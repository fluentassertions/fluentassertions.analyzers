using System.Collections.Generic;
using NUnit.Framework;
using FluentAssertions;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

public class Nunit3AnalyzerTests
{
    [Test]
    public void AssertIsTrue()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.IsTrue(flag);
        Assert.True(flag);
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
        Assert.True(flag);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsTrue_Failure_OldAssertion_1()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.IsTrue(flag);
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
        Assert.IsFalse(flag);
        Assert.False(flag);
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
        Assert.False(flag);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsFalse_Failure_OldAssertion_1()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.IsFalse(flag);
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
        Assert.IsNull(obj);
        Assert.Null(obj);
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
        Assert.Null(obj);
    }

    [Test, ExpectedAssertionException]
    public void AssertNull_Failure_OldAssertion_1()
    {
        // arrange
        object obj = "foo";

        // old assertion:
        Assert.IsNull(obj);
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
        Assert.IsNotNull(obj);
        Assert.NotNull(obj);
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
        Assert.NotNull(obj);
    }

    [Test, ExpectedAssertionException]
    public void AssertNotNull_Failure_OldAssertion_1()
    {
        // arrange
        object obj = null;

        // old assertion:
        Assert.IsNotNull(obj);
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
        Assert.IsEmpty(collection);
        Assert.That(collection, Is.Empty);
        Assert.That(collection, Has.Count.EqualTo(0));
        Assert.That(collection, Has.Count.Zero);
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
        Assert.IsEmpty(collection);
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
        Assert.That(collection, Has.Count.EqualTo(0));
    }

    [Test, ExpectedAssertionException]
    public void AssertIsEmpty_Failure_OldAssertion_3()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        Assert.That(collection, Has.Count.Zero);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsEmpty_Failure_OldAssertion_4()
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
        Assert.IsNotEmpty(collection);
        Assert.That(collection, Is.Not.Empty);
        Assert.That(collection, Has.Count.GreaterThan(0));
        Assert.That(collection, Has.Count.Not.Zero);
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
        Assert.IsNotEmpty(collection);
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
        Assert.That(collection, Has.Count.GreaterThan(0));
    }

    [Test, ExpectedAssertionException]
    public void AssertIsNotEmpty_Failure_OldAssertion_3()
    {
        // arrange
        var collection = new List<int>();

        // old assertion:
        Assert.That(collection, Has.Count.Not.Zero);
    }

    [Test, ExpectedAssertionException]
    public void AssertIsNotEmpty_Failure_OldAssertion_4()
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
        Assert.Zero(number);
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
        Assert.Zero(number);
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
        Assert.NotZero(number);
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
        Assert.NotZero(number);
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
    public void AssertAreSame()
    {
        // arrange
        var obj1 = new object();
        var obj2 = obj1;

        // old assertion:
        Assert.AreSame(obj1, obj2);

        // new assertion:
        obj1.Should().BeSameAs(obj2);
    }

    [Test, ExpectedAssertionException]
    public void AssertAreSame_Failure_OldAssertion()
    {
        // arrange
        object obj1 = 6;
        object obj2 = "foo";

        // old assertion:
        Assert.AreSame(obj1, obj2);
    }

    [Test, ExpectedAssertionException]
    public void AssertAreSame_Failure_NewAssertion()
    {
        // arrange
        object obj1 = 6;
        object obj2 = "foo";

        // new assertion:
        obj1.Should().BeSameAs(obj2);
    }

    [Test]
    public void AssertAreNotSame()
    {
        // arrange
        object obj1 = 6;
        object obj2 = "foo";

        // old assertion:
        Assert.AreNotSame(obj1, obj2);

        // new assertion:
        obj1.Should().NotBeSameAs(obj2);
    }

    [Test, ExpectedAssertionException]
    public void AssertAreNotSame_Failure_OldAssertion()
    {
        // arrange
        var obj1 = "foo";
        var obj2 = "foo";

        // old assertion:
        Assert.AreNotSame(obj1, obj2);
    }

    [Test, ExpectedAssertionException]
    public void AssertAreNotSame_Failure_NewAssertion()
    {
        // arrange
        var obj1 = "foo";
        var obj2 = "foo";

        // new assertion:
        obj1.Should().NotBeSameAs(obj2);
    }

    [Test]
    public void CollectionAssertAreEqual()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2, 3 };

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

    [Test]
    public void CollectionAssertContains()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.Contains(collection, 2);

        // new assertion:
        collection.Should().Contain(2);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertContains_Failure_OldAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.Contains(collection, 4);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertContains_Failure_NewAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };

        // new assertion:
        collection.Should().Contain(4);
    }

    [Test]
    public void CollectionAssertContains_WithCasting()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        object item = 2;

        // old assertion:
        CollectionAssert.Contains(collection, item);

        // new assertion:
        collection.Should().Contain((int)item);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertContains_WithCasting_Failure_OldAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        object item = 4;

        // old assertion:
        CollectionAssert.Contains(collection, item);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertContains_WithCasting_Failure_NewAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        object item = 4;

        // new assertion:
        collection.Should().Contain((int)item);
    }

    [Test]
    public void CollectionAssertDoesNotContain()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.DoesNotContain(collection, 4);

        // new assertion:
        collection.Should().NotContain(4);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertDoesNotContain_Failure_OldAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.DoesNotContain(collection, 2);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertDoesNotContain_Failure_NewAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };

        // new assertion:
        collection.Should().NotContain(2);
    }

    [Test]
    public void CollectionAssertDoesNotContain_WithCasting()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        object item = 4;

        // old assertion:
        CollectionAssert.DoesNotContain(collection, item);

        // new assertion:
        collection.Should().NotContain((int)item);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertDoesNotContain_WithCasting_Failure_OldAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        object item = 2;

        // old assertion:
        CollectionAssert.DoesNotContain(collection, item);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertDoesNotContain_WithCasting_Failure_NewAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        object item = 2;

        // new assertion:
        collection.Should().NotContain((int)item);
    }

    [Test]
    public void CollectionAssertAllItemsAreInstancesOfType()
    {
        // arrange
        var collection = new object[] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.AllItemsAreInstancesOfType(collection, typeof(int));

        // new assertion:
        collection.Should().AllBeOfType<int>();
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertAllItemsAreInstancesOfType_Failure_OldAssertion()
    {
        // arrange
        var collection = new object[] { 1, 2, "3" };

        // old assertion:
        CollectionAssert.AllItemsAreInstancesOfType(collection, typeof(int));
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertAllItemsAreInstancesOfType_Failure_NewAssertion()
    {
        // arrange
        var collection = new object[] { 1, 2, "3" };

        // new assertion:
        collection.Should().AllBeOfType<int>();
    }

    [Test]
    public void CollectionAssertAllItemsAreInstancesOfType_WithTypeArgument()
    {
        // arrange
        var collection = new object[] { 1, 2, 3 };
        var type = typeof(int);

        // old assertion:
        CollectionAssert.AllItemsAreInstancesOfType(collection, type);

        // new assertion:
        collection.Should().AllBeOfType(type);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertAllItemsAreInstancesOfType_WithTypeArgument_Failure_OldAssertion()
    {
        // arrange
        var collection = new object[] { 1, 2, "3" };
        var type = typeof(int);

        // old assertion:
        CollectionAssert.AllItemsAreInstancesOfType(collection, type);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertAllItemsAreInstancesOfType_WithTypeArgument_Failure_NewAssertion()
    {
        // arrange
        var collection = new object[] { 1, 2, "3" };
        var type = typeof(int);

        // new assertion:
        collection.Should().AllBeOfType(type);
    }

    [Test]
    public void CollectionAssertAllItemsAreNotNull()
    {
        // arrange
        var collection = new object[] { 1, "test", true };

        // old assertion:
        CollectionAssert.AllItemsAreNotNull(collection);

        // new assertion:
        collection.Should().NotContainNulls();
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertAllItemsAreNotNull_Failure_OldAssertion()
    {
        // arrange
        var collection = new object[] { 1, null, true };

        // old assertion:
        CollectionAssert.AllItemsAreNotNull(collection);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertAllItemsAreNotNull_Failure_NewAssertion()
    {
        // arrange
        var collection = new object[] { 1, null, true };

        // new assertion:
        collection.Should().NotContainNulls();
    }

    [Test]
    public void CollectionAssertAllItemsAreUnique()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.AllItemsAreUnique(collection);

        // new assertion:
        collection.Should().OnlyHaveUniqueItems();
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertAllItemsAreUnique_Failure_OldAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 1 };

        // old assertion:
        CollectionAssert.AllItemsAreUnique(collection);
    }

    [Test, ExpectedAssertionException]
    public void CollectionAssertAllItemsAreUnique_Failure_NewAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 1 };

        // new assertion:
        collection.Should().OnlyHaveUniqueItems();
    }
}
