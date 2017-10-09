using System.Collections;
using System.Text;

namespace FluentAssertions.BestPractices.Tests
{
    public static class GenerateCode
    {
        public static string NamespaceName => "TestNamespace";
        public static string ClassName => "TestClass";
        public static string MethodName => "TestMethod";

        public static string ActualVariableName => "actual";
        public static string ExpectedVariableName => "expected";
        public static string CountVariable => "k";

        public static string ComplexClassName => "TestComplexClass";
        public static string ComplexClassBooleanpropertyName => "BooleanProperty";


        public static string EnumerableAssertion(string assertion) => new StringBuilder()
            .AppendLine($"namespace {NamespaceName}")
            .AppendLine("{")
            .AppendLine($"    class {ClassName}")
            .AppendLine("    {")
            .AppendLine($"        void {MethodName}({nameof(IEnumerable)}<{ComplexClassName}> {ActualVariableName}, {ComplexClassName} {ExpectedVariableName}, int {CountVariable})")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine($"    class {ComplexClassName}")
            .AppendLine("    {")
            .AppendLine($"        public bool {ComplexClassBooleanpropertyName} {{ get; set; }}")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string NumericAssertion(string assertion) => new StringBuilder()
            .AppendLine($"namespace {NamespaceName}")
            .AppendLine("{")
            .AppendLine($"    class {ClassName}")
            .AppendLine("    {")
            .AppendLine($"        void {MethodName}(int {ActualVariableName}, int {ExpectedVariableName})")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();
    }
}
