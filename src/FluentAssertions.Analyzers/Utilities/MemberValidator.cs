using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;

namespace FluentAssertions.Analyzers
{
    public delegate bool ArgumentsPredicate(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel);
    public delegate bool ArgumentPredicate(ArgumentSyntax argument, SemanticModel semanticModel);

    [DebuggerDisplay("{Name}")]
    public class MemberValidator
    {
        private readonly ArgumentsPredicate _argumentsPredicate;

        public string Name { get; }

        public MemberValidator(string name)
        {
            Name = name;
            _argumentsPredicate = (arguments, semanticModel) => true;
        }

        public MemberValidator(string name, ArgumentsPredicate argumentsPredicate)
        {
            Name = name;
            _argumentsPredicate = argumentsPredicate;
        }

        public bool MatchesInvocationExpression(InvocationExpressionSyntax invocation, SemanticModel semanticModel)
        {
            return _argumentsPredicate(invocation.ArgumentList.Arguments, semanticModel);
        }

        public bool MatchesElementAccessExpression(ElementAccessExpressionSyntax elementAccess, SemanticModel semanticModel)
        {
            return _argumentsPredicate(elementAccess.ArgumentList.Arguments, semanticModel);
        }

        public static MemberValidator And { get; } = new MemberValidator(nameof(And));
        public static MemberValidator Which { get; } = new MemberValidator(nameof(Which));
        public static MemberValidator Should { get; } = new MemberValidator(nameof(Should));

        public static MemberValidator MethodNotContainingLambda(string name) => new MemberValidator(name, MethodNotContainingLambdaPredicate);
        public static MemberValidator MethodContainingLambda(string name) => new MemberValidator(name, MethodContainingLambdaPredicate);
        public static MemberValidator ArgumentIsVariable(string name) => new MemberValidator(name, ArgumentIsVariablePredicate);
        public static MemberValidator ArgumentIsLiteral<T>(string name, T value) => new MemberValidator(name, (arguments, semanticModel) => ArgumentIsLiteralPredicate(arguments, value));
        public static MemberValidator ArgumentIsIdentifierOrLiteral(string name) => new MemberValidator(name, ArgumentIsIdentifierOrLiteralPredicate);
        public static MemberValidator HasArguments(string name) => new MemberValidator(name, (arguments, semanticModel) => arguments.Any());
        public static MemberValidator HasArguments(string name, int count) => new MemberValidator(name, (arguments, semanticModel) => arguments.Count == count);
        public static MemberValidator HasNoArguments(string name) => new MemberValidator(name, (arguments, semanticModel) => !arguments.Any());
        public static MemberValidator ArgumentsMatch(string name, params ArgumentPredicate[] predicates) => new MemberValidator(name, (arguments, semanticModel) => ArgumentsMatchPredicate(arguments, predicates, semanticModel));

        public static bool MethodNotContainingLambdaPredicate(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel)
        {
            if (!arguments.Any()) return true;

            return !(arguments.First().Expression is LambdaExpressionSyntax);
        }
        public static bool MethodContainingLambdaPredicate(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel)
        {
            if (!arguments.Any()) return false;

            return arguments.First().Expression is LambdaExpressionSyntax;
        }
        public static bool ArgumentIsVariablePredicate(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel)
        {
            if (!arguments.Any()) return false;

            return ArgumentIsVariablePredicate(arguments.First());
        }
        public static bool ArgumentIsVariablePredicate(ArgumentSyntax argument)
        {
            if (argument.Expression is IdentifierNameSyntax identifier)
            {
                var argumentName = identifier.Identifier.Text;

                var variableName = VariableNameExtractor.ExtractVariableName(argument);

                return variableName == argumentName;
            }
            return false;
        }
        public static bool ArgumentIsLiteralPredicate<T>(SeparatedSyntaxList<ArgumentSyntax> arguments, T value)
        {
            return arguments.Any()
                && arguments.First().Expression is LiteralExpressionSyntax literal
                && literal.Token.Value is T argument
                && argument.Equals(value);
        }
        public static bool ArgumentIsIdentifierOrLiteralPredicate(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel)
        {
            if (!arguments.Any()) return false;

            var argumentsExpression = arguments.First().Expression;
            return argumentsExpression is IdentifierNameSyntax || argumentsExpression is LiteralExpressionSyntax;
        }
        public static bool ArgumentsMatchPredicate(SeparatedSyntaxList<ArgumentSyntax> arguments, ArgumentPredicate[] validators, SemanticModel semanticModel)
        {
            for (int i = 0; i < validators.Length && i < arguments.Count; i++)
            {
                if (!validators[i](arguments[i], semanticModel)) return false;
            }

            return true;
        }
    }
}