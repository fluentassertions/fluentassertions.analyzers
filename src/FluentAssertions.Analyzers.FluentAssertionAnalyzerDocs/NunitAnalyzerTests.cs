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

    [TestMethod]
    public void AssertNull()
    {
        // arrange
        object obj = null;

        // old assertion:
        Assert.IsNull(obj);
        Assert.Null(obj);

        // new assertion:
        obj.Should().BeNull();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertNull_Failure_OldAssertion_0()
    {
        // arrange
        object obj = "foo";

        // old assertion:
        Assert.Null(obj);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertNull_Failure_OldAssertion_1()
    {
        // arrange
        object obj = "foo";

        // old assertion:
        Assert.IsNull(obj);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertNull_Failure_NewAssertion()
    {
        // arrange
        object obj = "foo";

        // new assertion:
        obj.Should().BeNull();
    }

    [TestMethod]
    public void AssertNotNull()
    {
        // arrange
        object obj = "foo";

        // old assertion:
        Assert.IsNotNull(obj);
        Assert.NotNull(obj);

        // new assertion:
        obj.Should().NotBeNull();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertNotNull_Failure_OldAssertion_0()
    {
        // arrange
        object obj = null;

        // old assertion:
        Assert.NotNull(obj);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertNotNull_Failure_OldAssertion_1()
    {
        // arrange
        object obj = null;

        // old assertion:
        Assert.IsNotNull(obj);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertNotNull_Failure_NewAssertion()
    {
        // arrange
        object obj = null;

        // new assertion:
        obj.Should().NotBeNull();
    }
}
