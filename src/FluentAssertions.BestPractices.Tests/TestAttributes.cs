using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FluentAssertions.BestPractices.Tests
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class NotImplementedAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "NotImplemented" };
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ImplementedAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[] { "Completed" };
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AssertionAttribute : TestCategoryBaseAttribute
    {
        public string Assertion { get; }

        public string OldAssertion { get; }
        public string NewAssertion { get; }

        public override IList<string> TestCategories { get; }

        public AssertionAttribute(string assertion)
        {
            Assertion = assertion;

            TestCategories = new[] { Assertion };
        }
        public AssertionAttribute(string oldAssertion, string newAssertion)
        {
            OldAssertion = oldAssertion;
            NewAssertion = newAssertion;

            TestCategories = new[] { $"old: {OldAssertion} new: {NewAssertion}" };
        }
    }
}
