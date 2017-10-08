using System;
using System.Collections;
using System.Text;

namespace FluentAssertions.BestPractices.Tests
{
    public static class GenerateCode
    {
        public static readonly string NamespaceName = "TestNamespace";
        public static readonly string ClassName = "TestClass";
        public static readonly string MethodName = "TestMethod";
        public static readonly string VariableName = "actual";

        public static readonly string ComplexClassName = "TestComplexClass";
        public static readonly string ComplexClassBooleanpropertyName = "BooleanProperty";


        public static string EnumerableAssertion(string assertion) => new StringBuilder()
            .AppendLine($"namespace {NamespaceName}")
            .AppendLine("{")
            .AppendLine($"    class {ClassName}")
            .AppendLine("    {")
            .AppendLine($"        void {MethodName}({nameof(IEnumerable)}<{ComplexClassName}> {VariableName})")
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
            .AppendLine($"        void {MethodName}(int {VariableName})")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();
    }
}
