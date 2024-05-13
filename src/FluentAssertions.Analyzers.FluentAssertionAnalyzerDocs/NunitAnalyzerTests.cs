using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using FluentAssertions;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

[TestClass]
public class NunitAnalyzerTests
{
    [TestMethod]
    public void BooleanAssertIsTrue()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.IsTrue(flag);
        Assert.True(flag);

        // new assertion:
        flag.Should().BeTrue();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void BooleanAssertIsTrue_Failure_OldAssertion_0()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.True(flag);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void BooleanAssertIsTrue_Failure_OldAssertion_1()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.IsTrue(flag);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void BooleanAssertIsTrue_Failure_NewAssertion()
    {
        // arrange
        var flag = false;

        // new assertion:
        flag.Should().BeTrue();
    }

    [TestMethod]
    public void BooleanAssertIsFalse()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.IsFalse(flag);
        Assert.False(flag);

        // new assertion:
        flag.Should().BeFalse();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void BooleanAssertIsFalse_Failure_OldAssertion_0()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.False(flag);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void BooleanAssertIsFalse_Failure_OldAssertion_1()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.IsFalse(flag);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void BooleanAssertIsFalse_Failure_NewAssertion()
    {
        // arrange
        var flag = true;

        // new assertion:
        flag.Should().BeFalse();
    }
}
