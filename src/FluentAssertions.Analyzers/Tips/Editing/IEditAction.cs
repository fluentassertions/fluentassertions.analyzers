using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;

namespace FluentAssertions.Analyzers;

public interface IEditAction
{
    void Apply(DocumentEditor editor, InvocationExpressionSyntax invocationExpression);
}
