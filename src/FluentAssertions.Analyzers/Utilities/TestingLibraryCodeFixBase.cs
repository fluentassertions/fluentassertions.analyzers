using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FluentAssertions.Analyzers.Utilities;

public abstract class TestingLibraryCodeFixBase : FluentAssertionsCodeFixProvider
{
    protected abstract string AssertClassName { get; }

    protected ExpressionSyntax RenameMethodAndReplaceWithSubjectShould(ExpressionSyntax expression, string oldName, string newName)
    {
        var rename = NodeReplacement.RenameAndRemoveFirstArgument(oldName, newName);
        var newExpression = GetNewExpression(expression, rename);

        return ReplaceIdentifier(newExpression, AssertClassName, Expressions.SubjectShould(rename.Argument.Expression));
    }

    protected ExpressionSyntax RenameMethodAndReorderActualExpectedAndReplaceWithSubjectShould(ExpressionSyntax expression, string oldName, string newName)
    {
        var rename = NodeReplacement.RenameAndExtractArguments(oldName, newName);
        var newExpression = GetNewExpression(expression, rename);

        var actual = rename.Arguments[1];

        newExpression = ReplaceIdentifier(newExpression, AssertClassName, Expressions.SubjectShould(actual.Expression));

        return GetNewExpression(newExpression, NodeReplacement.WithArguments(newName, rename.Arguments.RemoveAt(1)));
    }
}
