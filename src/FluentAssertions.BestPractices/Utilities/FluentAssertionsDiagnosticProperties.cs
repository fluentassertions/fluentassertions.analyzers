using System.Collections.Immutable;

namespace FluentAssertions.BestPractices
{

    public class FluentAssertionsDiagnosticProperties
    {
        public ImmutableDictionary<string, string> Properties { get; }

        public FluentAssertionsDiagnosticProperties(ImmutableDictionary<string, string> properties)
        {
            Properties = properties;
        }

        public string Title => Properties[Constants.DiagnosticProperties.Title];
        public string VariableName => Properties[Constants.DiagnosticProperties.VariableName];
        public string BecauseArgumentsString => Properties[Constants.DiagnosticProperties.BecauseArgumentsString];
        public string PredicateString => Properties[Constants.DiagnosticProperties.PredicateString];
        public string ExpectedItemString => Properties[Constants.DiagnosticProperties.ExpectedItemString];
        public string UnexpectedItemString => Properties[Constants.DiagnosticProperties.UnexpectedItemString];
        public string CountArgument => Properties[Constants.DiagnosticProperties.CountArgument];

        public string CombineWithBecauseArgumentsString(string validArgument)
        {
            if (!string.IsNullOrWhiteSpace(BecauseArgumentsString))
            {
                return $"{validArgument}, {BecauseArgumentsString}";
            }
            return validArgument;
        }
    }
}
