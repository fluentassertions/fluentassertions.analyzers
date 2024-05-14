using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions.Analyzers.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.Simplification;

namespace FluentAssertions.Analyzers;

public abstract class TestingFrameworkCodeFixProvider<TTestContext> : CodeFixProviderBase<TTestContext> where TTestContext : TestingFrameworkCodeFixProvider.TestingFrameworkCodeFixContext
{
    protected override string Title => "Replace with FluentAssertions";

    protected override Func<CancellationToken, Task<Document>> TryComputeFix(IInvocationOperation invocation, CodeFixContext context, TTestContext t, Diagnostic diagnostic)
    {
        var fix = TryComputeFixCore(invocation, context, t, diagnostic);
        if (fix is null)
        {
            return null;
        }

        return async ctx =>
        {
            const string fluentAssertionNamespace = "FluentAssertions";
            var document = await fix(ctx);

            var model = await document.GetSemanticModelAsync();
            var scopes = model.GetImportScopes(diagnostic.Location.SourceSpan.Start);

            var hasFluentAssertionImport = scopes.Any(scope => scope.Imports.Any(import => import.NamespaceOrType.ToString().Equals(fluentAssertionNamespace)));
            if (hasFluentAssertionImport)
            {
                return document;
            }

            var root = (CompilationUnitSyntax)await document.GetSyntaxRootAsync();
            root = root.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(fluentAssertionNamespace)).WithAdditionalAnnotations(Simplifier.AddImportsAnnotation));

            document = document.WithSyntaxRoot(root);
            document = await Formatter.OrganizeImportsAsync(document);

            return document;
        };
    }

    protected abstract Func<CancellationToken, Task<Document>> TryComputeFixCore(IInvocationOperation invocation, CodeFixContext context, TTestContext t, Diagnostic diagnostic);

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

}

public abstract class TestingFrameworkCodeFixProvider : TestingFrameworkCodeFixProvider<TestingFrameworkCodeFixProvider.TestingFrameworkCodeFixContext>
{
    protected override TestingFrameworkCodeFixContext CreateTestContext(SemanticModel semanticModel) => new(semanticModel.Compilation);


    public class TestingFrameworkCodeFixContext(Compilation compilation)
    {
        public INamedTypeSymbol Object { get; } = compilation.ObjectType;
        public INamedTypeSymbol String { get; } = compilation.GetTypeByMetadataName("System.String");
        public INamedTypeSymbol Int32 { get; } = compilation.GetTypeByMetadataName("System.Int32");
        public INamedTypeSymbol UInt32 { get; } = compilation.GetTypeByMetadataName("System.UInt32");
        public INamedTypeSymbol Long { get; } = compilation.GetTypeByMetadataName("System.Int64");
        public INamedTypeSymbol ULong { get; } = compilation.GetTypeByMetadataName("System.UInt64");
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