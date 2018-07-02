using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.Tests
{
    [TestClass]
    public class AsyncVoidTests
    {
        [TestMethod]
        public void AssignAsyncVoidMethodToAction_TestAnalyzer()
        {
            const string statement = "Action action = AsyncVoidMethod;";
            var source = GenerateCode.AsyncFunctionStatement(statement);

            DiagnosticVerifier.VerifyCSharpDiagnosticUsingAllAnalyzers(source);
        }

        [TestMethod]
        public void AssignVoidLambdaToAction_TestAnalyzer()
        {
            const string statement = "Action action = () => {};";
            var source = GenerateCode.AsyncFunctionStatement(statement);

            DiagnosticVerifier.VerifyCSharpDiagnosticUsingAllAnalyzers(source);
        }

        [DataRow("Action action = async () => { await Task.CompletedTask; };")]
        [DataRow("Action action1 = async () => { await Task.CompletedTask; }, action2 = async () => { await Task.CompletedTask; };")]
        [DataRow("Action action1 = () => { }, action2 = async () => { await Task.CompletedTask; };")]
        [DataRow("Action action1 = async () => { await Task.CompletedTask; }, action2 = () => { };")]
        [DataTestMethod]
        public void AssignAsyncVoidLambdaToAction_TestAnalyzer(string assertion)
        {
            var source = GenerateCode.AsyncFunctionStatement(assertion);

            DiagnosticVerifier.VerifyCSharpDiagnosticUsingAllAnalyzers(source, new DiagnosticResult
            {
                Id = AsyncVoidAnalyzer.DiagnosticId,
                Message = AsyncVoidAnalyzer.Message,
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 10,13)
                },
                Severity = DiagnosticSeverity.Warning
            });
        }

        [DataRow(
            "Action action = async () => { await Task.CompletedTask; };",
            "Func<Task> action = async () => { await Task.CompletedTask; };")]
        [DataRow(
            "Action action1 = async () => { await Task.CompletedTask; }, action2 = async () => { await Task.CompletedTask; };",
            "Func<Task> action1 = async () => { await Task.CompletedTask; }, action2 = async () => { await Task.CompletedTask; };")]
        [DataTestMethod]
        public void AssignAsyncVoidLambdaToAction_TestCodeFix(string oldAssertion, string newAssertion)
        {

        }
    }
}
