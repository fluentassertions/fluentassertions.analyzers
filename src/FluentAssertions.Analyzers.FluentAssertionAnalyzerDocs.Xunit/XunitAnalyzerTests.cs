using System;
using System.Collections.Generic;
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
    public void AssertFalse_Failure_OldAssertion()
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

    [Fact]
    public void AssertSame()
    {
        // arrange
        var obj1 = new object();
        var obj2 = obj1;

        // old assertion:
        Assert.Same(obj1, obj2);

        // new assertion:
        obj1.Should().BeSameAs(obj2);
    }

    [Fact, ExpectedAssertionException]
    public void AssertSame_Failure_OldAssertion()
    {
        // arrange
        object obj1 = 6;
        object obj2 = "foo";

        // old assertion:
        Assert.Same(obj1, obj2);
    }

    [Fact, ExpectedAssertionException]
    public void AssertSame_Failure_NewAssertion()
    {
        // arrange
        object obj1 = 6;
        object obj2 = "foo";

        // new assertion:
        obj1.Should().BeSameAs(obj2);
    }

    [Fact]
    public void AssertNotSame()
    {
        // arrange
        object obj1 = 6;
        object obj2 = "foo";

        // old assertion:
        Assert.NotSame(obj1, obj2);

        // new assertion:
        obj1.Should().NotBeSameAs(obj2);
    }

    [Fact, ExpectedAssertionException]
    public void AssertNotSame_Failure_OldAssertion()
    {
        // arrange
        object obj1 = "foo";
        object obj2 = "foo";

        // old assertion:
        Assert.NotSame(obj1, obj2);
    }

    [Fact, ExpectedAssertionException]
    public void AssertNotSame_Failure_NewAssertion()
    {
        // arrange
        object obj1 = "foo";
        object obj2 = "foo";

        // new assertion:
        obj1.Should().NotBeSameAs(obj2);
    }

    [Fact]
    public void AssertDoubleEqual()
    {
        // arrange
        double actual = 3.14;
        double expected = 3.141;
        double tolerance = 0.00159;

        // old assertion:
        Assert.Equal(expected, actual, tolerance);

        // new assertion:
        actual.Should().BeApproximately(expected, tolerance);
    }

    [Fact, ExpectedAssertionException]
    public void AssertDoubleEqual_Failure_OldAssertion()
    {
        // arrange
        double actual = 3.14;
        double expected = 4.2;
        double tolerance = 0.0001;

        // old assertion:
        Assert.Equal(expected, actual, tolerance);
    }

    [Fact, ExpectedAssertionException]
    public void AssertDoubleEqual_Failure_NewAssertion()
    {
        // arrange
        double actual = 3.14;
        double expected = 4.2;
        double tolerance = 0.0001;

        // new assertion:
        actual.Should().BeApproximately(expected, tolerance);
    }

    [Fact]
    public void AssertDateTimeEqual()
    {
        // arrange
        var actual = new DateTime(2021, 1, 1);
        var expected = new DateTime(2021, 1, 2);

        // old assertion:
        Assert.Equal(expected, actual, TimeSpan.FromDays(3));

        // new assertion:
        actual.Should().BeCloseTo(expected, TimeSpan.FromDays(3));
    }

    [Fact, ExpectedAssertionException]
    public void AssertDateTimeEqual_Failure_OldAssertion()
    {
        // arrange
        var actual = new DateTime(2021, 1, 1);
        var expected = new DateTime(2021, 1, 2);

        // old assertion:
        Assert.Equal(expected, actual, TimeSpan.FromHours(3));
    }

    [Fact, ExpectedAssertionException]
    public void AssertDateTimeEqual_Failure_NewAssertion()
    {
        // arrange
        var actual = new DateTime(2021, 1, 1);
        var expected = new DateTime(2021, 1, 2);

        // new assertion:
        actual.Should().BeCloseTo(expected, TimeSpan.FromHours(3));
    }

    [Fact]
    public void AssertObjectEqual()
    {
        // arrange
        object actual = "foo";
        object expected = "foo";

        // old assertion:
        Assert.Equal(expected, actual);

        // new assertion:
        actual.Should().Be(expected);
    }

    [Fact, ExpectedAssertionException]
    public void AssertObjectEqual_Failure_OldAssertion()
    {
        // arrange
        object actual = "foo";
        object expected = 6;

        // old assertion:
        Assert.Equal(expected, actual);
    }

    [Fact, ExpectedAssertionException]
    public void AssertObjectEqual_Failure_NewAssertion()
    {
        // arrange
        object actual = "foo";
        object expected = 6;

        // new assertion:
        actual.Should().Be(expected);
    }

    [Fact]
    public void AssertObjectEqualWithComparer()
    {
        // arrange
        object actual = "foo";
        object expected = "foo";

        // old assertion:
        Assert.Equal(expected, actual, EqualityComparer<object>.Default);

        // new assertion:
        actual.Should().BeEquivalentTo(expected, options => options.Using(EqualityComparer<object>.Default));
    }

    [Fact, ExpectedAssertionException]
    public void AssertObjectEqualWithComparer_Failure_OldAssertion()
    {
        // arrange
        object actual = "foo";
        object expected = 6;

        // old assertion:
        Assert.Equal(expected, actual, EqualityComparer<object>.Default);
    }

    [Fact, ExpectedAssertionException]
    public void AssertObjectEqualWithComparer_Failure_NewAssertion()
    {
        // arrange
        object actual = "foo";
        object expected = 6;

        // new assertion:
        actual.Should().BeEquivalentTo(expected, options => options.Using(EqualityComparer<object>.Default));
    }

    [Fact]
    public void AssertObjectNotEqual()
    {
        // arrange
        object actual = "foo";
        object expected = 6;

        // old assertion:
        Assert.NotEqual(expected, actual);

        // new assertion:
        actual.Should().NotBe(expected);
    }

    [Fact, ExpectedAssertionException]
    public void AssertObjectNotEqual_Failure_OldAssertion()
    {
        // arrange
        object actual = "foo";
        object expected = "foo";

        // old assertion:
        Assert.NotEqual(expected, actual);
    }

    [Fact, ExpectedAssertionException]
    public void AssertObjectNotEqual_Failure_NewAssertion()
    {
        // arrange
        object actual = "foo";
        object expected = "foo";

        // new assertion:
        actual.Should().NotBe(expected);
    }

    [Fact]
    public void AssertObjectNotEqualWithComparer()
    {
        // arrange
        object actual = "foo";
        object expected = 6;

        // old assertion:
        Assert.NotEqual(expected, actual, EqualityComparer<object>.Default);

        // new assertion:
        actual.Should().NotBeEquivalentTo(expected, options => options.Using(EqualityComparer<object>.Default));
    }

    [Fact, ExpectedAssertionException]
    public void AssertObjectNotEqualWithComparer_Failure_OldAssertion()
    {
        // arrange
        object actual = "foo";
        object expected = "foo";

        // old assertion:
        Assert.NotEqual(expected, actual, EqualityComparer<object>.Default);
    }

    [Fact, ExpectedAssertionException]
    public void AssertObjectNotEqualWithComparer_Failure_NewAssertion()
    {
        // arrange
        object actual = "foo";
        object expected = "foo";

        // new assertion:
        actual.Should().NotBeEquivalentTo(expected, options => options.Using(EqualityComparer<object>.Default));
    }

    [Fact]
    public void AssertStrictEqual()
    {
        // arrange
        object actual = "foo";
        object expected = "foo";

        // old assertion:
        Assert.StrictEqual(expected, actual);

        // new assertion:
        actual.Should().Be(expected);
    }

    [Fact, ExpectedAssertionException]
    public void AssertStrictEqual_Failure_OldAssertion()
    {
        // arrange
        object actual = "foo";
        object expected = 6;

        // old assertion:
        Assert.StrictEqual(expected, actual);
    }

    [Fact, ExpectedAssertionException]
    public void AssertStrictEqual_Failure_NewAssertion()
    {
        // arrange
        object actual = "foo";
        object expected = 6;

        // new assertion:
        actual.Should().Be(expected);
    }

    [Fact]
    public void AssertNotStrictEqual()
    {
        // arrange
        object actual = "foo";
        object expected = 6;

        // old assertion:
        Assert.NotStrictEqual(expected, actual);

        // new assertion:
        actual.Should().NotBe(expected);
    }

    [Fact, ExpectedAssertionException]
    public void AssertNotStrictEqual_Failure_OldAssertion()
    {
        // arrange
        object actual = "foo";
        object expected = "foo";

        // old assertion:
        Assert.NotStrictEqual(expected, actual);
    }

    [Fact, ExpectedAssertionException]
    public void AssertNotStrictEqual_Failure_NewAssertion()
    {
        // arrange
        object actual = "foo";
        object expected = "foo";

        // new assertion:
        actual.Should().NotBe(expected);
    }
}
