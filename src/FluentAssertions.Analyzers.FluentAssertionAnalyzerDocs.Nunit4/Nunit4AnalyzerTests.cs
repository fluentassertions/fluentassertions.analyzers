using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

public class Nunit4AnalyzerTests
{
    [Test]
    public void AssertIsTrue()
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
    public void AssertIsTrue_Failure_OldAssertion_0()
    {
        // arrange
        var flag = false;

        // old assertion:
        ClassicAssert.True(flag);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsTrue_Failure_OldAssertion_1()
    {
        // arrange
        var flag = false;

        // old assertion:
        ClassicAssert.IsTrue(flag);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsTrue_Failure_OldAssertion_2()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.That(flag);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsTrue_Failure_OldAssertion_3()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.That(flag, Is.True);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsTrue_Failure_OldAssertion_4()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.That(flag, Is.Not.False);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsTrue_Failure_NewAssertion()
    {
        // arrange
        var flag = false;

        // new assertion:
        flag.Should().BeTrue();
    }

    [Test]
    public void AssertIsFalse()
    {
        // arrange
        var flag = false;

        // old assertion:
        ClassicAssert.IsFalse(flag);
        ClassicAssert.False(flag);
        Assert.That(flag, Is.False);
        Assert.That(flag, Is.Not.True);

        // new assertion:
        flag.Should().BeFalse();
    }

    [Test, ExpectedAssertionException]
    public void AssertIsFalse_Failure_OldAssertion_0()
    {
        // arrange
        var flag = true;

        // old assertion:
        ClassicAssert.False(flag);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsFalse_Failure_OldAssertion_1()
    {
        // arrange
        var flag = true;

        // old assertion:
        ClassicAssert.IsFalse(flag);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsFalse_Failure_OldAssertion_2()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.That(flag, Is.False);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsFalse_Failure_OldAssertion_3()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.That(flag, Is.Not.True);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsFalse_Failure_NewAssertion()
    {
        // arrange
        var flag = true;

        // new assertion:
        flag.Should().BeFalse();
    }

    [Test]
    public void AssertNull()
    {
        // arrange
        object obj = null;

        // old assertion:
        ClassicAssert.IsNull(obj);
        ClassicAssert.Null(obj);
        Assert.That(obj, Is.Null);

        // new assertion:
        obj.Should().BeNull();
    }

    [Test, ExpectedAssertionException]
    public void AssertNull_Failure_OldAssertion_0()
    {
        // arrange
        object obj = "foo";

        // old assertion:
        ClassicAssert.Null(obj);
    }

    [Test, ExpectedAssertionException]
    public void AssertNull_Failure_OldAssertion_1()
    {
        // arrange
        object obj = "foo";

        // old assertion:
        ClassicAssert.IsNull(obj);
    }

    [Test, ExpectedAssertionException]
    public void AssertNull_Failure_OldAssertion_2()
    {
        // arrange
        object obj = "foo";

        // old assertion:
        Assert.That(obj, Is.Null);
    }

    [Test, ExpectedAssertionException]
    public void AssertNull_Failure_NewAssertion()
    {
        // arrange
        object obj = "foo";

        // new assertion:
        obj.Should().BeNull();
    }

    [Test]
    public void AssertNotNull()
    {
        // arrange
        object obj = "foo";

        // old assertion:
        ClassicAssert.IsNotNull(obj);
        ClassicAssert.NotNull(obj);
        Assert.That(obj, Is.Not.Null);

        // new assertion:
        obj.Should().NotBeNull();
    }

    [Test, ExpectedAssertionException]
    public void AssertNotNull_Failure_OldAssertion_0()
    {
        // arrange
        object obj = null;

        // old assertion:
        ClassicAssert.NotNull(obj);
    }

    [Test, ExpectedAssertionException]
    public void AssertNotNull_Failure_OldAssertion_1()
    {
        // arrange
        object obj = null;

        // old assertion:
        ClassicAssert.IsNotNull(obj);
    }

    [Test, ExpectedAssertionException]
    public void AssertNotNull_Failure_OldAssertion_2()
    {
        // arrange
        object obj = null;

        // old assertion:
        Assert.That(obj, Is.Not.Null);
    }

    [Test, ExpectedAssertionException]
    public void AssertNotNull_Failure_NewAssertion()
    {
        // arrange
        object obj = null;

        // new assertion:
        obj.Should().NotBeNull();
    }

    [Test]
    public void AssertIsEmpty()
    {
        // arrange
        var collection = new List<int>();

        // old assertion:
        ClassicAssert.IsEmpty(collection);
        Assert.That(collection, Is.Empty);
        CollectionAssert.IsEmpty(collection);

        // new assertion:
        collection.Should().BeEmpty();
    }

    [Test, ExpectedAssertionException]
    public void AssertIsEmpty_Failure_OldAssertion_0()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        ClassicAssert.IsEmpty(collection);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsEmpty_Failure_OldAssertion_1()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        Assert.That(collection, Is.Empty);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsEmpty_Failure_OldAssertion_2()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        CollectionAssert.IsEmpty(collection);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsEmpty_Failure_NewAssertion()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // new assertion:
        collection.Should().BeEmpty();
    }

    [Test]
    public void AssertIsNotEmpty()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        ClassicAssert.IsNotEmpty(collection);
        Assert.That(collection, Is.Not.Empty);
        CollectionAssert.IsNotEmpty(collection);

        // new assertion:
        collection.Should().NotBeEmpty();
    }

    [Test, ExpectedAssertionException]
    public void AssertIsNotEmpty_Failure_OldAssertion_0()
    {
        // arrange
        var collection = new List<int>();

        // old assertion:
        ClassicAssert.IsNotEmpty(collection);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsNotEmpty_Failure_OldAssertion_1()
    {
        // arrange
        var collection = new List<int>();

        // old assertion:
        Assert.That(collection, Is.Not.Empty);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsNotEmpty_Failure_OldAssertion_2()
    {
        // arrange
        var collection = new List<int>();

        // old assertion:
        CollectionAssert.IsNotEmpty(collection);
}

    [Test, ExpectedAssertionException]
    public void AssertIsNotEmpty_Failure_NewAssertion()
    {
        // arrange
        var collection = new List<int>();

        // new assertion:
        collection.Should().NotBeEmpty();
    }

    [Test]
    public void AssertZero()
    {
        // arrange
        var number = 0;

        // old assertion:
        ClassicAssert.Zero(number);
        Assert.That(number, Is.Zero);

        // new assertion:
        number.Should().Be(0);
    }

    [Test, ExpectedAssertionException]
    public void AssertZero_Failure_OldAssertion_0()
    {
        // arrange
        var number = 1;

        // old assertion:
        ClassicAssert.Zero(number);
    }

    [Test, ExpectedAssertionException]
    public void AssertZero_Failure_OldAssertion_1()
    {
        // arrange
        var number = 1;

        // old assertion:
        Assert.That(number, Is.Zero);
    }

    [Test, ExpectedAssertionException]
    public void AssertZero_Failure_NewAssertion()
    {
        // arrange
        var number = 1;

        // new assertion:
        number.Should().Be(0);
    }

    [Test]
    public void AssertNotZero()
    {
        // arrange
        var number = 1;

        // old assertion:
        ClassicAssert.NotZero(number);
        Assert.That(number, Is.Not.Zero);

        // new assertion:
        number.Should().NotBe(0);
    }

    [Test, ExpectedAssertionException]
    public void AssertNotZero_Failure_OldAssertion_0()
    {
        // arrange
        var number = 0;

        // old assertion:
        ClassicAssert.NotZero(number);
    }

    [Test, ExpectedAssertionException]
    public void AssertNotZero_Failure_OldAssertion_1()
    {
        // arrange
        var number = 0;

        // old assertion:
        Assert.That(number, Is.Not.Zero);
    }

    [Test, ExpectedAssertionException]
    public void AssertNotZero_Failure_NewAssertion()
    {
        // arrange
        var number = 0;

        // new assertion:
        number.Should().NotBe(0);
    }

    [Test]
    public void CollectionAssertAreEqual()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        var expected = new [] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.AreEqual(expected, collection);

        // new assertion:
        collection.Should().Equal(expected);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertAreEqual_Failure_OldAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2, 4 };

        // old assertion:
        CollectionAssert.AreEqual(expected, collection);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertAreEqual_Failure_NewAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2, 4 };

        // new assertion:
        collection.Should().Equal(expected);
    }

    [Test]
    public void CollectionAssertAreNotEqual()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2, 4 };

        // old assertion:
        CollectionAssert.AreNotEqual(expected, collection);

        // new assertion:
        collection.Should().NotEqual(expected);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertAreNotEqual_Failure_OldAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.AreNotEqual(expected, collection);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertAreNotEqual_Failure_NewAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2, 3 };

        // new assertion:
        collection.Should().NotEqual(expected);
    }
}