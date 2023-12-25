using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using CreateChangedDocument = System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<Microsoft.CodeAnalysis.Document>>;

namespace FluentAssertions.Analyzers;

public abstract class TestingFrameworkCodeFixProvider : CodeFixProvider
{
    protected const string Title = "Replace with FluentAssertions";

    public override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

    public override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken);
        var semanticModel = await context.Document.GetSemanticModelAsync(context.CancellationToken);

        var testContext = new TestingFrameworkCodeFixContext(semanticModel.Compilation);
        foreach (var diagnostic in context.Diagnostics)
        {
            var node = root.FindNode(diagnostic.Location.SourceSpan);
            if (node is not InvocationExpressionSyntax invocationExpression)
            {
                continue;
            }

            var operation = semanticModel.GetOperation(invocationExpression, context.CancellationToken);
            if (operation is not IInvocationOperation invocation)
            {
                continue;
            }

            var fix = TryComputeFix(invocation, context, testContext, diagnostic);
            if (fix is not null)
            {
                context.RegisterCodeFix(CodeAction.Create(Title, fix, equivalenceKey: Title), diagnostic);
            }
        }
    }

    protected abstract CreateChangedDocument TryComputeFix(IInvocationOperation invocation, CodeFixContext context, TestingFrameworkCodeFixContext t, Diagnostic diagnostic);

    protected static bool ArgumentsAreTypeOf(IInvocationOperation invocation, params ITypeSymbol[] types) => ArgumentsAreTypeOf(invocation, 0, types);
    protected static bool ArgumentsAreTypeOf(IInvocationOperation invocation, int startFromIndex, params ITypeSymbol[] types)
    {
        if (invocation.TargetMethod.Parameters.Length != types.Length + startFromIndex)
        {
            return false;
        }

        for (int i = startFromIndex; i < types.Length; i++)
        {
            if (!invocation.TargetMethod.Parameters[i].Type.EqualsSymbol(types[i]))
            {
                return false;
            }
        }

        return true;
    }

    protected static bool ArgumentsAreGenericTypeOf(IInvocationOperation invocation, params ITypeSymbol[] types)
    {
        const int generics = 1;
        if (invocation.TargetMethod.Parameters.Length != types.Length)
        {
            return false;
        }

        if (invocation.TargetMethod.TypeArguments.Length != generics)
        {
            return false;
        }

        var genericType = invocation.TargetMethod.TypeArguments[0];

        for (int i = 0; i < types.Length; i++)
        {
            if (invocation.TargetMethod.Parameters[i].Type is not INamedTypeSymbol parameterType)
            {
                return false;
            }

            if (parameterType.TypeArguments.IsEmpty && parameterType.EqualsSymbol(genericType))
            {
                continue;
            }

            if (parameterType.TypeArguments.Length != generics
            || !(parameterType.TypeArguments[0].EqualsSymbol(genericType) && parameterType.OriginalDefinition.EqualsSymbol(types[i])))
            {
                return false;
            }
        }

        return true;
    }

    protected static bool ArgumentsCount(IInvocationOperation invocation, int arguments)
    {
        return invocation.TargetMethod.Parameters.Length == arguments;
    }

    protected sealed class TestingFrameworkCodeFixContext(Compilation compilation)
    {
        public INamedTypeSymbol Object { get; } = compilation.ObjectType;
        public INamedTypeSymbol String { get; } = compilation.GetTypeByMetadataName("System.String");
        public INamedTypeSymbol Int32 { get; } = compilation.GetTypeByMetadataName("System.Int32");
        public INamedTypeSymbol Float { get; } = compilation.GetTypeByMetadataName("System.Single");
        public INamedTypeSymbol Double { get; } = compilation.GetTypeByMetadataName("System.Double");
        public INamedTypeSymbol Decimal { get; } = compilation.GetTypeByMetadataName("System.Decimal");
        public INamedTypeSymbol Boolean { get; } = compilation.GetTypeByMetadataName("System.Boolean");
        public INamedTypeSymbol Action { get; } = compilation.GetTypeByMetadataName("System.Action");
        public INamedTypeSymbol Type { get; } = compilation.GetTypeByMetadataName("System.Type");
        public INamedTypeSymbol DateTime { get; } = compilation.GetTypeByMetadataName("System.DateTime");
        public INamedTypeSymbol TimeSpan { get; } = compilation.GetTypeByMetadataName("System.TimeSpan");
        public INamedTypeSymbol FuncOfObject { get; } = compilation.GetTypeByMetadataName("System.Func`1").Construct(compilation.ObjectType);
        public INamedTypeSymbol FuncOfTask { get; } = compilation.GetTypeByMetadataName("System.Func`1").Construct(compilation.GetTypeByMetadataName("System.Threading.Tasks.Task"));
        public IArrayTypeSymbol ObjectArray { get; } = compilation.CreateArrayTypeSymbol(compilation.ObjectType);
        public INamedTypeSymbol CultureInfo { get; } = compilation.GetTypeByMetadataName("System.Globalization.CultureInfo");
        public INamedTypeSymbol StringComparison { get; } = compilation.GetTypeByMetadataName("System.StringComparison");
        public INamedTypeSymbol Regex { get; } = compilation.GetTypeByMetadataName("System.Text.RegularExpressions.Regex");
        public INamedTypeSymbol ICollection { get; } = compilation.GetTypeByMetadataName("System.Collections.ICollection");
        public INamedTypeSymbol IComparer { get; } = compilation.GetTypeByMetadataName("System.Collections.IComparer");
        public INamedTypeSymbol IEqualityComparerOfT1 { get; } = compilation.GetTypeByMetadataName("System.Collections.Generic.IEqualityComparer`1");
        public INamedTypeSymbol IEnumerableOfT1 { get; } = compilation.GetTypeByMetadataName("System.Collections.Generic.IEnumerable`1");

        public INamedTypeSymbol Identity { get; } = null;
    }
}