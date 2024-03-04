using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

[TestClass]
public class FluentAssertionsAnalyzerTests
{
    [TestMethod]
    public void CollectionsShouldNotBeEmpty()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

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

    [TestMethod]
    public void CollectionShouldHaveCount_Count()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Count().Should().Be(3);
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

    [TestMethod]
    public void CollectionShouldContainSingle_CountShouldBe1()
    {
        // arrange
        var collection = new List<int> { 1 };

        // old assertion:
        collection.Count().Should().Be(1);
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
}