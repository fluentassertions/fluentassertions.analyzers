using FluentAssertions;
using Xunit;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

public class XunitAnalyzerTests
{
    [Fact]
    public void AssertTrue()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.True(flag);

        // new assertion:
        flag.Should().BeTrue();
    }

    [Fact, ExpectedAssertionException]
    public void AssertTrue_Failure_OldAssertion()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.True(flag);
    }

    [Fact, ExpectedAssertionException]
    public void AssertTrue_Failure_NewAssertion()
    {
        // arrange
        var flag = false;

        // new assertion:
        flag.Should().BeTrue();
    }

    [Fact]
    public void AssertFalse()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.False(flag);

        // new assertion:
        flag.Should().BeFalse();
    }

    [Fact, ExpectedAssertionException]
    public void AssertFalse_Failure_OldAssertion_0()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.False(flag);
    }

    [Fact, ExpectedAssertionException]
    public void AssertFalse_Failure_NewAssertion()
    {
        // arrange
        var flag = true;

        // new assertion:
        flag.Should().BeFalse();
    }
}
