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
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            var diagnosticAttributes = testMethod.GetAttributes<AssertionDiagnosticAttribute>(false);
            var codeFixAttributes = testMethod.GetAttributes<AssertionCodeFixAttribute>(false);

            var results = new TestResult[diagnosticAttributes.Length + codeFixAttributes.Length];
            for (int i = 0; i < diagnosticAttributes.Length; i++)
            {
                var assertion = diagnosticAttributes[i].Assertion;

                var result = testMethod.Invoke(new[] { assertion });
                result.DisplayName = $"{testMethod.TestMethodName}(assertion: \"{assertion}\")";

                results[i] = result;
            }
            for (int i = 0; i < codeFixAttributes.Length; i++)
            {
                var oldAssertion = codeFixAttributes[i].OldAssertion;
                var newAssertion = codeFixAttributes[i].NewAssertion;

                var result = testMethod.Invoke(new[] { oldAssertion, newAssertion });
                result.DisplayName = $"{testMethod.TestMethodName}({Environment.NewLine}old: \"{oldAssertion}\" {Environment.NewLine}new: \"{newAssertion}\")";

                results[i + diagnosticAttributes.Length] = result;
            }
            return results;
        }
    }
}
