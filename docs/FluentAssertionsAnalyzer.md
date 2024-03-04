# FluentAssertions Analyzer Docs
## method: CollectionsShouldNotBeEmpty

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Any().Should().BeTrue();

// new assertion:
collection.Should().NotBeEmpty();
```

## method: CollectionShouldBeEmpty

```cs
// arrange
var collection = new List<int>();

// old assertion:
collection.Any().Should().BeFalse();
collection.Count().Should().Be(0);
collection.Should().HaveCount(0);

// new assertion:
collection.Should().BeEmpty();
```

## method: CollectionShouldNotContainCondition

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Any(i => i == 4).Should().BeFalse();
collection.Where(i => i == 4).Should().BeEmpty();

// new assertion:
collection.Should().NotContain(i => i == 4);
```

## method: CollectionShouldNotContainItem

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Contains(4).Should().BeFalse();

// new assertion:
collection.Should().NotContain(4);
```

## method: CollectionShouldOnlyContainProperty

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.All(x => x > 0).Should().BeTrue();
// new assertion:
collection.Should().OnlyContain(x => x > 0);
```

## method: CollectionShouldContainItem

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Contains(2).Should().BeTrue();
// new assertion:
collection.Should().Contain(2);
```

## method: CollectionShouldContainCondition

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Any(i => i == 2).Should().BeTrue();
collection.Where(i => i == 2).Should().NotBeEmpty();

// new assertion:
collection.Should().Contain(i => i == 2);
```

## method: CollectionShouldHaveCount_Count

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().Be(3);
// new assertion:
collection.Should().HaveCount(3);
```

## method: CollectionShouldHaveCount_Length

```cs
// arrange
var collection = new int[] { 1, 2, 3 };

// old assertion:
collection.Length.Should().Be(3);
// new assertion:
collection.Should().HaveCount(3);
```

## method: CollectionShouldNotHaveCount_Count

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().NotBe(4);
// new assertion:
collection.Should().NotHaveCount(4);
```

## method: CollectionShouldContainSingle_CountShouldBe1

```cs
// arrange
var collection = new List<int> { 1 };

// old assertion:
collection.Count().Should().Be(1);
collection.Should().HaveCount(1);

// new assertion:
collection.Should().ContainSingle();
```

## method: CollectionShouldHaveCountGreaterThan_CountShouldBeGreaterThan

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().BeGreaterThan(2);
// new assertion:
collection.Should().HaveCountGreaterThan(2);
```

## method: CollectionShouldHaveCountGreaterOrEqualTo_CountShouldBeGreaterOrEqualTo

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().BeGreaterOrEqualTo(3);
// new assertion:
collection.Should().HaveCountGreaterOrEqualTo(3);
```

## method: CollectionShouldHaveCountLessThan_CountShouldBeLessThan

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().BeLessThan(4);
// new assertion:
collection.Should().HaveCountLessThan(4);
```

## method: CollectionShouldHaveCountLessOrEqualTo_CountShouldBeLessOrEqualTo

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().BeLessOrEqualTo(3);
// new assertion:
collection.Should().HaveCountLessOrEqualTo(3);
```

## method: CollectionShouldHaveSameCount_ShouldHaveCountOtherCollectionCount

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };
var otherCollection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Should().HaveCount(otherCollection.Count());
// new assertion:
collection.Should().HaveSameCount(otherCollection);
```

## method: CollectionShouldNotHaveSameCount_CountShouldNotBeOtherCollectionCount

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };
var otherCollection = new List<int> { 1, 2, 3, 4 };

// old assertion:
collection.Count().Should().NotBe(otherCollection.Count());
// new assertion:
collection.Should().NotHaveSameCount(otherCollection);
```

## method: CollectionShouldContainSingle_WhereShouldHaveCount1

```cs
// arrange
var collection = new List<int> { 1 };

// old assertion:
collection.Where(i => i == 1).Should().HaveCount(1);
// new assertion:
collection.Should().ContainSingle(i => i == 1);
```

## method: CollectionShouldNotBeNullOrEmpty

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Should().NotBeEmpty().And.NotBeNull();
collection.Should().NotBeNull().And.NotBeEmpty();

// new assertion:
collection.Should().NotBeNullOrEmpty();
```

