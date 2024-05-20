using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;
using System.Collections.Generic;
using NUnit.Framework;
using FluentAssertions;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

[TestClass]
public class Nunit3AnalyzerTests
{
    [TestMethod]
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

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsTrue_Failure_OldAssertion_0()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.True(flag);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsTrue_Failure_OldAssertion_1()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.IsTrue(flag);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsTrue_Failure_OldAssertion_2()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.That(flag);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsTrue_Failure_OldAssertion_3()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.That(flag, Is.True);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsTrue_Failure_OldAssertion_4()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.That(flag, Is.Not.False);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsTrue_Failure_NewAssertion()
    {
        // arrange
        var flag = false;

        // new assertion:
        flag.Should().BeTrue();
    }

    [TestMethod]
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

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsFalse_Failure_OldAssertion_0()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.False(flag);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsFalse_Failure_OldAssertion_1()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.IsFalse(flag);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsFalse_Failure_OldAssertion_2()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.That(flag, Is.False);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsFalse_Failure_OldAssertion_3()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.That(flag, Is.Not.True);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsFalse_Failure_NewAssertion()
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
        Assert.That(obj, Is.Null);

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
    public void AssertNull_Failure_OldAssertion_2()
    {
        // arrange
        object obj = "foo";

        // old assertion:
        Assert.That(obj, Is.Null);
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
        Assert.That(obj, Is.Not.Null);

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
    public void AssertNotNull_Failure_OldAssertion_2()
    {
        // arrange
        object obj = null;

        // old assertion:
        Assert.That(obj, Is.Not.Null);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertNotNull_Failure_NewAssertion()
    {
        // arrange
        object obj = null;

        // new assertion:
        obj.Should().NotBeNull();
    }

    [TestMethod]
    public void AssertIsEmpty()
    {
        // arrange
        var collection = new List<int>();

        // old assertion:
        Assert.IsEmpty(collection);
        Assert.That(collection, Is.Empty);
        CollectionAssert.IsEmpty(collection);

        // new assertion:
        collection.Should().BeEmpty();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsEmpty_Failure_OldAssertion_0()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        Assert.IsEmpty(collection);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsEmpty_Failure_OldAssertion_1()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        Assert.That(collection, Is.Empty);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsEmpty_Failure_OldAssertion_2()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        CollectionAssert.IsEmpty(collection);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsEmpty_Failure_NewAssertion()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // new assertion:
        collection.Should().BeEmpty();
    }

    [TestMethod]
    public void AssertIsNotEmpty()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        Assert.IsNotEmpty(collection);
        Assert.That(collection, Is.Not.Empty);
        CollectionAssert.IsNotEmpty(collection);

        // new assertion:
        collection.Should().NotBeEmpty();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsNotEmpty_Failure_OldAssertion_0()
    {
        // arrange
        var collection = new List<int>();

        // old assertion:
        Assert.IsNotEmpty(collection);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsNotEmpty_Failure_OldAssertion_1()
    {
        // arrange
        var collection = new List<int>();

        // old assertion:
        Assert.That(collection, Is.Not.Empty);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsNotEmpty_Failure_OldAssertion_2()
    {
        // arrange
        var collection = new List<int>();

        // old assertion:
        CollectionAssert.IsNotEmpty(collection);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertIsNotEmpty_Failure_NewAssertion()
    {
        // arrange
        var collection = new List<int>();

        // new assertion:
        collection.Should().NotBeEmpty();
    }

    [TestMethod]
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

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertZero_Failure_OldAssertion_0()
    {
        // arrange
        var number = 1;

        // old assertion:
        Assert.Zero(number);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertZero_Failure_OldAssertion_1()
    {
        // arrange
        var number = 1;

        // old assertion:
        Assert.That(number, Is.Zero);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertZero_Failure_NewAssertion()
    {
        // arrange
        var number = 1;

        // new assertion:
        number.Should().Be(0);
    }

    [TestMethod]
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

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertNotZero_Failure_OldAssertion_0()
    {
        // arrange
        var number = 0;

        // old assertion:
        Assert.NotZero(number);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertNotZero_Failure_OldAssertion_1()
    {
        // arrange
        var number = 0;

        // old assertion:
        Assert.That(number, Is.Not.Zero);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertNotZero_Failure_NewAssertion()
    {
        // arrange
        var number = 0;

        // new assertion:
        number.Should().NotBe(0);
    }

    [TestMethod]
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

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertAreSame_Failure_OldAssertion()
    {
        // arrange
        object obj1 = 6;
        object obj2 = "foo";

        // old assertion:
        Assert.AreSame(obj1, obj2);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertAreSame_Failure_NewAssertion()
    {
        // arrange
        object obj1 = 6;
        object obj2 = "foo";

        // new assertion:
        obj1.Should().BeSameAs(obj2);
    }

    [TestMethod]
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

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertAreNotSame_Failure_OldAssertion()
    {
        // arrange
        var obj1 = "foo";
        var obj2 = "foo";

        // old assertion:
        Assert.AreNotSame(obj1, obj2);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void AssertAreNotSame_Failure_NewAssertion()
    {
        // arrange
        var obj1 = "foo";
        var obj2 = "foo";

        // new assertion:
        obj1.Should().NotBeSameAs(obj2);
    }

    [TestMethod]
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

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertAreEqual_Failure_OldAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2, 4 };

        // old assertion:
        CollectionAssert.AreEqual(expected, collection);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertAreEqual_Failure_NewAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2, 4 };

        // new assertion:
        collection.Should().Equal(expected);
    }

    [TestMethod]
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

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertAreNotEqual_Failure_OldAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.AreNotEqual(expected, collection);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertAreNotEqual_Failure_NewAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2, 3 };

        // new assertion:
        collection.Should().NotEqual(expected);
    }

    [TestMethod]
    public void CollectionAssertContains()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.Contains(collection, 2);

        // new assertion:
        collection.Should().Contain(2);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertContains_Failure_OldAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.Contains(collection, 4);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertContains_Failure_NewAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };

        // new assertion:
        collection.Should().Contain(4);
    }

    [TestMethod]
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

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertContains_WithCasting_Failure_OldAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        object item = 4;

        // old assertion:
        CollectionAssert.Contains(collection, item);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertContains_WithCasting_Failure_NewAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        object item = 4;

        // new assertion:
        collection.Should().Contain((int)item);
    }

    [TestMethod]
    public void CollectionAssertDoesNotContain()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.DoesNotContain(collection, 4);

        // new assertion:
        collection.Should().NotContain(4);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertDoesNotContain_Failure_OldAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.DoesNotContain(collection, 2);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertDoesNotContain_Failure_NewAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };

        // new assertion:
        collection.Should().NotContain(2);
    }

    [TestMethod]
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

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertDoesNotContain_WithCasting_Failure_OldAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        object item = 2;

        // old assertion:
        CollectionAssert.DoesNotContain(collection, item);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertDoesNotContain_WithCasting_Failure_NewAssertion()
    {
        // arrange
        var collection = new[] { 1, 2, 3 };
        object item = 2;

        // new assertion:
        collection.Should().NotContain((int)item);
    }

    [TestMethod]
    public void CollectionAssertAllItemsAreInstancesOfType()
    {
        // arrange
        var collection = new object[] { 1, 2, 3 };

        // old assertion:
        CollectionAssert.AllItemsAreInstancesOfType(collection, typeof(int));

        // new assertion:
        collection.Should().AllBeOfType<int>();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertAllItemsAreInstancesOfType_Failure_OldAssertion()
    {
        // arrange
        var collection = new object[] { 1, 2, "3" };

        // old assertion:
        CollectionAssert.AllItemsAreInstancesOfType(collection, typeof(int));
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertAllItemsAreInstancesOfType_Failure_NewAssertion()
    {
        // arrange
        var collection = new object[] { 1, 2, "3" };

        // new assertion:
        collection.Should().AllBeOfType<int>();
    }

    [TestMethod]
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

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertAllItemsAreInstancesOfType_WithTypeArgument_Failure_OldAssertion()
    {
        // arrange
        var collection = new object[] { 1, 2, "3" };
        var type = typeof(int);

        // old assertion:
        CollectionAssert.AllItemsAreInstancesOfType(collection, type);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionAssertAllItemsAreInstancesOfType_WithTypeArgument_Failure_NewAssertion()
    {
        // arrange
        var collection = new object[] { 1, 2, "3" };
        var type = typeof(int);

        // new assertion:
        collection.Should().AllBeOfType(type);
    }
}
