using FluentAssertions.Analyzers.TestUtils;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace FluentAssertions.Analyzers.Tests.Tips
{
    [TestClass]
    public class MsTestTests
    {
        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsTrue(actual{0});")]
        [AssertionDiagnostic("Assert.IsTrue(bool.Parse(\"true\"){0});")]
        [Implemented]
        public void AssertIsTrue_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("bool actual", assertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsTrue(actual{0});")]
        [AssertionDiagnostic("Assert.IsTrue(bool.Parse(\"true\"){0});")]
        [Implemented]
        public void AssertIsTrue_NestedUsingInNamespace1_TestAnalyzer(string assertion)
            => VerifyCSharpDiagnostic<AssertAnalyzer>(new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("using System.Threading.Tasks;")
            .AppendLine("namespace Microsoft.VisualStudio.TestTools")
            .AppendLine("{")
            .AppendLine("    using UnitTesting;")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod(bool actual)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString());

        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsTrue(actual{0});")]
        [AssertionDiagnostic("Assert.IsTrue(bool.Parse(\"true\"){0});")]
        [Implemented]
        public void AssertIsTrue_NestedUsingInNamespace2_TestAnalyzer(string assertion)
            => VerifyCSharpDiagnostic<AssertAnalyzer>(new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("using System.Threading.Tasks;")
            .AppendLine("namespace Microsoft.VisualStudio")
            .AppendLine("{")
            .AppendLine("    using TestTools.UnitTesting;")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod(bool actual)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString());

        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsTrue(actual{0});")]
        [AssertionDiagnostic("Assert.IsTrue(bool.Parse(\"true\"){0});")]
        [Implemented]
        public void AssertIsTrue_NestedUsingInNamespace3_TestAnalyzer(string assertion)
            => VerifyCSharpDiagnostic<AssertAnalyzer>(new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("using System.Threading.Tasks;")
            .AppendLine("namespace Microsoft")
            .AppendLine("{ namespace VisualStudio {")
            .AppendLine("    using TestTools.UnitTesting;")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod(bool actual)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }}")
            .AppendLine("}")
            .ToString());

        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsTrue(actual{0});")]
        [AssertionDiagnostic("Assert.IsTrue(bool.Parse(\"true\"){0});")]
        [Implemented]
        public void AssertIsTrue_NestedUsingInNamespace4_TestAnalyzer(string assertion)
            => VerifyCSharpDiagnostic<AssertAnalyzer>(new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("using System.Threading.Tasks;")
            .AppendLine("namespace Microsoft")
            .AppendLine("{ namespace VisualStudio {")
            .AppendLine("    using TestTools   .   UnitTesting;")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod(bool actual)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }}")
            .AppendLine("}")
            .ToString());

        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsTrue(actual{0});")]
        [AssertionDiagnostic("Assert.IsTrue(bool.Parse(\"true\"){0});")]
        [Implemented]
        public void AssertIsTrue_NestedUsingInNamespace5_TestAnalyzer(string assertion)
            => VerifyCSharpDiagnostic<AssertAnalyzer>(new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("using System.Threading.Tasks;")
            .AppendLine("using Microsoft . VisualStudio . TestTools . UnitTesting;")
            .AppendLine("namespace Testing")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod(bool actual)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString());

        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsTrue(actual{0});")]
        [AssertionDiagnostic("Assert.IsTrue(bool.Parse(\"true\"){0});")]
        [Implemented]
        public void AssertIsTrue_NestedUsingInNamespace6_TestAnalyzer(string assertion)
            => VerifyCSharpDiagnostic<AssertAnalyzer>(new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("using System.Threading.Tasks; using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;")
            .AppendLine("using Microsoft . VisualStudio . TestTools . UnitTesting;")
            .AppendLine("namespace Testing")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod(bool actual)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString());

        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsTrue(actual{0});")]
        [AssertionDiagnostic("Assert.IsTrue(bool.Parse(\"true\"){0});")]
        [Implemented]
        public void AssertIsTrue_NestedUsingInNamespace7_TestAnalyzer(string assertion)
            => VerifyCSharpDiagnostic<AssertAnalyzer>(new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("using System.Threading.Tasks; using MsAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;")
            .AppendLine("using Microsoft . VisualStudio . TestTools . UnitTesting;")
            .AppendLine("namespace Testing")
            .AppendLine("{")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod(bool actual)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString());

        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsTrue(actual{0});")]
        [AssertionDiagnostic("Assert.IsTrue(bool.Parse(\"true\"){0});")]
        [Implemented]
        public void AssertIsTrue_NestedUsingInNamespace8_TestAnalyzer(string assertion)
            => VerifyCSharpDiagnostic<AssertAnalyzer>(new StringBuilder()
            .AppendLine("using System;")
            .AppendLine("using FluentAssertions;")
            .AppendLine("using FluentAssertions.Extensions;")
            .AppendLine("using System.Threading.Tasks;")
            .AppendLine("namespace Testing")
            .AppendLine("{")
            .AppendLine("    using Microsoft.VisualStudio.TestTools.UnitTesting;")
            .AppendLine("    class TestClass")
            .AppendLine("    {")
            .AppendLine($"        void TestMethod(bool actual)")
            .AppendLine("        {")
            .AppendLine($"            {assertion}")
            .AppendLine("        }")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString());

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsTrue(actual{0});",
            newAssertion: "actual.Should().BeTrue({0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsTrue(bool.Parse(\"true\"){0});",
            newAssertion: "bool.Parse(\"true\").Should().BeTrue({0});")]
        [Implemented]
        public void AssertIsTrue_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("bool actual", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsFalse(actual{0});")]
        [AssertionDiagnostic("Assert.IsFalse(bool.Parse(\"true\"){0});")]
        [Implemented]
        public void AssertIsFalse_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("bool actual", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsFalse(actual{0});",
            newAssertion: "actual.Should().BeFalse({0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsFalse(bool.Parse(\"true\"){0});",
            newAssertion: "bool.Parse(\"true\").Should().BeFalse({0});")]
        [Implemented]
        public void AssertIsFalse_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("bool actual", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsNull(actual{0});")]
        [Implemented]
        public void AssertIsNull_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("object actual", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsNull(actual{0});",
            newAssertion: "actual.Should().BeNull({0});")]
        [Implemented]
        public void AssertIsNull_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("object actual", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsNotNull(actual{0});")]
        [Implemented]
        public void AssertIsNotNull_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("object actual", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsNotNull(actual{0});",
            newAssertion: "actual.Should().NotBeNull({0});")]
        [Implemented]
        public void AssertIsNotNull_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("object actual", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsInstanceOfType(actual, type{0});")]
        [AssertionDiagnostic("Assert.IsInstanceOfType(actual, typeof(string){0});")]
        [AssertionDiagnostic("Assert.IsInstanceOfType<string>(actual{0});")]
        [Implemented]
        public void AssertIsInstanceOfType_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("object actual, Type type", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsInstanceOfType(actual, type{0});",
            newAssertion: "actual.Should().BeOfType(type{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsInstanceOfType(actual, typeof(string){0});",
            newAssertion: "actual.Should().BeOfType<string>({0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsInstanceOfType<string>(actual{0});",
            newAssertion: "actual.Should().BeOfType<string>({0});")]
        [Implemented]
        public void AssertIsInstanceOfType_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("object actual, Type type", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.IsNotInstanceOfType(actual, type{0});")]
        [AssertionDiagnostic("Assert.IsNotInstanceOfType(actual, typeof(string){0});")]
        [Implemented]
        public void AssertIsNotInstanceOfType_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("object actual, Type type", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsNotInstanceOfType(actual, type{0});",
            newAssertion: "actual.Should().NotBeOfType(type{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.IsNotInstanceOfType(actual, typeof(string){0});",
            newAssertion: "actual.Should().NotBeOfType<string>({0});")]
        [Implemented]
        public void AssertIsNotInstanceOfType_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("object actual, Type type", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual{0});")]
        [Implemented]
        public void AssertObjectAreEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("object actual, object expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual{0});",
            newAssertion: "actual.Should().Be(expected{0});")]
        [Implemented]
        public void AssertObjectAreEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("object actual, object expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual{0});")]
        [Implemented]
        public void AssertOptionalIntAreEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("int? actual, int? expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual{0});",
            newAssertion: "actual.Should().Be(expected{0});")]
        [Implemented]
        public void AssertOptionalIntAreEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("int? actual, int? expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreEqual(actual, null{0});")]
        [Implemented]
        public void AssertOptionalIntAndNullAreEqual1_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("int? actual", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(actual, null{0});",
            newAssertion: "actual.Should().BeNull({0});")]
        [Implemented]
        public void AssertOptionalIntAndNullAreEqual1_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("int? actual", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreEqual(null, actual{0});")]
        [Implemented]
        public void AssertOptionalIntAndNullAreEqual2_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("int? actual", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(null, actual{0});",
            newAssertion: "actual.Should().BeNull({0});")]
        [Implemented]
        public void AssertOptionalIntAndNullAreEqual2_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("int? actual", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, delta{0});")]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, 0.6{0});")]
        [Implemented]
        public void AssertDoubleAreEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("double actual, double expected, double delta", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, delta{0});",
            newAssertion: "actual.Should().BeApproximately(expected, delta{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, 0.6{0});",
            newAssertion: "actual.Should().BeApproximately(expected, 0.6{0});")]
        [Implemented]
        public void AssertDoubleAreEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("double actual, double expected, double delta", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, delta{0});")]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, 0.6f{0});")]
        [Implemented]
        public void AssertFloatAreEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("float actual, float expected, float delta", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, delta{0});",
            newAssertion: "actual.Should().BeApproximately(expected, delta{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, 0.6f{0});",
            newAssertion: "actual.Should().BeApproximately(expected, 0.6f{0});")]
        [Implemented]
        public void AssertFloatAreEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("float actual, float expected, float delta", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual{0});")]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, false{0});")]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, true{0});")]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, false, System.Globalization.CultureInfo.CurrentCulture{0});")]
        [AssertionDiagnostic("Assert.AreEqual(expected, actual, true, System.Globalization.CultureInfo.CurrentCulture{0});")]
        [Implemented]
        public void AssertStringAreEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("string actual, string expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual{0});",
            newAssertion: "actual.Should().Be(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, false{0});",
            newAssertion: "actual.Should().Be(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, true{0});",
            newAssertion: "actual.Should().BeEquivalentTo(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, false, System.Globalization.CultureInfo.CurrentCulture{0});",
            newAssertion: "actual.Should().Be(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreEqual(expected, actual, true, System.Globalization.CultureInfo.CurrentCulture{0});",
            newAssertion: "actual.Should().BeEquivalentTo(expected{0});")]
        [Implemented]
        public void AssertStringAreEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("string actual, string expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual{0});")]
        [Implemented]
        public void AssertObjectAreNotEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("object actual, object expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual{0});",
            newAssertion: "actual.Should().NotBe(expected{0});")]
        [Implemented]
        public void AssertObjectAreNotEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("object actual, object expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, delta{0});")]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, 0.6{0});")]
        [Implemented]
        public void AssertDoubleAreNotEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("double actual, double expected, double delta", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, delta{0});",
            newAssertion: "actual.Should().NotBeApproximately(expected, delta{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, 0.6{0});",
            newAssertion: "actual.Should().NotBeApproximately(expected, 0.6{0});")]
        [Implemented]
        public void AssertDoubleAreNotEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("double actual, double expected, double delta", oldAssertion, newAssertion);


        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual{0});")]
        [Implemented]
        public void AssertOptionalIntAreNotEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("int? actual, int? expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual{0});",
            newAssertion: "actual.Should().NotBe(expected{0});")]
        [Implemented]
        public void AssertOptionalIntAreNotEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("int? actual, int? expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreNotEqual(actual, null{0});")]
        [Implemented]
        public void AssertOptionalIntAndNullAreNotEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("int? actual", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(actual, null{0});",
            newAssertion: "actual.Should().NotBeNull({0});")]
        [Implemented]
        public void AssertOptionalIntAndNullAreNotEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("int? actual", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, delta{0});")]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, 0.6f{0});")]
        [Implemented]
        public void AssertFloatAreNotEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("float actual, float expected, float delta", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, delta{0});",
            newAssertion: "actual.Should().NotBeApproximately(expected, delta{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, 0.6f{0});",
            newAssertion: "actual.Should().NotBeApproximately(expected, 0.6f{0});")]
        [Implemented]
        public void AssertFloatAreNotEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("float actual, float expected, float delta", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual{0});")]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, false{0});")]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, true{0});")]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, false, System.Globalization.CultureInfo.CurrentCulture{0});")]
        [AssertionDiagnostic("Assert.AreNotEqual(expected, actual, true, System.Globalization.CultureInfo.CurrentCulture{0});")]
        [Implemented]
        public void AssertStringAreNotEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("string actual, string expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual{0});",
            newAssertion: "actual.Should().NotBe(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, false{0});",
            newAssertion: "actual.Should().NotBe(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, true{0});",
            newAssertion: "actual.Should().NotBeEquivalentTo(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, false, System.Globalization.CultureInfo.CurrentCulture{0});",
            newAssertion: "actual.Should().NotBe(expected{0});")]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotEqual(expected, actual, true, System.Globalization.CultureInfo.CurrentCulture{0});",
            newAssertion: "actual.Should().NotBeEquivalentTo(expected{0});")]
        [Implemented]
        public void AssertStringAreNotEqual_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("string actual, string expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreSame(expected, actual{0});")]
        [Implemented]
        public void AssertAreSame_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("object actual, object expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreSame(expected, actual{0});",
            newAssertion: "actual.Should().BeSameAs(expected{0});")]
        [Implemented]
        public void AssertAreSame_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("object actual, object expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.AreNotSame(expected, actual{0});")]
        [Implemented]
        public void AssertAreNotSame_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("object actual, object expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.AreNotSame(expected, actual{0});",
            newAssertion: "actual.Should().NotBeSameAs(expected{0});")]
        [Implemented]
        public void AssertAreNotSame_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("object actual, object expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.ThrowsException<ArgumentException>(action{0});")]
        [Implemented]
        public void AssertThrowsException_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("Action action", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.ThrowsException<ArgumentException>(action{0});",
            newAssertion: "action.Should().ThrowExactly<ArgumentException>({0});")]
        [Implemented]
        public void AssertThrowsException_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("Action action", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("Assert.ThrowsExceptionAsync<ArgumentException>(action{0});")]
        [Implemented]
        public void AssertThrowsExceptionAsync_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<AssertAnalyzer>("Func<Task> action", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "Assert.ThrowsExceptionAsync<ArgumentException>(action{0});",
            newAssertion: "action.Should().ThrowExactlyAsync<ArgumentException>({0});")]
        [Implemented]
        public void AssertThrowsExceptionAsync_TestCodeFix(string oldAssertion, string newAssertion)
            => VerifyCSharpFix<MsTestCodeFixProvider, AssertAnalyzer>("Func<Task> action", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("CollectionAssert.AllItemsAreInstancesOfType(actual, type{0});")]
        [AssertionDiagnostic("CollectionAssert.AllItemsAreInstancesOfType(actual, typeof(int){0});")]
        [AssertionDiagnostic("CollectionAssert.AllItemsAreInstancesOfType(actual, typeof(Int32){0});")]
        [AssertionDiagnostic("CollectionAssert.AllItemsAreInstancesOfType(actual, typeof(System.Int32){0});")]
        [Implemented]
        public void CollectionAssertAllItemsAreInstancesOfType_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionAssertAllItemsAreInstancesOfTypeAnalyzer>("System.Collections.Generic.List<int> actual, Type type", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.AllItemsAreInstancesOfType(actual, type{0});",
            newAssertion: "actual.Should().AllBeOfType(type{0});")]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.AllItemsAreInstancesOfType(actual, typeof(int){0});",
            newAssertion: "actual.Should().AllBeOfType<int>({0});")]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.AllItemsAreInstancesOfType(actual, typeof(Int32){0});",
            newAssertion: "actual.Should().AllBeOfType<Int32>({0});")]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.AllItemsAreInstancesOfType(actual, typeof(System.Int32){0});",
            newAssertion: "actual.Should().AllBeOfType<System.Int32>({0});")]
        [Implemented]
        public void CollectionAssertAllItemsAreInstancesOfType_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionAssertAllItemsAreInstancesOfTypeCodeFix, CollectionAssertAllItemsAreInstancesOfTypeAnalyzer>("System.Collections.Generic.List<int> actual, Type type", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("CollectionAssert.AreEqual(expected, actual{0});")]
        [Implemented]
        public void CollectionAssertAreEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionAssertAreEqualAnalyzer>("System.Collections.Generic.List<int> actual, System.Collections.Generic.List<int> expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.AreEqual(expected, actual{0});",
            newAssertion: "actual.Should().Equal(expected{0});")]
        [Implemented]
        public void CollectionAssertAreEqual_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionAssertAreEqualCodeFix, CollectionAssertAreEqualAnalyzer>("System.Collections.Generic.List<int> actual, System.Collections.Generic.List<int> expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("CollectionAssert.AreNotEqual(expected, actual{0});")]
        [Implemented]
        public void CollectionAssertAreNotEqual_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionAssertAreNotEqualAnalyzer>("System.Collections.Generic.List<int> actual, System.Collections.Generic.List<int> expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.AreNotEqual(expected, actual{0});",
            newAssertion: "actual.Should().NotEqual(expected{0});")]
        [Implemented]
        public void CollectionAssertAreNotEqual_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionAssertAreNotEqualCodeFix, CollectionAssertAreNotEqualAnalyzer>("System.Collections.Generic.List<int> actual, System.Collections.Generic.List<int> expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("CollectionAssert.AreEquivalent(expected, actual{0});")]
        [Implemented]
        public void CollectionAssertAreEquivalent_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionAssertAreEquivalentAnalyzer>("System.Collections.Generic.List<int> actual, System.Collections.Generic.List<int> expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.AreEquivalent(expected, actual{0});",
            newAssertion: "actual.Should().BeEquivalentTo(expected{0});")]
        [Implemented]
        public void CollectionAssertAreEquivalent_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionAssertAreEquivalentCodeFix, CollectionAssertAreEquivalentAnalyzer>("System.Collections.Generic.List<int> actual, System.Collections.Generic.List<int> expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("CollectionAssert.AreNotEquivalent(expected, actual{0});")]
        [Implemented]
        public void CollectionAssertAreNotEquivalent_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionAssertAreNotEquivalentAnalyzer>("System.Collections.Generic.List<int> actual, System.Collections.Generic.List<int> expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.AreNotEquivalent(expected, actual{0});",
            newAssertion: "actual.Should().NotBeEquivalentTo(expected{0});")]
        [Implemented]
        public void CollectionAssertAreNotEquivalent_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionAssertAreNotEquivalentCodeFix, CollectionAssertAreNotEquivalentAnalyzer>("System.Collections.Generic.List<int> actual, System.Collections.Generic.List<int> expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("CollectionAssert.AllItemsAreNotNull(actual{0});")]
        [Implemented]
        public void CollectionAssertAllItemsAreNotNull_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionAssertAllItemsAreNotNullAnalyzer>("System.Collections.Generic.List<int> actual", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.AllItemsAreNotNull(actual{0});",
            newAssertion: "actual.Should().NotContainNulls({0});")]
        [Implemented]
        public void CollectionAssertAllItemsAreNotNull_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionAssertAllItemsAreNotNullCodeFix, CollectionAssertAllItemsAreNotNullAnalyzer>("System.Collections.Generic.List<int> actual", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("CollectionAssert.AllItemsAreUnique(actual{0});")]
        [Implemented]
        public void CollectionAssertAllItemsAreUnique_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionAssertAllItemsAreUniqueAnalyzer>("System.Collections.Generic.List<int> actual", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.AllItemsAreUnique(actual{0});",
            newAssertion: "actual.Should().OnlyHaveUniqueItems({0});")]
        [Implemented]
        public void CollectionAssertAllItemsAreUnique_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionAssertAllItemsAreUniqueCodeFix, CollectionAssertAllItemsAreUniqueAnalyzer>("System.Collections.Generic.List<int> actual", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("CollectionAssert.Contains(actual, expected{0});")]
        [Implemented]
        public void CollectionAssertContains_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionAssertContainsAnalyzer>("System.Collections.Generic.List<int> actual, int expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.Contains(actual, expected{0});",
            newAssertion: "actual.Should().Contain(expected{0});")]
        [Implemented]
        public void CollectionAssertContains_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionAssertContainsCodeFix, CollectionAssertContainsAnalyzer>("System.Collections.Generic.List<int> actual, int expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("CollectionAssert.DoesNotContain(actual, expected{0});")]
        [Implemented]
        public void CollectionAssertDoesNotContain_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionAssertDoesNotContainAnalyzer>("System.Collections.Generic.List<int> actual, int expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.DoesNotContain(actual, expected{0});",
            newAssertion: "actual.Should().NotContain(expected{0});")]
        [Implemented]
        public void CollectionAssertDoesNotContain_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionAssertDoesNotContainCodeFix, CollectionAssertDoesNotContainAnalyzer>("System.Collections.Generic.List<int> actual, int expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("CollectionAssert.IsSubsetOf(expected, actual{0});")]
        [Implemented]
        public void CollectionAssertIsSubsetOf_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionAssertIsSubsetOfAnalyzer>("System.Collections.Generic.List<int> actual, System.Collections.Generic.List<int> expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.IsSubsetOf(expected, actual{0});",
            newAssertion: "actual.Should().BeSubsetOf(expected{0});")]
        [Implemented]
        public void CollectionAssertIsSubsetOf_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionAssertIsSubsetOfCodeFix, CollectionAssertIsSubsetOfAnalyzer>("System.Collections.Generic.List<int> actual, System.Collections.Generic.List<int> expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("CollectionAssert.IsNotSubsetOf(expected, actual{0});")]
        [Implemented]
        public void CollectionAssertIsNotSubsetOf_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<CollectionAssertIsNotSubsetOfAnalyzer>("System.Collections.Generic.List<int> actual, System.Collections.Generic.List<int> expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "CollectionAssert.IsNotSubsetOf(expected, actual{0});",
            newAssertion: "actual.Should().NotBeSubsetOf(expected{0});")]
        [Implemented]
        public void CollectionAssertIsNotSubsetOf_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<CollectionAssertIsNotSubsetOfCodeFix, CollectionAssertIsNotSubsetOfAnalyzer>("System.Collections.Generic.List<int> actual, System.Collections.Generic.List<int> expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("StringAssert.Contains(expected, actual{0});")]
        [Implemented]
        public void StringAssertContains_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<StringAssertContainsAnalyzer>("string actual, string expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "StringAssert.Contains(expected, actual{0});",
            newAssertion: "actual.Should().Contain(expected{0});")]
        [Implemented]
        public void StringAssertContains_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<StringAssertContainsCodeFix, StringAssertContainsAnalyzer>("string actual, string expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("StringAssert.StartsWith(expected, actual{0});")]
        [Implemented]
        public void StringAssertStartsWith_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<StringAssertStartsWithAnalyzer>("string actual, string expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "StringAssert.StartsWith(expected, actual{0});",
            newAssertion: "actual.Should().StartWith(expected{0});")]
        [Implemented]
        public void StringAssertStartsWith_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<StringAssertStartsWithCodeFix, StringAssertStartsWithAnalyzer>("string actual, string expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("StringAssert.EndsWith(expected, actual{0});")]
        [Implemented]
        public void StringAssertEndsWith_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<StringAssertEndsWithAnalyzer>("string actual, string expected", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "StringAssert.EndsWith(expected, actual{0});",
            newAssertion: "actual.Should().EndWith(expected{0});")]
        [Implemented]
        public void StringAssertEndsWith_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<StringAssertEndsWithCodeFix, StringAssertEndsWithAnalyzer>("string actual, string expected", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("StringAssert.Matches(actual, pattern{0});")]
        [Implemented]
        public void StringAssertMatches_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<StringAssertMatchesAnalyzer>("string actual, System.Text.RegularExpressions.Regex pattern", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "StringAssert.Matches(actual, pattern{0});",
            newAssertion: "actual.Should().MatchRegex(pattern{0});")]
        [Implemented]
        public void StringAssertMatches_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<StringAssertMatchesCodeFix, StringAssertMatchesAnalyzer>("string actual, System.Text.RegularExpressions.Regex pattern", oldAssertion, newAssertion);

        [DataTestMethod]
        [AssertionDiagnostic("StringAssert.DoesNotMatch(actual, pattern{0});")]
        [Implemented]
        public void StringAssertDoesNotMatch_TestAnalyzer(string assertion) => VerifyCSharpDiagnostic<StringAssertDoesNotMatchAnalyzer>("string actual, System.Text.RegularExpressions.Regex pattern", assertion);

        [DataTestMethod]
        [AssertionCodeFix(
            oldAssertion: "StringAssert.DoesNotMatch(actual, pattern{0});",
            newAssertion: "actual.Should().NotMatchRegex(pattern{0});")]
        [Implemented]
        public void StringAssertDoesNotMatch_TestCodeFix(string oldAssertion, string newAssertion) => VerifyCSharpFix<StringAssertDoesNotMatchCodeFix, StringAssertDoesNotMatchAnalyzer>("string actual, System.Text.RegularExpressions.Regex pattern", oldAssertion, newAssertion);

        private void VerifyCSharpDiagnostic<TDiagnosticAnalyzer>(string source) where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var type = typeof(TDiagnosticAnalyzer);
            var diagnosticId = type.GetField("DiagnosticId")?.GetValue(null)?.ToString() ?? AssertAnalyzer.MSTestsRule.Id;
            var message = type.GetField("Message")?.GetValue(null)?.ToString() ?? AssertAnalyzer.Message;

            DiagnosticVerifier.VerifyDiagnostic(new DiagnosticVerifierArguments()
                .WithAllAnalyzers()
                .WithSources(source)
                .WithPackageReferences(PackageReference.FluentAssertions_6_12_0, PackageReference.MSTestTestFramework_3_1_1)
                .WithExpectedDiagnostics(new DiagnosticResult
                {
                    Id = diagnosticId,
                    Message = message,
                    Locations = new DiagnosticResultLocation[]
                    {
                        new DiagnosticResultLocation("Test0.cs", 12, 13)
                    },
                    Severity = DiagnosticSeverity.Info
                })
            );
        }
        private void VerifyCSharpDiagnostic<TDiagnosticAnalyzer>(string methodArguments, string assertion) where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
            => VerifyCSharpDiagnostic<TDiagnosticAnalyzer>(GenerateCode.MsTestAssertion(methodArguments, assertion));

        private void VerifyCSharpFix<TCodeFixProvider, TDiagnosticAnalyzer>(string methodArguments, string oldAssertion, string newAssertion)
            where TCodeFixProvider : Microsoft.CodeAnalysis.CodeFixes.CodeFixProvider, new()
            where TDiagnosticAnalyzer : Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer, new()
        {
            var oldSource = GenerateCode.MsTestAssertion(methodArguments, oldAssertion);
            var newSource = GenerateCode.MsTestAssertion(methodArguments, newAssertion);

            DiagnosticVerifier.VerifyFix(new CodeFixVerifierArguments()
                .WithCodeFixProvider<TCodeFixProvider>()
                .WithDiagnosticAnalyzer<TDiagnosticAnalyzer>()
                .WithSources(oldSource)
                .WithFixedSources(newSource)
                .WithPackageReferences(PackageReference.FluentAssertions_6_12_0, PackageReference.MSTestTestFramework_3_1_1)
            );
        }
    }
}
