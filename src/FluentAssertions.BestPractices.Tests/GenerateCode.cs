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
        public static string ExpectedItemVariableName => "expectedItem";
        public static string UnexpectedVariableName => "unexpected";
        public static string UnexpectedItemVariableName => "unexpectedItem";
        public static string CountVariable => "k";

        public static string ComplexClassName => "TestComplexClass";
        public static string ComplexClassBooleanpropertyName => "BooleanProperty";
                
        public static string EnumerableAssertion(string assertion) => new StringBuilder()
            .AppendLine("using System.Collections.Generic;")
            .AppendLine("using System.Linq;")
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine($"namespace {NamespaceName}")
            .AppendLine("{")
            .AppendLine($"    public class {ClassName}")
            .AppendLine("    {")
            .AppendLine($"        public void {MethodName}({nameof(IList)}<{ComplexClassName}> {ActualVariableName}, {nameof(IList)}<{ComplexClassName}> {ExpectedVariableName}, {nameof(IList)}<{ComplexClassName}> {UnexpectedVariableName}, {ComplexClassName} {ExpectedItemVariableName}, {ComplexClassName} {UnexpectedItemVariableName}, int {CountVariable})")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine($"    public class {ComplexClassName}")
            .AppendLine("    {")
            .AppendLine($"        public bool {ComplexClassBooleanpropertyName} {{ get; set; }}")
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
