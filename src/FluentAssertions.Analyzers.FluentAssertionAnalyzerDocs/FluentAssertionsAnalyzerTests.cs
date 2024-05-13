using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

[TestClass]
public class FluentAssertionsAnalyzerTests
{
    [TestMethod]
    public void CollectionShouldNotBeEmpty()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Any().Should().BeTrue();

        // new assertion:
        collection.Should().NotBeEmpty();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldNotBeEmpty_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { };

        // old assertion:
        collection.Any().Should().BeTrue();

        // new assertion:
        collection.Should().NotBeEmpty();
    }

    [TestMethod]
    public void CollectionShouldBeEmpty()
    {
        // arrange
        var collection = new List<int>();

        // old assertion:
        collection.Any().Should().BeFalse();
        collection.Count().Should().Be(0);
        collection.Count.Should().Be(0);
        collection.Should().HaveCount(0);

        // new assertion:
        collection.Should().BeEmpty();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldBeEmpty_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Any().Should().BeFalse();
        collection.Count().Should().Be(0);
        collection.Count.Should().Be(0);
        collection.Should().HaveCount(0);

        // new assertion:
        collection.Should().BeEmpty();
    }

    [TestMethod]
    public void CollectionShouldNotContainCondition()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Any(i => i == 4).Should().BeFalse();
        collection.Where(i => i == 4).Should().BeEmpty();

        // new assertion:
        collection.Should().NotContain(i => i == 4);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldNotContainCondition_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 2, 3, 4, 5 };

        // old assertion:
        collection.Any(i => i == 4).Should().BeFalse();
        collection.Where(i => i == 4).Should().BeEmpty();

        // new assertion:
        collection.Should().NotContain(i => i == 4);
    }

    [TestMethod]
    public void CollectionShouldNotContainItem()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Contains(4).Should().BeFalse();

        // new assertion:
        collection.Should().NotContain(4);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldNotContainItem_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 2, 3, 4, 5 };

        // old assertion:
        collection.Contains(4).Should().BeFalse();

        // new assertion:
        collection.Should().NotContain(4);
    }

    [TestMethod]
    public void CollectionShouldOnlyContainProperty()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.All(x => x > 0).Should().BeTrue();

        // new assertion:
        collection.Should().OnlyContain(x => x > 0);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldOnlyContainProperty_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 2, 3, -1 };

        // old assertion:
        collection.All(x => x > 0).Should().BeTrue();

        // new assertion:
        collection.Should().OnlyContain(x => x > 0);
    }

    [TestMethod]
    public void CollectionShouldContainItem()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Contains(2).Should().BeTrue();

        // new assertion:
        collection.Should().Contain(2);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldContainItem_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 3, 4, 5 };

        // old assertion:
        collection.Contains(2).Should().BeTrue();

        // new assertion:
        collection.Should().Contain(2);
    }

    [TestMethod]
    public void CollectionShouldContainCondition()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Any(i => i == 2).Should().BeTrue();
        collection.Where(i => i == 2).Should().NotBeEmpty();

        // new assertion:
        collection.Should().Contain(i => i == 2);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldContainCondition_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 3, 4, 5 };

        // old assertion:
        collection.Any(i => i == 2).Should().BeTrue();
        collection.Where(i => i == 2).Should().NotBeEmpty();

        // new assertion:
        collection.Should().Contain(i => i == 2);
    }

    [TestMethod]
    public void CollectionShouldHaveCount_Count()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Count().Should().Be(3);
        collection.Count.Should().Be(3);

        // new assertion:
        collection.Should().HaveCount(3);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldHaveCount_Count_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 2, 3, 4, 5 };

        // old assertion:
        collection.Count().Should().Be(3);
        collection.Count.Should().Be(3);

        // new assertion:
        collection.Should().HaveCount(3);
    }

    [TestMethod]
    public void CollectionShouldHaveCount_Length()
    {
        // arrange
        var collection = new int[] { 1, 2, 3 };

        // old assertion:
        collection.Length.Should().Be(3);

        // new assertion:
        collection.Should().HaveCount(3);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldHaveCount_Length_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new int[] { 1, 2, 3, 4, 5 };

        // old assertion:
        collection.Length.Should().Be(3);

        // new assertion:
        collection.Should().HaveCount(3);
    }

    [TestMethod]
    public void CollectionShouldNotHaveCount_Count()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Count().Should().NotBe(4);

        // new assertion:
        collection.Should().NotHaveCount(4);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldNotHaveCount_Count_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 2, 3, 4 };

        // old assertion:
        collection.Count().Should().NotBe(4);

        // new assertion:
        collection.Should().NotHaveCount(4);
    }

    [TestMethod]
    public void CollectionShouldContainSingle()
    {
        // arrange
        var collection = new List<int> { 1 };

        // old assertion:
        collection.Count().Should().Be(1);
        collection.Count.Should().Be(1);
        collection.Should().HaveCount(1);

        // new assertion:
        collection.Should().ContainSingle();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldContainSingle_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Count().Should().Be(1);
        collection.Count.Should().Be(1);
        collection.Should().HaveCount(1);

        // new assertion:
        collection.Should().ContainSingle();
    }

    [TestMethod]
    public void CollectionShouldHaveCountGreaterThan_CountShouldBeGreaterThan()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Count().Should().BeGreaterThan(2);

        // new assertion:
        collection.Should().HaveCountGreaterThan(2);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldHaveCountGreaterThan_CountShouldBeGreaterThan_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1 };

        // old assertion:
        collection.Count().Should().BeGreaterThan(2);

        // new assertion:
        collection.Should().HaveCountGreaterThan(2);
    }

    [TestMethod]
    public void CollectionShouldHaveCountGreaterOrEqualTo_CountShouldBeGreaterOrEqualTo()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Count().Should().BeGreaterOrEqualTo(3);

        // new assertion:
        collection.Should().HaveCountGreaterOrEqualTo(3);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldHaveCountGreaterOrEqualTo_CountShouldBeGreaterOrEqualTo_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 2 };

        // old assertion:
        collection.Count().Should().BeGreaterOrEqualTo(3);

        // new assertion:
        collection.Should().HaveCountGreaterOrEqualTo(3);
    }

    [TestMethod]
    public void CollectionShouldHaveCountLessThan_CountShouldBeLessThan()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Count().Should().BeLessThan(4);

        // new assertion:
        collection.Should().HaveCountLessThan(4);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldHaveCountLessThan_CountShouldBeLessThan_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 2, 3, 4, 5 };

        // old assertion:
        collection.Count().Should().BeLessThan(4);

        // new assertion:
        collection.Should().HaveCountLessThan(4);
    }

    [TestMethod]
    public void CollectionShouldHaveCountLessOrEqualTo_CountShouldBeLessOrEqualTo()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Count().Should().BeLessOrEqualTo(3);

        // new assertion:
        collection.Should().HaveCountLessOrEqualTo(3);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldHaveCountLessOrEqualTo_CountShouldBeLessOrEqualTo_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 2, 3, 4 };

        // old assertion:
        collection.Count().Should().BeLessOrEqualTo(3);

        // new assertion:
        collection.Should().HaveCountLessOrEqualTo(3);
    }

    [TestMethod]
    public void CollectionShouldHaveSameCount_ShouldHaveCountOtherCollectionCount()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };
        var otherCollection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Should().HaveCount(otherCollection.Count());

        // new assertion:
        collection.Should().HaveSameCount(otherCollection);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldHaveSameCount_ShouldHaveCountOtherCollectionCount_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 2, 3 };
        var otherCollection = new List<int> { 2, 3, 4, 5 };

        // old assertion:
        collection.Should().HaveCount(otherCollection.Count());

        // new assertion:
        collection.Should().HaveSameCount(otherCollection);
    }

    [TestMethod]
    public void CollectionShouldNotHaveSameCount_CountShouldNotBeOtherCollectionCount()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };
        var otherCollection = new List<int> { 1, 2, 3, 4 };

        // old assertion:
        collection.Count().Should().NotBe(otherCollection.Count());

        // new assertion:
        collection.Should().NotHaveSameCount(otherCollection);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldNotHaveSameCount_CountShouldNotBeOtherCollectionCount_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 2, 3 };
        var otherCollection = new List<int> { 4, 5, 6 };

        // old assertion:
        collection.Count().Should().NotBe(otherCollection.Count());

        // new assertion:
        collection.Should().NotHaveSameCount(otherCollection);
    }

    [TestMethod]
    public void CollectionShouldContainSingle_WhereShouldHaveCount1()
    {
        // arrange
        var collection = new List<int> { 1 };

        // old assertion:
        collection.Where(i => i == 1).Should().HaveCount(1);

        // new assertion:
        collection.Should().ContainSingle(i => i == 1);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldContainSingle_WhereShouldHaveCount1_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int> { 1, 2, 3, 1 };

        // old assertion:
        collection.Where(i => i == 1).Should().HaveCount(1);

        // new assertion:
        collection.Should().ContainSingle(i => i == 1);
    }

    [TestMethod]
    public void CollectionShouldNotBeNullOrEmpty()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Should().NotBeEmpty().And.NotBeNull();
        collection.Should().NotBeNull().And.NotBeEmpty();

        // new assertion:
        collection.Should().NotBeNullOrEmpty();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void CollectionShouldNotBeNullOrEmpty_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var collection = new List<int>();

        // old assertion:
        collection.Should().NotBeEmpty().And.NotBeNull();
        collection.Should().NotBeNull().And.NotBeEmpty();

        // new assertion:
        collection.Should().NotBeNullOrEmpty();
    }

    [TestMethod]
    public void DictionaryShouldContainKey()
    {
        // arrange
        var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

        // old assertion:
        dictionary.ContainsKey("two").Should().BeTrue();

        // new assertion:
        dictionary.Should().ContainKey("two");
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void DictionaryShouldContainKey_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var dictionary = new Dictionary<string, int> { ["one"] = 1, ["three"] = 3 };

        // old assertion:
        dictionary.ContainsKey("two").Should().BeTrue();

        // new assertion:
        dictionary.Should().ContainKey("two");
    }

    [TestMethod]
    public void DictionaryShouldNotContainKey()
    {
        // arrange
        var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

        // old assertion:
        dictionary.ContainsKey("four").Should().BeFalse();

        // new assertion:
        dictionary.Should().NotContainKey("four");
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void DictionaryShouldNotContainKey_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3, ["four"] = 4 };

        // old assertion:
        dictionary.ContainsKey("four").Should().BeFalse();

        // new assertion:
        dictionary.Should().NotContainKey("four");
    }

    [TestMethod]
    public void DictionaryShouldContainValue()
    {
        // arrange
        var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

        // old assertion:
        dictionary.ContainsValue(2).Should().BeTrue();

        // new assertion:
        dictionary.Should().ContainValue(2);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void DictionaryShouldContainValue_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

        // old assertion:
        dictionary.ContainsValue(4).Should().BeTrue();

        // new assertion:
        dictionary.Should().ContainValue(4);
    }

    [TestMethod]
    public void DictionaryShouldNotContainValue()
    {
        // arrange
        var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

        // old assertion:
        dictionary.ContainsValue(4).Should().BeFalse();

        // new assertion:
        dictionary.Should().NotContainValue(4);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void DictionaryShouldNotContainValue_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3, ["four"] = 4 };

        // old assertion:
        dictionary.ContainsValue(4).Should().BeFalse();

        // new assertion:
        dictionary.Should().NotContainValue(4);
    }

    [TestMethod]
    public void DictionaryShouldContainKeyAndValue()
    {
        // arrange
        var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

        // old assertion:
        dictionary.Should().ContainKey("two").And.ContainValue(2);

        // new assertion:
        dictionary.Should().Contain("two", 2);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void DictionaryShouldContainKeyAndValue_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

        // old assertion:
        dictionary.Should().ContainKey("two").And.ContainValue(4);

        // new assertion:
        dictionary.Should().Contain("two", 4);
    }

    [TestMethod]
    public void DictionaryShouldContainPair()
    {
        // arrange
        var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };
        var pair = new KeyValuePair<string, int>("two", 2);

        // old assertion:
        dictionary.Should().ContainKey(pair.Key).And.ContainValue(pair.Value);

        // new assertion:
        dictionary.Should().Contain(pair);
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void DictionaryShouldContainPair_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };
        var pair = new KeyValuePair<string, int>("two", 4);

        // old assertion:
        dictionary.Should().ContainKey(pair.Key).And.ContainValue(pair.Value);

        // new assertion:
        dictionary.Should().Contain(pair);
    }

    [TestMethod]
    public void ExceptionShouldThrowWithMessage_Be()
    {
        // arrange
        static void ThrowException() => throw new Exception("message");
        Action action = ThrowException;

        // old assertion:
        action.Should().Throw<Exception>().And.Message.Should().Be("message");
        action.Should().Throw<Exception>().Which.Message.Should().Be("message");

        // new assertion:
        action.Should().Throw<Exception>().WithMessage("message");
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void ExceptionShouldThrowWithMessage_Be_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        static void ThrowException() => throw new Exception("wrong");
        Action action = ThrowException;

        // old assertion:
        action.Should().Throw<Exception>().And.Message.Should().Be("message");
        action.Should().Throw<Exception>().Which.Message.Should().Be("message");

        // new assertion:
        action.Should().Throw<Exception>().WithMessage("message");
    }

    [TestMethod]
    public void ExceptionShouldThrowWithMessage_Contain()
    {
        // arrange
        static void ThrowException() => throw new Exception("message");
        Action action = ThrowException;

        // old assertion:
        action.Should().Throw<Exception>().And.Message.Should().Contain("mess");
        action.Should().Throw<Exception>().Which.Message.Should().Contain("mess");

        // new assertion:
        action.Should().Throw<Exception>().WithMessage("*mess*");
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void ExceptionShouldThrowWithMessage_Contain_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        static void ThrowException() => throw new Exception("wrong");
        Action action = ThrowException;

        // old assertion:
        action.Should().Throw<Exception>().And.Message.Should().Contain("mess");
        action.Should().Throw<Exception>().Which.Message.Should().Contain("mess");

        // new assertion:
        action.Should().Throw<Exception>().WithMessage("*mess*");
    }

    [TestMethod]
    public void ExceptionShouldThrowWithMessage_EndWith()
    {
        // arrange
        static void ThrowException() => throw new Exception("message");
        Action action = ThrowException;

        // old assertion:
        action.Should().Throw<Exception>().And.Message.Should().EndWith("age");
        action.Should().Throw<Exception>().Which.Message.Should().EndWith("age");

        // new assertion:
        action.Should().Throw<Exception>().WithMessage("*age");
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void ExceptionShouldThrowWithMessage_EndWith_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        static void ThrowException() => throw new Exception("wrong");
        Action action = ThrowException;

        // old assertion:
        action.Should().Throw<Exception>().And.Message.Should().EndWith("age");
        action.Should().Throw<Exception>().Which.Message.Should().EndWith("age");

        // new assertion:
        action.Should().Throw<Exception>().WithMessage("*age");
    }

    [TestMethod]
    public void ExceptionShouldThrowWithMessage_StartWith()
    {
        // arrange
        static void ThrowException() => throw new Exception("message");
        Action action = ThrowException;

        // old assertion:
        action.Should().Throw<Exception>().And.Message.Should().StartWith("mes");
        action.Should().Throw<Exception>().Which.Message.Should().StartWith("mes");

        // new assertion:
        action.Should().Throw<Exception>().WithMessage("mes*");
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void ExceptionShouldThrowWithMessage_StartWith_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        static void ThrowException() => throw new Exception("wrong");
        Action action = ThrowException;

        // old assertion:
        action.Should().Throw<Exception>().And.Message.Should().StartWith("mes");
        action.Should().Throw<Exception>().Which.Message.Should().StartWith("mes");

        // new assertion:
        action.Should().Throw<Exception>().WithMessage("mes*");
    }

    [TestMethod]
    public void ExceptionShouldThrowExactlyWithMessage_Be()
    {
        // arrange
        static void ThrowException() => throw new ArgumentException("message");
        Action action = ThrowException;

        // old assertion:
        action.Should().ThrowExactly<ArgumentException>().And.Message.Should().Be("message");
        action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().Be("message");

        // new assertion:
        action.Should().ThrowExactly<ArgumentException>().WithMessage("message");
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void ExceptionShouldThrowExactlyWithMessage_Be_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        static void ThrowException() => throw new ArgumentException("wrong");
        Action action = ThrowException;

        // old assertion:
        action.Should().ThrowExactly<ArgumentException>().And.Message.Should().Be("message");
        action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().Be("message");

        // new assertion:
        action.Should().ThrowExactly<ArgumentException>().WithMessage("message");
    }

    [TestMethod]
    public void ExceptionShouldThrowExactlyWithMessage_Contain()
    {
        // arrange
        static void ThrowException() => throw new ArgumentException("message");
        Action action = ThrowException;

        // old assertion:
        action.Should().ThrowExactly<ArgumentException>().And.Message.Should().Contain("mess");
        action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().Contain("mess");

        // new assertion:
        action.Should().ThrowExactly<ArgumentException>().WithMessage("*mess*");
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void ExceptionShouldThrowExactlyWithMessage_Contain_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        static void ThrowException() => throw new ArgumentException("wrong");
        Action action = ThrowException;

        // old assertion:
        action.Should().ThrowExactly<ArgumentException>().And.Message.Should().Contain("mess");
        action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().Contain("mess");

        // new assertion:
        action.Should().ThrowExactly<ArgumentException>().WithMessage("*mess*");
    }

    [TestMethod]
    public void ExceptionShouldThrowExactlyWithMessage_EndWith()
    {
        // arrange
        static void ThrowException() => throw new ArgumentException("message");
        Action action = ThrowException;

        // old assertion:
        action.Should().ThrowExactly<ArgumentException>().And.Message.Should().EndWith("age");
        action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().EndWith("age");

        // new assertion:
        action.Should().ThrowExactly<ArgumentException>().WithMessage("*age");
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void ExceptionShouldThrowExactlyWithMessage_EndWith_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        static void ThrowException() => throw new ArgumentException("wrong");
        Action action = ThrowException;

        // old assertion:
        action.Should().ThrowExactly<ArgumentException>().And.Message.Should().EndWith("age");
        action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().EndWith("age");

        // new assertion:
        action.Should().ThrowExactly<ArgumentException>().WithMessage("*age");
    }

    [TestMethod]
    public void ExceptionShouldThrowExactlyWithMessage_StartWith()
    {
        // arrange
        static void ThrowException() => throw new ArgumentException("message");
        Action action = ThrowException;

        // old assertion:
        action.Should().ThrowExactly<ArgumentException>().And.Message.Should().StartWith("mes");
        action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().StartWith("mes");

        // new assertion:
        action.Should().ThrowExactly<ArgumentException>().WithMessage("mes*");
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void ExceptionShouldThrowExactlyWithMessage_StartWith_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        static void ThrowException() => throw new ArgumentException("wrong");
        Action action = ThrowException;

        // old assertion:
        action.Should().ThrowExactly<ArgumentException>().And.Message.Should().StartWith("mes");
        action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().StartWith("mes");

        // new assertion:
        action.Should().ThrowExactly<ArgumentException>().WithMessage("mes*");
    }

    [TestMethod]
    public void ExceptionShouldThrowExactlyWithInnerExceptionExactly_BeOfType()
    {
        // arrange
        static void ThrowException() => throw new ArgumentException("message", new InvalidOperationException());
        Action action = ThrowException;

        // old assertion:
        action.Should().ThrowExactly<ArgumentException>().And.InnerException.Should().BeOfType<InvalidOperationException>();
        action.Should().ThrowExactly<ArgumentException>().Which.InnerException.Should().BeOfType<InvalidOperationException>();

        // new assertion:
        action.Should().ThrowExactly<ArgumentException>().WithInnerExceptionExactly<InvalidOperationException>();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void ExceptionShouldThrowExactlyWithInnerExceptionExactly_BeOfType_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        static void ThrowException() => throw new ArgumentException("message", new InvalidOperationException());
        Action action = ThrowException;

        // old assertion:
        action.Should().ThrowExactly<ArgumentException>().And.InnerException.Should().BeOfType<ArgumentException>();
        action.Should().ThrowExactly<ArgumentException>().Which.InnerException.Should().BeOfType<ArgumentException>();

        // new assertion:
        action.Should().ThrowExactly<ArgumentException>().WithInnerExceptionExactly<ArgumentException>();
    }

    [TestMethod]
    public void ExceptionShouldThrowWithInnerExceptionExactly_BeOfType()
    {
        // arrange
        static void ThrowException() => throw new ArgumentException("message", new InvalidOperationException());
        Action action = ThrowException;

        // old assertion:
        action.Should().Throw<ArgumentException>().And.InnerException.Should().BeOfType<InvalidOperationException>();
        action.Should().Throw<ArgumentException>().Which.InnerException.Should().BeOfType<InvalidOperationException>();

        // new assertion:
        action.Should().Throw<ArgumentException>().WithInnerExceptionExactly<InvalidOperationException>();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void ExceptionShouldThrowWithInnerExceptionExactly_BeOfType_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        static void ThrowException() => throw new ArgumentException("message", new InvalidOperationException());
        Action action = ThrowException;

        // old assertion:
        action.Should().Throw<ArgumentException>().And.InnerException.Should().BeOfType<ArgumentException>();
        action.Should().Throw<ArgumentException>().Which.InnerException.Should().BeOfType<ArgumentException>();

        // new assertion:
        action.Should().Throw<ArgumentException>().WithInnerExceptionExactly<ArgumentException>();
    }

    [TestMethod]
    public void ExceptionShouldThrowExactlyWithInnerException_BeAssignableTo()
    {
        // arrange
        static void ThrowException() => throw new ArgumentException("message", new InvalidOperationException());
        Action action = ThrowException;

        // old assertion:
        action.Should().ThrowExactly<ArgumentException>().And.InnerException.Should().BeAssignableTo<InvalidOperationException>();
        action.Should().ThrowExactly<ArgumentException>().Which.InnerException.Should().BeAssignableTo<InvalidOperationException>();

        // new assertion:
        action.Should().ThrowExactly<ArgumentException>().WithInnerException<InvalidOperationException>();
    }

    [TestMethod, ExpectedTestFrameworkException]
    public void ExceptionShouldThrowExactlyWithInnerException_BeAssignableTo_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        static void ThrowException() => throw new ArgumentException("message", new InvalidOperationException());
        Action action = ThrowException;

        // old assertion:
        action.Should().ThrowExactly<ArgumentException>().And.InnerException.Should().BeAssignableTo<ArgumentException>();
        action.Should().ThrowExactly<ArgumentException>().Which.InnerException.Should().BeAssignableTo<ArgumentException>();

        // new assertion:
        action.Should().ThrowExactly<ArgumentException>().WithInnerException<ArgumentException>();
    }
}