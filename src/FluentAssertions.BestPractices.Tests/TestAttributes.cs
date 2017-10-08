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
}
