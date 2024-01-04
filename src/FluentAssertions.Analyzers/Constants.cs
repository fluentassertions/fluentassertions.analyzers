namespace FluentAssertions.Analyzers;

public static class Constants
{
    public static class DiagnosticProperties
    {
        public const string VisitorName = nameof(VisitorName);
        public const string HelpLink = nameof(HelpLink);
        public const string IdPrefix = "FluentAssertions";
    }

    public static class Tips
    {
        public const string Category = "FluentAssertionTips";
    }

    public static class CodeSmell
    {
        public const string Category = "FluentAssertionCodeSmell";

        public const string AsyncVoid = $"{DiagnosticProperties.IdPrefix}0801";
        public const string ShouldEquals = $"{DiagnosticProperties.IdPrefix}0802";
    }
}
