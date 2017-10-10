using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FluentAssertions.BestPractices.Tests
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NotImplementedAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "NotImplemented" };
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ImplementedAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Completed" };
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AssertionDiagnosticAttribute : Attribute
    {
        public string Assertion { get; }

        public AssertionDiagnosticAttribute(string assertion)
        {
            Assertion = assertion;
        }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AssertionCodeFixAttribute : Attribute
    {
        public string OldAssertion { get; }
        public string NewAssertion { get; }

        public AssertionCodeFixAttribute(string oldAssertion, string newAssertion)
        {
            OldAssertion = oldAssertion;
            NewAssertion = newAssertion;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class AssertionDataTestMethod : TestMethodAttribute
    {
        private static readonly string Empty = string.Empty;
        private static readonly string Because = "\"because it's possible\"";
        private static readonly string FormattedBecause = "\"because message with {0} placeholders {1} at {2}\", 3, \"is awesome\", DateTime.Now.Add(2.Seconds())";

        public override TestResult[] Execute(ITestMethod testMethod)
        {
            var diagnosticAttributes = testMethod.GetAttributes<AssertionDiagnosticAttribute>(false);
            var codeFixAttributes = testMethod.GetAttributes<AssertionCodeFixAttribute>(false);

            var results = new List<TestResult>();
            for (int i = 0; i < diagnosticAttributes.Length; i++)
            {
                foreach (var assertion in GetTestCases(diagnosticAttributes[i]))
                {
                    var result = testMethod.Invoke(new[] { assertion });
                    result.DisplayName = assertion;

                    results.Add(result);
                }
            }
            for (int i = 0; i < codeFixAttributes.Length; i++)
            {
                foreach (var (oldAssertion, newAssertion) in GetTestCases(codeFixAttributes[i]))
                {
                    var result = testMethod.Invoke(new[] { oldAssertion, newAssertion });
                    result.DisplayName = $"{Environment.NewLine}old: \"{oldAssertion}\" {Environment.NewLine}new: \"{newAssertion}\"";

                    results.Add(result);
                }
            }

            return results.ToArray();
        }

        private IEnumerable<string> GetTestCases(AssertionDiagnosticAttribute attribute)
        {
            yield return SafeFormat(attribute.Assertion, Empty);
            yield return SafeFormat(attribute.Assertion, Because);
            yield return SafeFormat(attribute.Assertion, FormattedBecause);
        }
        private IEnumerable<(string oldAssertion, string newAssertion)> GetTestCases(AssertionCodeFixAttribute attribute)
        {
            yield return (SafeFormat(attribute.OldAssertion, Empty), SafeFormat(attribute.NewAssertion, Empty));
            yield return (SafeFormat(attribute.OldAssertion, Because), SafeFormat(attribute.NewAssertion, Because));
            yield return (SafeFormat(attribute.OldAssertion, FormattedBecause), SafeFormat(attribute.NewAssertion, FormattedBecause));
        }

        /// <summary>
        /// Adds an comma before the additional argument if needed.
        /// </summary>
        private string SafeFormat(string assertion, string arg)
        {
            var index = assertion.IndexOf("{0}");
            if (!string.IsNullOrEmpty(arg) && assertion[index - 1] != '(')
            {
                return string.Format(assertion, ", " + arg);
            }
            return string.Format(assertion, arg);
        }
    }
}
