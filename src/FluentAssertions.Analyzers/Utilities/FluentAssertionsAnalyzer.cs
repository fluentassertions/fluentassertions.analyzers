using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace FluentAssertions.Analyzers;

public abstract class FluentAssertionsAnalyzer<TCSharpSyntaxVisitor> : DiagnosticAnalyzer where TCSharpSyntaxVisitor : FluentAssertionsCSharpSyntaxVisitor
{
    public const string Title = "Simplify Assertion";
    protected abstract DiagnosticDescriptor Rule { get; }

    protected abstract IEnumerable<TCSharpSyntaxVisitor> Visitors { get; }

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

    public sealed override void Initialize(AnalysisContext context)
    {
        context.EnableConcurrentExecution();
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.RegisterSyntaxNodeAction(AnalyzeExpressionStatementSyntax, SyntaxKind.ExpressionStatement, SyntaxKind.ArrowExpressionClause);
    }

    private void AnalyzeExpressionStatementSyntax(SyntaxNodeAnalysisContext context)
    {
        ExpressionSyntax expression = context.Node.Kind() switch
        {
            SyntaxKind.ExpressionStatement => ((ExpressionStatementSyntax)context.Node).Expression,
            SyntaxKind.ArrowExpressionClause => ((ArrowExpressionClauseSyntax)context.Node).Expression,
            _ => null
        };
        if (expression == null)
        {
            return;
        }

        var diagnostic = AnalyzeExpressionSafely(expression, context.SemanticModel);
        if (diagnostic != null)
        {
            context.ReportDiagnostic(diagnostic);
        }
    }

    protected virtual bool ShouldAnalyzeVariableNamedType(INamedTypeSymbol type, SemanticModel semanticModel) => true;
    protected virtual bool ShouldAnalyzeVariableType(ITypeSymbol type, SemanticModel semanticModel) => true;

    private bool ShouldAnalyzeVariableTypeCore(IdentifierNameSyntax identifier, SemanticModel semanticModel)
    {
        ISymbol symbol = semanticModel.GetTypeInfo(identifier).Type ?? semanticModel.GetSymbolInfo(identifier).Symbol;  
        if (symbol is INamedTypeSymbol namedType)
        {
            return ShouldAnalyzeVariableNamedType(namedType, semanticModel);
        }

        if (symbol is ITypeSymbol typeSymbol)
        {
            return ShouldAnalyzeVariableType(typeSymbol, semanticModel);
        }

        return false;
    }

    protected virtual Diagnostic AnalyzeExpression(ExpressionSyntax expression, SemanticModel semanticModel)
    {
        var variableNameExtractor = new VariableNameExtractor(semanticModel);
        expression.Accept(variableNameExtractor);

        if (variableNameExtractor.PropertiesAccessed.TrueForAll(identifier => !ShouldAnalyzeVariableTypeCore(identifier, semanticModel))) {
            return null;
        }

        foreach (var visitor in Visitors)
        {
            visitor.SemanticModel = semanticModel;
            expression.Accept(visitor);

            if (visitor.IsValid(expression))
            {
                return CreateDiagnostic(visitor, expression);
            }
        }
        return null;
    }

    protected virtual Diagnostic CreateDiagnostic(TCSharpSyntaxVisitor visitor, ExpressionSyntax expression)
    {
        var properties = visitor.ToDiagnosticProperties()
            .Add(Constants.DiagnosticProperties.Title, Title);
        var newRule = new DiagnosticDescriptor(Rule.Id, Rule.Title, Rule.MessageFormat, Rule.Category, Rule.DefaultSeverity, true,
            helpLinkUri: properties.GetValueOrDefault(Constants.DiagnosticProperties.HelpLink));
        return Diagnostic.Create(
            descriptor: newRule,
            location: expression.GetLocation(),
            properties: properties);
    }

    private Diagnostic AnalyzeExpressionSafely(ExpressionSyntax expression, SemanticModel semanticModel)
    {
        try
        {
            return AnalyzeExpression(expression, semanticModel);
        }
        catch (Exception e)
        {
            var expressionString = "UNKNOWN";
            try {
                expressionString = expression.ToString();
            } catch {}
            Console.Error.WriteLine($"Failed to analyze expression in {GetType().FullName}. expression: {expressionString}\n{e}");

            #if DEBUG
            throw e;
            #else
            return null;
            #endif
        }
    }
}

public abstract class FluentAssertionsAnalyzer : FluentAssertionsAnalyzer<FluentAssertionsCSharpSyntaxVisitor>
{
}