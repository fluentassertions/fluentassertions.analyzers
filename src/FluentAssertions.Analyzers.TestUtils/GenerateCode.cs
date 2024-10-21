﻿using System;
using System.Text;

namespace FluentAssertions.Analyzers.TestUtils
{
    public static class GenerateCode
    {
        public static string GenericArrayCodeBlockAssertion(string assertion) => GenericArrayAssertion(
            "        {" + Environment.NewLine +
            "            " + assertion + Environment.NewLine +
            "        }");
        public static string GenericArrayExpressionBodyAssertion(string assertion) => GenericArrayAssertion(
            "            => " + assertion);

        private static string GenericArrayAssertion(string bodyExpression) => new StringBuilder()
            .AppendLine("using System.Collections.Generic;")
            .AppendLine("using System.Linq;")
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;using FluentAssertions.Extensions;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    public class TestClass")
            .AppendLine("    {")
            .AppendLine("        public void TestMethod(TestComplexClass[] actual, TestComplexClass[] expected, TestComplexClass[] unexpected, TestComplexClass expectedItem, TestComplexClass unexpectedItem, int k)")
            .AppendLine(bodyExpression)
            .AppendLine("    }")
            .AppendLine("    public class TestComplexClass")
            .AppendLine("    {")
            .AppendLine("        public bool BooleanProperty { get; set; }")
            .AppendLine("        public string Message { get; set; }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string GenericIListCodeBlockAssertion(string assertion) => GenericIListAssertion(
            "        {" + Environment.NewLine +
            "            " + assertion + Environment.NewLine +
            "        }");
        public static string GenericIListExpressionBodyAssertion(string assertion) => GenericIListAssertion(
            "            => " + assertion);

        private static string GenericIListAssertion(string bodyExpression) => new StringBuilder()
            .AppendLine("using System.Collections.Generic;")
            .AppendLine("using System.Linq;")
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;using FluentAssertions.Extensions;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    public class TestClass")
            .AppendLine("    {")
            .AppendLine("        public void TestMethod(IList<TestComplexClass> actual, IList<TestComplexClass> expected, IList<TestComplexClass> unexpected, TestComplexClass expectedItem, TestComplexClass unexpectedItem, int k)")
            .AppendLine(bodyExpression)
            .AppendLine("    }")
            .AppendLine("    public class TestComplexClass")
            .AppendLine("    {")
            .AppendLine("        public bool BooleanProperty { get; set; }")
            .AppendLine("        public string Message { get; set; }")
            .AppendLine("        public TestComplexClass this[int index] => throw new NotImplementedException();")
            .AppendLine("    }")
            .AppendLine()
            .AppendLine("}")
            .ToString();

        public static string GenericIEnumerableAssertion(string assertion) => new StringBuilder()
            .AppendLine("using System.Collections.Generic;")
            .AppendLine("using System.Linq;")
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;using FluentAssertions.Extensions;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    public class TestClass")
            .AppendLine("    {")
            .AppendLine("        public void TestMethod<T>(IEnumerable<T> actual, IEnumerable<T> expected)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string GenericIDictionaryAssertion(string assertion) => new StringBuilder()
            .AppendLine("using System.Collections.Generic;")
            .AppendLine("using System.Linq;")
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    public class TestClass")
            .AppendLine("    {")
            .AppendLine("        public void TestMethod(Dictionary<string, TestComplexClass> actual, IDictionary<string, TestComplexClass> expected, IDictionary<string, TestComplexClass> unexpected, string expectedKey, TestComplexClass expectedValue, string unexpectedKey, TestComplexClass unexpectedValue, KeyValuePair<string, TestComplexClass> pair, KeyValuePair<string, TestComplexClass> otherPair)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("    public class TestComplexClass")
            .AppendLine("    {")
            .AppendLine("        public bool BooleanProperty { get; set; }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string DoubleAssertion(string assertion) => NumericAssertion(assertion, "double");

        public static string NumericAssertion(string assertion, string type) => new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod({type} actual, {type} expected, {type} lower, {type} upper, {type} delta)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string ComparableInt32Assertion(string assertion) => new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine("        void TestMethod(IComparable<int> actual, int expected)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string StringAssertion(string assertion) => new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;using FluentAssertions.Extensions;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine("        void TestMethod(string actual, string expected, int k)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string ExceptionAssertion(string assertion) => new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;using FluentAssertions.Extensions;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine("        void TestMethod(Action action, string expectedMessage)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string AsyncFunctionStatement(string statement) => new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using System.Threading.Tasks;")
            .AppendLine("using FluentAssertions;using FluentAssertions.Extensions;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine("        void TestMethod()")
            .AppendLine("        {")
            .AppendLine($"            {statement}")
            .AppendLine("        }")
            .AppendLine("        async void AsyncVoidMethod() { await Task.CompletedTask; }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string ObjectStatement(string statement) => new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using System.Threading.Tasks;")
            .AppendLine("using FluentAssertions;using FluentAssertions.Extensions;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine("        void TestMethod(object actual, object expected)")
            .AppendLine("        {")
            .AppendLine($"            {statement}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string MsTestAssertion(string methodArguments, string assertion) => new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("using Microsoft.VisualStudio.TestTools.UnitTesting;")
            .AppendLine("using System.Threading.Tasks;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod({methodArguments})")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string XunitAssertion(string methodArguments, string assertion) => new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using System.Collections.Generic;")
            .AppendLine("using System.Collections.Immutable;")
            .AppendLine("using System.Text.RegularExpressions;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("using Xunit;")
            .AppendLine("using System.Threading.Tasks;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod({methodArguments})")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string Nunit3Assertion(string methodArguments, string assertion) => new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using System.Collections;")
            .AppendLine("using System.Collections.Generic;")
            .AppendLine("using System.Collections.Immutable;")
            .AppendLine("using System.Text.RegularExpressions;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("using NUnit.Framework;")
            .AppendLine("using System.Threading.Tasks;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod({methodArguments})")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();

        public static string Nunit4Assertion(string methodArguments, string assertion) => new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using System.Collections;")
            .AppendLine("using System.Collections.Generic;")
            .AppendLine("using System.Collections.Immutable;")
            .AppendLine("using System.Text.RegularExpressions;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("using NUnit.Framework; using NUnit.Framework.Legacy;")
            .AppendLine("using System.Threading.Tasks;")
            .AppendLine("namespace TestNamespace")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod({methodArguments})")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();
    }
}
