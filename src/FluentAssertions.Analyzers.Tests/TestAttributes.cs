using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluentAssertions.Analyzers.Tests;

[AttributeUsage(AttributeTargets.Method)]
public class NotImplementedAttribute : TestCategoryBaseAttribute
{
    public string Reason { get; set; }

    public override IList<string> TestCategories => new[] { "NotImplemented" };
}

[AttributeUsage(AttributeTargets.Method)]
public class ImplementedAttribute : TestCategoryBaseAttribute
{
    public string Reason { get; set; }

    public override IList<string> TestCategories => new[] { "Completed" };
}

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class AssertionDiagnosticAttribute : Attribute, ITestDataSource
{
    public string Assertion { get; }

    public bool Ignore { get; }

    public AssertionDiagnosticAttribute(string assertion, bool ignore = false) => (Assertion, Ignore) = (assertion, ignore);

    public IEnumerable<object[]> GetData(MethodInfo methodInfo)
    {
        if (Ignore) yield break;

        foreach (var assertion in TestCasesInputUtils.GetTestCases(Assertion))
        {
            yield return new object[] { assertion };
        }
    }

    public string GetDisplayName(MethodInfo methodInfo, object[] data) => $"{methodInfo.Name}(\"{data[0]}\")";
}

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class AssertionCodeFixAttribute : Attribute, ITestDataSource
{
    public string OldAssertion { get; }
    public string NewAssertion { get; }

    public bool Ignore { get; }

    public AssertionCodeFixAttribute(string oldAssertion, string newAssertion, bool ignore = false) => (OldAssertion, NewAssertion, Ignore) = (oldAssertion, newAssertion, ignore);

    public IEnumerable<object[]> GetData(MethodInfo methodInfo)
    {
        if (Ignore) yield break;

        foreach (var (oldAssertion, newAssertion) in TestCasesInputUtils.GetTestCases(OldAssertion, NewAssertion))
        {
            yield return new object[] { oldAssertion, newAssertion };
        }
    }

    public string GetDisplayName(MethodInfo methodInfo, object[] data) => $"{methodInfo.Name}(\"old: {data[0]}\", new: {data[1]}\")";
}

public static class TestCasesInputUtils
{
    private static readonly string Empty = string.Empty;
    private static readonly string Because = "\"because it's possible\"";
    private static readonly string FormattedBecause = "\"because message with {0} placeholders {1} at {2}\", 3, \"is awesome\", DateTime.Now.Add(2.Seconds())";
    public static IEnumerable<string> GetTestCases(string assertion)
    {
        if (!assertion.Contains("{0}"))
        {
            yield return assertion;
            yield break;
        }

        yield return SafeFormat(assertion, Empty);
        yield return SafeFormat(assertion, Because);
        yield return SafeFormat(assertion, FormattedBecause);
    }
    public static IEnumerable<(string oldAssertion, string newAssertion)> GetTestCases(string oldAssertion, string newAssertion)
    {
        if (!oldAssertion.Contains("{0}") && !newAssertion.Contains("{0}"))
        {
            yield return (oldAssertion, newAssertion);
            yield break;
        }

        yield return (SafeFormat(oldAssertion, Empty), SafeFormat(newAssertion, Empty));
        yield return (SafeFormat(oldAssertion, Because), SafeFormat(newAssertion, Because));
        yield return (SafeFormat(oldAssertion, FormattedBecause), SafeFormat(newAssertion, FormattedBecause));
    }

    /// <summary>
    /// Adds an comma before the additional argument if needed.
    /// </summary>
    private static string SafeFormat(string assertion, string arg)
    {
        var index = assertion.IndexOf("{0}");
        if (!string.IsNullOrEmpty(arg) && assertion[index - 1] != '(')
        {
            return string.Format(assertion, ", " + arg);
        }
        return string.Format(assertion, arg);
    }
}
