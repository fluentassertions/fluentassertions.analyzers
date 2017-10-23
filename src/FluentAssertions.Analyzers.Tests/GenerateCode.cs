using System;
using System.Text;

namespace FluentAssertions.Analyzers.Tests
{
    public static class GenerateCode
    {
        public static string ActualVariableName => "actual";

        public static string EnumerableCodeBlockAssertion(string assertion) => EnumerableAssertion(
            "        {" + Environment.NewLine +
            "            " + assertion + Environment.NewLine +
            "        }");
        public static string EnumerableExpressionBodyAssertion(string assertion) => EnumerableAssertion(
            "            => " + assertion);

        private static string EnumerableAssertion(string bodyExpression) => new StringBuilder()
            .AppendLine("using System.Collections.Generic;")
            .AppendLine("using System.Linq;")
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    public class TestClass")
            .AppendLine("    {")
            .AppendLine($"        public void TestMethod(IList<TestComplexClass> {ActualVariableName}, IList<TestComplexClass> expected, IList<TestComplexClass> unexpected, TestComplexClass expectedItem, TestComplexClass unexpectedItem, int k)")
            .AppendLine(bodyExpression)
            .AppendLine("    }")
            .AppendLine("    public class TestComplexClass")
            .AppendLine("    {")
            .AppendLine("        public bool BooleanProperty { get; set; }")
            .AppendLine("        public string Message { get; set; }")
            .AppendLine("    }")
            .AppendLine("    class Program")
            .AppendLine("    {")
            .AppendLine("        public static void Main()")
            .AppendLine("        {")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string DictionaryAssertion(string assertion) => new StringBuilder()
            .AppendLine("using System.Collections.Generic;")
            .AppendLine("using System.Linq;")
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    public class TestClass")
            .AppendLine("    {")
            .AppendLine($"        public void TestMethod(Dictionary<string, TestComplexClass> {ActualVariableName}, IDictionary<string, TestComplexClass> expected, IDictionary<string, TestComplexClass> unexpected, string expectedKey, TestComplexClass expectedValue, string unexpectedKey, TestComplexClass unexpectedValue, KeyValuePair<string, TestComplexClass> pair)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine($"    public class TestComplexClass")
            .AppendLine("    {")
            .AppendLine("        public bool BooleanProperty { get; set; }")
            .AppendLine("    }")
            .AppendLine("    class Program")
            .AppendLine("    {")
            .AppendLine($"        public static void Main()")
            .AppendLine("        {")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string NumericAssertion(string assertion) => new StringBuilder()
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod(int {ActualVariableName}, int expected)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();
    }
}
