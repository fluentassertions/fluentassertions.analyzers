using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

[TestClass]
public class MsTestAnalyzerTests
{
    [TestMethod]
    public void AssertIsTrue()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.IsTrue(flag);

        // new assertion:
        flag.Should().BeTrue();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertIsTrue_Failure_OldAssertion()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.IsTrue(flag);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
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

        // new assertion:
        flag.Should().BeFalse();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertIsFalse_Failure_OldAssertion()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.IsFalse(flag);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertIsFalse_Failure_NewAssertion()
    {
        // arrange
        var flag = true;

        // new assertion:
        flag.Should().BeFalse();
    }

    [TestMethod]
    public void AssertIsNull()
    {
        // arrange
        object obj = null;

        // old assertion:
        Assert.IsNull(obj);

        // new assertion:
        obj.Should().BeNull();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertIsNull_Failure_OldAssertion()
    {
        // arrange
        var obj = "foo";

        // old assertion:
        Assert.IsNull(obj);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertIsNull_Failure_NewAssertion()
    {
        // arrange
        var obj = "foo";

        // new assertion:
        obj.Should().BeNull();
    }

    [TestMethod]
    public void AssertIsNotNull()
    {
        // arrange
        var obj = new object();

        // old assertion:
        Assert.IsNotNull(obj);

        // new assertion:
        obj.Should().NotBeNull();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertIsNotNull_Failure_OldAssertion()
    {
        // arrange
        object obj = null;

        // old assertion:
        Assert.IsNotNull(obj);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertIsNotNull_Failure_NewAssertion()
    {
        // arrange
        object obj = null;

        // new assertion:
        obj.Should().NotBeNull();
    }

    [TestMethod]
    public void AssertIsInstanceOfType()
    {
        // arrange
        var obj = new List<object>();

        // old assertion:
        Assert.IsInstanceOfType(obj, typeof(List<object>));
        Assert.IsInstanceOfType<List<object>>(obj);

        // new assertion:
        obj.Should().BeOfType<List<object>>();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertIsInstanceOfType_Failure_OldAssertion_0()
    {
        // arrange
        var obj = new List<int>();

        // old assertion:
        Assert.IsInstanceOfType(obj, typeof(List<object>));
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertIsInstanceOfType_Failure_OldAssertion_1()
    {
        // arrange
        var obj = new List<int>();

        // old assertion:
        Assert.IsInstanceOfType<List<object>>(obj);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertIsInstanceOfType_Failure_NewAssertion()
    {
        // arrange
        var obj = new List<int>();

        // new assertion:
        obj.Should().BeOfType<List<object>>();
    }

    [TestMethod]
    public void AssertIsNotInstanceOfType()
    {
        // arrange
        var obj = new List<int>();

        // old assertion:
        Assert.IsNotInstanceOfType(obj, typeof(List<object>));
        Assert.IsNotInstanceOfType<List<object>>(obj);

        // new assertion:
        obj.Should().NotBeOfType<List<object>>();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertIsNotInstanceOfType_Failure_OldAssertion_0()
    {
        // arrange
        var obj = new List<object>();

        // old assertion:
        Assert.IsNotInstanceOfType(obj, typeof(List<object>));
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertIsNotInstanceOfType_Failure_OldAssertion_1()
    {
        // arrange
        var obj = new List<object>();

        // old assertion:
        Assert.IsNotInstanceOfType<List<object>>(obj);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertIsNotInstanceOfType_Failure_NewAssertion()
    {
        // arrange
        var obj = new List<object>();

        // new assertion:
        obj.Should().NotBeOfType<List<object>>();
    }

    [TestMethod]
    public void AssertObjectAreEqual()
    {
        // arrange
        object obj1 = "foo";
        object obj2 = "foo";

        // old assertion:
        Assert.AreEqual(obj2, obj1);

        // new assertion:
        obj1.Should().Be(obj2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertObjectAreEqual_Failure_OldAssertion()
    {
        // arrange
        object obj1 = "foo";
        object obj2 = 42;

        // old assertion:
        Assert.AreEqual(obj2, obj1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertObjectAreEqual_Failure_NewAssertion()
    {
        // arrange
        object obj1 = "foo";
        object obj2 = 42;

        // new assertion:
        obj1.Should().Be(obj2);
    }

    [TestMethod]
    public void AssertObjectAreEqual_LiteralValue()
    {
        // arrange
        object obj1 = "foo";

        // old assertion:
        Assert.AreEqual(obj1, "foo");

        // new assertion:
        obj1.Should().Be("foo");
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertObjectAreEqual_LiteralValue_Failure_OldAssertion()
    {
        // arrange
        object obj1 = "foo";

        // old assertion:
        Assert.AreEqual(obj1, "bar");
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertObjectAreEqual_LiteralValue_Failure_NewAssertion()
    {
        // arrange
        object obj1 = "foo";

        // new assertion:
        obj1.Should().Be("bar");
    }

    [TestMethod]
    public void AssertOptionalIntegerAreEqual()
    {
        // arrange
        int? number1 = 42;
        int? number2 = 42;

        // old assertion:
        Assert.AreEqual(number2, number1);

        // new assertion:
        number1.Should().Be(number2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertOptionalIntegerAreEqual_Failure_OldAssertion()
    {
        // arrange
        int? number1 = 42;
        int? number2 = 6;

        // old assertion:
        Assert.AreEqual(number2, number1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertOptionalIntegerAreEqual_Failure_NewAssertion()
    {
        // arrange
        int? number1 = 42;
        int? number2 = 6;

        // new assertion:
        number1.Should().Be(number2);
    }

    [TestMethod]
    public void AssertOptionalIntegerAndNullAreEqual()
    {
        // arrange
        int? number = null;

        // old assertion:
        Assert.AreEqual(number, null);
        Assert.AreEqual(null, number);

        // new assertion:
        number.Should().BeNull();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertOptionalIntegerAndNullAreEqual_Failure_OldAssertion_0()
    {
        // arrange
        int? number = 42;

        // old assertion:
        Assert.AreEqual(number, null);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertOptionalIntegerAndNullAreEqual_Failure_OldAssertion_1()
    {
        // arrange
        int? number = 42;

        // old assertion:
        Assert.AreEqual(null, number);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertOptionalIntegerAndNullAreEqual_Failure_NewAssertion()
    {
        // arrange
        int? number = 42;

        // new assertion:
        number.Should().BeNull();
    }

    [TestMethod]
    public void AssertDoubleAreEqual()
    {
        // arrange
        double number1 = 3.14;
        double number2 = 3.141;
        double delta = 0.00159;

        // old assertion:
        Assert.AreEqual(number2, number1, delta);

        // new assertion:
        number1.Should().BeApproximately(number2, delta);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertDoubleAreEqual_Failure_OldAssertion()
    {
        // arrange
        double number1 = 3.14;
        double number2 = 4.2;
        double delta = 0.0001;

        // old assertion:
        Assert.AreEqual(number2, number1, delta);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertDoubleAreEqual_Failure_NewAssertion()
    {
        // arrange
        double number1 = 3.14;
        double number2 = 4.2;
        double delta = 0.0001;

        // new assertion:
        number1.Should().BeApproximately(number2, delta);
    }

    [TestMethod]
    public void AssertFloatAreEqual()
    {
        // arrange
        float number1 = 3.14f;
        float number2 = 3.141f;
        float delta = 0.00159f;

        // old assertion:
        Assert.AreEqual(number2, number1, delta);

        // new assertion:
        number1.Should().BeApproximately(number2, delta);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertFloatAreEqual_Failure_OldAssertion()
    {
        // arrange
        float number1 = 3.14f;
        float number2 = 4.2f;
        float delta = 0.0001f;

        // old assertion:
        Assert.AreEqual(number2, number1, delta);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertFloatAreEqual_Failure_NewAssertion()
    {
        // arrange
        float number1 = 3.14f;
        float number2 = 4.2f;
        float delta = 0.0001f;

        // new assertion:
        number1.Should().BeApproximately(number2, delta);
    }

    [TestMethod]
    public void AssertStringAreEqual_CaseSensitive()
    {
        // arrange
        string str1 = "foo";
        string str2 = "foo";

        // old assertion:
        Assert.AreEqual(str2, str1);
        Assert.AreEqual(str2, str1, ignoreCase: false);
        Assert.AreEqual(str2, str1, ignoreCase: false, culture: CultureInfo.CurrentCulture);

        // new assertion:
        str1.Should().Be(str2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreEqual_CaseSensitive_Failure_OldAssertion_0()
    {
        // arrange
        string str1 = "foo";
        string str2 = "FoO";

        // old assertion:
        Assert.AreEqual(str2, str1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreEqual_CaseSensitive_Failure_OldAssertion_1()
    {
        // arrange
        string str1 = "foo";
        string str2 = "FoO";

        // old assertion:
        Assert.AreEqual(str2, str1, ignoreCase: false);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreEqual_CaseSensitive_Failure_OldAssertion_2()
    {
        // arrange
        string str1 = "foo";
        string str2 = "FoO";

        // old assertion:
        Assert.AreEqual(str2, str1, ignoreCase: false, culture: CultureInfo.CurrentCulture);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreEqual_CaseSensitive_Failure_NewAssertion()
    {
        // arrange
        string str1 = "foo";
        string str2 = "FoO";

        // new assertion:
        str1.Should().Be(str2);
    }

    [TestMethod]
    public void AssertStringAreEqual_IgnoreCase()
    {
        // arrange
        string str1 = "foo";
        string str2 = "FoO";

        // old assertion:
        Assert.AreEqual(str2, str1, ignoreCase: true);
        Assert.AreEqual(str2, str1, ignoreCase: true, culture: CultureInfo.CurrentCulture);

        // new assertion:
        str1.Should().BeEquivalentTo(str2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreEqual_IgnoreCase_Failure_OldAssertion_0()
    {
        // arrange
        string str1 = "foo";
        string str2 = "bar";

        // old assertion:
        Assert.AreEqual(str2, str1, ignoreCase: true);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreEqual_IgnoreCase_Failure_OldAssertion_1()
    {
        // arrange
        string str1 = "foo";
        string str2 = "bar";

        // old assertion:
        Assert.AreEqual(str2, str1, ignoreCase: true, culture: CultureInfo.CurrentCulture);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreEqual_IgnoreCase_Failure_NewAssertion()
    {
        // arrange
        string str1 = "foo";
        string str2 = "bar";

        // new assertion:
        str1.Should().BeEquivalentTo(str2);
    }

    [TestMethod]
    public void AssertObjectAreNotEqual()
    {
        // arrange
        object obj1 = "foo";
        object obj2 = "bar";

        // old assertion:
        Assert.AreNotEqual(obj2, obj1);

        // new assertion:
        obj1.Should().NotBe(obj2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertObjectAreNotEqual_Failure_OldAssertion()
    {
        // arrange
        object obj1 = "foo";
        object obj2 = "foo";

        // old assertion:
        Assert.AreNotEqual(obj2, obj1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertObjectAreNotEqual_Failure_NewAssertion()
    {
        // arrange
        object obj1 = "foo";
        object obj2 = "foo";

        // new assertion:
        obj1.Should().NotBe(obj2);
    }

    [TestMethod]
    public void AssertOptionalIntegerAreNotEqual()
    {
        // arrange
        int? number1 = 42;
        int? number2 = 6;

        // old assertion:
        Assert.AreNotEqual(number2, number1);

        // new assertion:
        number1.Should().NotBe(number2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertOptionalIntegerAreNotEqual_Failure_OldAssertion()
    {
        // arrange
        int? number1 = 42;
        int? number2 = 42;

        // old assertion:
        Assert.AreNotEqual(number2, number1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertOptionalIntegerAreNotEqual_Failure_NewAssertion()
    {
        // arrange
        int? number1 = 42;
        int? number2 = 42;

        // new assertion:
        number1.Should().NotBe(number2);
    }

    [TestMethod]
    public void AssertDoubleAreNotEqual()
    {
        // arrange
        double number1 = 3.14;
        double number2 = 4.2;
        double delta = 0.0001;

        // old assertion:
        Assert.AreNotEqual(number2, number1, delta);

        // new assertion:
        number1.Should().NotBeApproximately(number2, delta);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertDoubleAreNotEqual_Failure_OldAssertion()
    {
        // arrange
        double number1 = 3.14;
        double number2 = 3.141;
        double delta = 0.00159;

        // old assertion:
        Assert.AreNotEqual(number2, number1, delta);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertDoubleAreNotEqual_Failure_NewAssertion()
    {
        // arrange
        double number1 = 3.14;
        double number2 = 3.141;
        double delta = 0.00159;

        // new assertion:
        number1.Should().NotBeApproximately(number2, delta);
    }

    [TestMethod]
    public void AssertFloatAreNotEqual()
    {
        // arrange
        float number1 = 3.14f;
        float number2 = 4.2f;
        float delta = 0.0001f;

        // old assertion:
        Assert.AreNotEqual(number2, number1, delta);

        // new assertion:
        number1.Should().NotBeApproximately(number2, delta);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertFloatAreNotEqual_Failure_OldAssertion()
    {
        // arrange
        float number1 = 3.14f;
        float number2 = 3.141f;
        float delta = 0.00159f;

        // old assertion:
        Assert.AreNotEqual(number2, number1, delta);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertFloatAreNotEqual_Failure_NewAssertion()
    {
        // arrange
        float number1 = 3.14f;
        float number2 = 3.141f;
        float delta = 0.00159f;

        // new assertion:
        number1.Should().NotBeApproximately(number2, delta);
    }

    [TestMethod]
    public void AssertStringAreNotEqual_CaseSensitive()
    {
        // arrange
        string str1 = "foo";
        string str2 = "bar";

        // old assertion:
        Assert.AreNotEqual(str2, str1);
        Assert.AreNotEqual(str2, str1, ignoreCase: false);
        Assert.AreNotEqual(str2, str1, ignoreCase: false, culture: CultureInfo.CurrentCulture);

        // new assertion:
        str1.Should().NotBe(str2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreNotEqual_CaseSensitive_Failure_OldAssertion_0()
    {
        // arrange
        string str1 = "foo";
        string str2 = "foo";

        // old assertion:
        Assert.AreNotEqual(str2, str1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreNotEqual_CaseSensitive_Failure_OldAssertion_1()
    {
        // arrange
        string str1 = "foo";
        string str2 = "foo";

        // old assertion:
        Assert.AreNotEqual(str2, str1, ignoreCase: false);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreNotEqual_CaseSensitive_Failure_OldAssertion_2()
    {
        // arrange
        string str1 = "foo";
        string str2 = "foo";

        // old assertion:
        Assert.AreNotEqual(str2, str1, ignoreCase: false, culture: CultureInfo.CurrentCulture);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreNotEqual_CaseSensitive_Failure_NewAssertion()
    {
        // arrange
        string str1 = "foo";
        string str2 = "foo";

        // new assertion:
        str1.Should().NotBe(str2);
    }

    [TestMethod]
    public void AssertStringAreNotEqual_IgnoreCase()
    {
        // arrange
        string str1 = "foo";
        string str2 = "bar";

        // old assertion:
        Assert.AreNotEqual(str2, str1, ignoreCase: true);
        Assert.AreNotEqual(str2, str1, ignoreCase: true, culture: CultureInfo.CurrentCulture);

        // new assertion:
        str1.Should().NotBeEquivalentTo(str2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreNotEqual_IgnoreCase_Failure_OldAssertion_0()
    {
        // arrange
        string str1 = "foo";
        string str2 = "FoO";

        // old assertion:
        Assert.AreNotEqual(str2, str1, ignoreCase: true);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreNotEqual_IgnoreCase_Failure_OldAssertion_1()
    {
        // arrange
        string str1 = "foo";
        string str2 = "FoO";

        // old assertion:
        Assert.AreNotEqual(str2, str1, ignoreCase: true, culture: CultureInfo.CurrentCulture);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertStringAreNotEqual_IgnoreCase_Failure_NewAssertion()
    {
        // arrange
        string str1 = "foo";
        string str2 = "FoO";

        // new assertion:
        str1.Should().NotBeEquivalentTo(str2);
    }

    [TestMethod]
    public void AssertAreSame()
    {
        // arrange
        var obj1 = new object();
        var obj2 = obj1;

        // old assertion:
        Assert.AreSame(obj2, obj1);

        // new assertion:
        obj1.Should().BeSameAs(obj2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertAreSame_Failure_OldAssertion()
    {
        // arrange
        object obj1 = 6;
        object obj2 = "foo";

        // old assertion:
        Assert.AreSame(obj2, obj1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
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
        Assert.AreNotSame(obj2, obj1);

        // new assertion:
        obj1.Should().NotBeSameAs(obj2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertAreNotSame_Failure_OldAssertion()
    {
        // arrange
        object obj1 = "foo";
        object obj2 = "foo";

        // old assertion:
        Assert.AreNotSame(obj2, obj1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertAreNotSame_Failure_NewAssertion()
    {
        // arrange
        object obj1 = "foo";
        object obj2 = "foo";

        // new assertion:
        obj1.Should().NotBeSameAs(obj2);
    }

    [TestMethod]
    public void CollectionAssertAllItemsAreInstancesOfType()
    {
        // arrange
        var list = new List<object> { 1, 2, 3 };

        // old assertion:
        CollectionAssert.AllItemsAreInstancesOfType(list, typeof(int));

        // new assertion:
        list.Should().AllBeOfType<int>();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAllItemsAreInstancesOfType_Failure_OldAssertion()
    {
        // arrange
        var list = new List<object> { 1, 2, "foo" };

        // old assertion:
        CollectionAssert.AllItemsAreInstancesOfType(list, typeof(int));
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAllItemsAreInstancesOfType_Failure_NewAssertion()
    {
        // arrange
        var list = new List<object> { 1, 2, "foo" };

        // new assertion:
        list.Should().AllBeOfType<int>();
    }

    [TestMethod]
    public void CollectionAssertAreEqual()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 1, 2, 3 };

        // old assertion:
        CollectionAssert.AreEqual(list2, list1);

        // new assertion:
        list1.Should().Equal(list2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAreEqual_Failure_OldAssertion()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 1, 2, 4 };

        // old assertion:
        CollectionAssert.AreEqual(list2, list1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAreEqual_Failure_NewAssertion()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 1, 2, 4 };

        // new assertion:
        list1.Should().Equal(list2);
    }

    [TestMethod]
    public void CollectionAssertAreNotEqual()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 1, 2, 4 };

        // old assertion:
        CollectionAssert.AreNotEqual(list2, list1);

        // new assertion:
        list1.Should().NotEqual(list2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAreNotEqual_Failure_OldAssertion()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 1, 2, 3 };

        // old assertion:
        CollectionAssert.AreNotEqual(list2, list1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAreNotEqual_Failure_NewAssertion()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 1, 2, 3 };

        // new assertion:
        list1.Should().NotEqual(list2);
    }

    [TestMethod]
    public void CollectionAssertAreEquivalent()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 3, 2, 1 };

        // old assertion:
        CollectionAssert.AreEquivalent(list2, list1);

        // new assertion:
        list1.Should().BeEquivalentTo(list2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAreEquivalent_Failure_OldAssertion()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 2, 3, 4 };

        // old assertion:
        CollectionAssert.AreEquivalent(list2, list1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAreEquivalent_Failure_NewAssertion()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 2, 3, 4 };

        // new assertion:
        list1.Should().BeEquivalentTo(list2);
    }

    [TestMethod]
    public void CollectionAssertAreNotEquivalent()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 2, 3, 4 };

        // old assertion:
        CollectionAssert.AreNotEquivalent(list2, list1);

        // new assertion:
        list1.Should().NotBeEquivalentTo(list2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAreNotEquivalent_Failure_OldAssertion()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 2, 3, 1 };

        // old assertion:
        CollectionAssert.AreNotEquivalent(list2, list1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAreNotEquivalent_Failure_NewAssertion()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 2, 3, 1 };

        // new assertion:
        list1.Should().NotBeEquivalentTo(list2);
    }

    [TestMethod]
    public void CollectionAssertAllItemsAreNotNull()
    {
        // arrange
        var list = new List<object> { 1, "foo", true };

        // old assertion:
        CollectionAssert.AllItemsAreNotNull(list);

        // new assertion:
        list.Should().NotContainNulls();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAllItemsAreNotNull_Failure_OldAssertion()
    {
        // arrange
        var list = new List<object> { 1, null, true };

        // old assertion:
        CollectionAssert.AllItemsAreNotNull(list);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAllItemsAreNotNull_Failure_NewAssertion()
    {
        // arrange
        var list = new List<object> { 1, null, true };

        // new assertion:
        list.Should().NotContainNulls();
    }

    [TestMethod]
    public void CollectionAssertAllItemsAreUnique()
    {
        // arrange
        var list = new List<int> { 1, 2, 3 };

        // old assertion:
        CollectionAssert.AllItemsAreUnique(list);

        // new assertion:
        list.Should().OnlyHaveUniqueItems();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAllItemsAreUnique_Failure_OldAssertion()
    {
        // arrange
        var list = new List<int> { 1, 2, 1 };

        // old assertion:
        CollectionAssert.AllItemsAreUnique(list);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertAllItemsAreUnique_Failure_NewAssertion()
    {
        // arrange
        var list = new List<int> { 1, 2, 1 };

        // new assertion:
        list.Should().OnlyHaveUniqueItems();
    }

    [TestMethod]
    public void CollectionAssertContains()
    {
        // arrange
        var list = new List<int> { 1, 2, 3 };

        // old assertion:
        CollectionAssert.Contains(list, 2);

        // new assertion:
        list.Should().Contain(2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertContains_Failure_OldAssertion()
    {
        // arrange
        var list = new List<int> { 1, 2, 3 };

        // old assertion:
        CollectionAssert.Contains(list, 4);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertContains_Failure_NewAssertion()
    {
        // arrange
        var list = new List<int> { 1, 2, 3 };

        // new assertion:
        list.Should().Contain(4);
    }

    [TestMethod]
    public void CollectionAssertDoesNotContain()
    {
        // arrange
        var list = new List<int> { 1, 2, 3 };

        // old assertion:
        CollectionAssert.DoesNotContain(list, 4);

        // new assertion:
        list.Should().NotContain(4);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertDoesNotContain_Failure_OldAssertion()
    {
        // arrange
        var list = new List<int> { 1, 2, 3 };

        // old assertion:
        CollectionAssert.DoesNotContain(list, 2);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertDoesNotContain_Failure_NewAssertion()
    {
        // arrange
        var list = new List<int> { 1, 2, 3 };

        // new assertion:
        list.Should().NotContain(2);
    }

    [TestMethod]
    public void CollectionAssertIsSubsetOf()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3, 4 };
        var list2 = new List<int> { 2, 3 };

        // old assertion:
        CollectionAssert.IsSubsetOf(list2, list1);

        // new assertion:
        list2.Should().BeSubsetOf(list1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertIsSubsetOf_Failure_OldAssertion()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3, 4 };
        var list2 = new List<int> { 2, 3, 5 };

        // old assertion:
        CollectionAssert.IsSubsetOf(list2, list1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertIsSubsetOf_Failure_NewAssertion()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3, 4 };
        var list2 = new List<int> { 2, 3, 5 };

        // new assertion:
        list2.Should().BeSubsetOf(list1);
    }

    [TestMethod]
    public void CollectionAssertIsNotSubsetOf()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3, 4 };
        var list2 = new List<int> { 2, 3, 5 };

        // old assertion:
        CollectionAssert.IsNotSubsetOf(list2, list1);

        // new assertion:
        list2.Should().NotBeSubsetOf(list1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertIsNotSubsetOf_Failure_OldAssertion()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3, 4 };
        var list2 = new List<int> { 2, 3 };

        // old assertion:
        CollectionAssert.IsNotSubsetOf(list2, list1);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void CollectionAssertIsNotSubsetOf_Failure_NewAssertion()
    {
        // arrange
        var list1 = new List<int> { 1, 2, 3, 4 };
        var list2 = new List<int> { 2, 3 };

        // new assertion:
        list2.Should().NotBeSubsetOf(list1);
    }

    [TestMethod]
    public void AssertThrowsException()
    {
        // arrange
        static void ThrowException() => throw new InvalidOperationException();
        Action action = ThrowException;

        // old assertion:
        Assert.ThrowsException<InvalidOperationException>(action);

        // new assertion:
        action.Should().ThrowExactly<InvalidOperationException>();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertThrowsException_Failure_OldAssertion()
    {
        // arrange
        static void ThrowException() => throw new InvalidOperationException();
        Action action = ThrowException;

        // old assertion:
        Assert.ThrowsException<ArgumentException>(action);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void AssertThrowsException_Failure_NewAssertion()
    {
        // arrange
        static void ThrowException() => throw new InvalidOperationException();
        Action action = ThrowException;

        // new assertion:
        action.Should().ThrowExactly<ArgumentException>();
    }

    [TestMethod]
    public async Task AssertThrowsExceptionAsync()
    {
        // arrange
        static Task ThrowExceptionAsync() => throw new InvalidOperationException();
        Func<Task> action = ThrowExceptionAsync;

        // old assertion:
        await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);

        // new assertion:
        await action.Should().ThrowExactlyAsync<InvalidOperationException>();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public async Task AssertThrowsExceptionAsync_Failure_OldAssertion()
    {
        // arrange
        static Task ThrowExceptionAsync() => throw new InvalidOperationException();
        Func<Task> action = ThrowExceptionAsync;

        // old assertion:
        await Assert.ThrowsExceptionAsync<ArgumentException>(action);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public async Task AssertThrowsExceptionAsync_Failure_NewAssertion()
    {
        // arrange
        static Task ThrowExceptionAsync() => throw new InvalidOperationException();
        Func<Task> action = ThrowExceptionAsync;

        // new assertion:
        await action.Should().ThrowExactlyAsync<ArgumentException>();
    }

    [TestMethod]
    public void StringAssertContains()
    {
        // arrange
        var str = "foo";

        // old assertion:
        StringAssert.Contains(str, "oo");

        // new assertion:
        str.Should().Contain("oo");
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void StringAssertContains_Failure_OldAssertion()
    {
        // arrange
        var str = "foo";

        // old assertion:
        StringAssert.Contains(str, "bar");
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void StringAssertContains_Failure_NewAssertion()
    {
        // arrange
        var str = "foo";

        // new assertion:
        str.Should().Contain("bar");
    }

    [TestMethod]
    public void StringAssertStartsWith()
    {
        // arrange
        var str = "foo";

        // old assertion:
        StringAssert.StartsWith(str, "fo");

        // new assertion:
        str.Should().StartWith("fo");
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void StringAssertStartsWith_Failure_OldAssertion()
    {
        // arrange
        var str = "foo";

        // old assertion:
        StringAssert.StartsWith(str, "oo");
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void StringAssertStartsWith_Failure_NewAssertion()
    {
        // arrange
        var str = "foo";

        // new assertion:
        str.Should().StartWith("oo");
    }

    [TestMethod]
    public void StringAssertEndsWith()
    {
        // arrange
        var str = "foo";

        // old assertion:
        StringAssert.EndsWith(str, "oo");

        // new assertion:
        str.Should().EndWith("oo");
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void StringAssertEndsWith_Failure_OldAssertion()
    {
        // arrange
        var str = "foo";

        // old assertion:
        StringAssert.EndsWith(str, "fo");
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void StringAssertEndsWith_Failure_NewAssertion()
    {
        // arrange
        var str = "foo";

        // new assertion:
        str.Should().EndWith("fo");
    }

    [TestMethod]
    public void StringAssertMatches()
    {
        // arrange
        var str = "foo";
        var pattern = new Regex("f.o");

        // old assertion:
        StringAssert.Matches(str, pattern);

        // new assertion:
        str.Should().MatchRegex(pattern);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void StringAssertMatches_Failure_OldAssertion()
    {
        // arrange
        var str = "foo";
        var pattern = new Regex("b.r");

        // old assertion:
        StringAssert.Matches(str, pattern);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void StringAssertMatches_Failure_NewAssertion()
    {
        // arrange
        var str = "foo";
        var pattern = new Regex("b.r");

        // new assertion:
        str.Should().MatchRegex(pattern);
    }

    [TestMethod]
    public void StringAssertDoesNotMatch()
    {
        // arrange
        var str = "foo";
        var pattern = new Regex("b.r");

        // old assertion:
        StringAssert.DoesNotMatch(str, pattern);

        // new assertion:
        str.Should().NotMatchRegex(pattern);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void StringAssertDoesNotMatch_Failure_OldAssertion()
    {
        // arrange
        var str = "foo";
        var pattern = new Regex("f.o");

        // old assertion:
        StringAssert.DoesNotMatch(str, pattern);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void StringAssertDoesNotMatch_Failure_NewAssertion()
    {
        // arrange
        var str = "foo";
        var pattern = new Regex("f.o");

        // new assertion:
        str.Should().NotMatchRegex(pattern);
    }
}
