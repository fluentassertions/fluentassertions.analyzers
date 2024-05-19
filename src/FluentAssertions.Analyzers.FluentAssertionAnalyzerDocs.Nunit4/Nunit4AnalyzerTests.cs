using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

public class Nunit4AnalyzerTests
{
    [Test]
    public void BooleanAssertIsTrue()
    {
        // arrange
        var flag = true;

        // old assertion:
        ClassicAssert.IsTrue(flag);
        ClassicAssert.True(flag);
        Assert.That(flag);
        Assert.That(flag, Is.True);
        Assert.That(flag, Is.Not.False);

        // new assertion:
        flag.Should().BeTrue();
    }

    [Test, ExpectedAssertionException]
    public void BooleanAssertIsTrue_Failure_OldAssertion_0()
    {
        // arrange
        var flag = false;

        // old assertion:
        ClassicAssert.True(flag);
    }

    [Test, ExpectedAssertionException]
    public void BooleanAssertIsTrue_Failure_OldAssertion_1()
    {
        // arrange
        var flag = false;

        // old assertion:
        ClassicAssert.IsTrue(flag);
    }

    [Test, ExpectedAssertionException]
    public void BooleanAssertIsTrue_Failure_OldAssertion_2()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.That(flag);
    }

    [Test, ExpectedAssertionException]
    public void BooleanAssertIsTrue_Failure_OldAssertion_3()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.That(flag, Is.True);
    }

    [Test, ExpectedAssertionException]
    public void BooleanAssertIsTrue_Failure_OldAssertion_4()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.That(flag, Is.Not.False);
    }

    [Test, ExpectedAssertionException]
    public void BooleanAssertIsTrue_Failure_NewAssertion()
    {
        // arrange
        var flag = false;

        // new assertion:
        flag.Should().BeTrue();
    }
}