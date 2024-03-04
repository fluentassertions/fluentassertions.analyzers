# FluentAssertions Analyzer Docs

- [CollectionsShouldNotBeEmpty](#scenario-collectionsshouldnotbeempty) - `collection.Should().NotBeEmpty();`
- [CollectionShouldBeEmpty](#scenario-collectionshouldbeempty) - `collection.Should().BeEmpty();`
- [CollectionShouldNotContainCondition](#scenario-collectionshouldnotcontaincondition) - `collection.Should().NotContain(i => i == 4);`
- [CollectionShouldNotContainItem](#scenario-collectionshouldnotcontainitem) - `collection.Should().NotContain(4);`
- [CollectionShouldOnlyContainProperty](#scenario-collectionshouldonlycontainproperty) - `collection.Should().OnlyContain(x => x > 0);`
- [CollectionShouldContainItem](#scenario-collectionshouldcontainitem) - `collection.Should().Contain(2);`
- [CollectionShouldContainCondition](#scenario-collectionshouldcontaincondition) - `collection.Should().Contain(i => i == 2);`
- [CollectionShouldHaveCount_Count](#scenario-collectionshouldhavecount_count) - `collection.Should().HaveCount(3);`
- [CollectionShouldHaveCount_Length](#scenario-collectionshouldhavecount_length) - `collection.Should().HaveCount(3);`
- [CollectionShouldNotHaveCount_Count](#scenario-collectionshouldnothavecount_count) - `collection.Should().NotHaveCount(4);`
- [CollectionShouldContainSingle](#scenario-collectionshouldcontainsingle) - `collection.Should().ContainSingle();`
- [CollectionShouldHaveCountGreaterThan_CountShouldBeGreaterThan](#scenario-collectionshouldhavecountgreaterthan_countshouldbegreaterthan) - `collection.Should().HaveCountGreaterThan(2);`
- [CollectionShouldHaveCountGreaterOrEqualTo_CountShouldBeGreaterOrEqualTo](#scenario-collectionshouldhavecountgreaterorequalto_countshouldbegreaterorequalto) - `collection.Should().HaveCountGreaterOrEqualTo(3);`
- [CollectionShouldHaveCountLessThan_CountShouldBeLessThan](#scenario-collectionshouldhavecountlessthan_countshouldbelessthan) - `collection.Should().HaveCountLessThan(4);`
- [CollectionShouldHaveCountLessOrEqualTo_CountShouldBeLessOrEqualTo](#scenario-collectionshouldhavecountlessorequalto_countshouldbelessorequalto) - `collection.Should().HaveCountLessOrEqualTo(3);`
- [CollectionShouldHaveSameCount_ShouldHaveCountOtherCollectionCount](#scenario-collectionshouldhavesamecount_shouldhavecountothercollectioncount) - `collection.Should().HaveSameCount(otherCollection);`
- [CollectionShouldNotHaveSameCount_CountShouldNotBeOtherCollectionCount](#scenario-collectionshouldnothavesamecount_countshouldnotbeothercollectioncount) - `collection.Should().NotHaveSameCount(otherCollection);`
- [CollectionShouldContainSingle_WhereShouldHaveCount1](#scenario-collectionshouldcontainsingle_whereshouldhavecount1) - `collection.Should().ContainSingle(i => i == 1);`
- [CollectionShouldNotBeNullOrEmpty](#scenario-collectionshouldnotbenullorempty) - `collection.Should().NotBeNullOrEmpty();`


## Scenarios

### scenario: CollectionsShouldNotBeEmpty

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Any().Should().BeTrue();

// new assertion:
collection.Should().NotBeEmpty();
```

### scenario: CollectionShouldBeEmpty

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

### scenario: CollectionShouldNotContainCondition

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Any(i => i == 4).Should().BeFalse();
collection.Where(i => i == 4).Should().BeEmpty();

// new assertion:
collection.Should().NotContain(i => i == 4);
```

### scenario: CollectionShouldNotContainItem

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Contains(4).Should().BeFalse();

// new assertion:
collection.Should().NotContain(4);
```

### scenario: CollectionShouldOnlyContainProperty

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.All(x => x > 0).Should().BeTrue();
// new assertion:
collection.Should().OnlyContain(x => x > 0);
```

### scenario: CollectionShouldContainItem

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Contains(2).Should().BeTrue();
// new assertion:
collection.Should().Contain(2);
```

### scenario: CollectionShouldContainCondition

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Any(i => i == 2).Should().BeTrue();
collection.Where(i => i == 2).Should().NotBeEmpty();

// new assertion:
collection.Should().Contain(i => i == 2);
```

### scenario: CollectionShouldHaveCount_Count

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().Be(3);
// new assertion:
collection.Should().HaveCount(3);
```

### scenario: CollectionShouldHaveCount_Length

```cs
// arrange
var collection = new int[] { 1, 2, 3 };

// old assertion:
collection.Length.Should().Be(3);
// new assertion:
collection.Should().HaveCount(3);
```

### scenario: CollectionShouldNotHaveCount_Count

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().NotBe(4);
// new assertion:
collection.Should().NotHaveCount(4);
```

### scenario: CollectionShouldContainSingle

```cs
// arrange
var collection = new List<int> { 1 };

// old assertion:
collection.Count().Should().Be(1);
collection.Should().HaveCount(1);

// new assertion:
collection.Should().ContainSingle();
```

### scenario: CollectionShouldHaveCountGreaterThan_CountShouldBeGreaterThan

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().BeGreaterThan(2);
// new assertion:
collection.Should().HaveCountGreaterThan(2);
```

### scenario: CollectionShouldHaveCountGreaterOrEqualTo_CountShouldBeGreaterOrEqualTo

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().BeGreaterOrEqualTo(3);
// new assertion:
collection.Should().HaveCountGreaterOrEqualTo(3);
```

### scenario: CollectionShouldHaveCountLessThan_CountShouldBeLessThan

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().BeLessThan(4);
// new assertion:
collection.Should().HaveCountLessThan(4);
```

### scenario: CollectionShouldHaveCountLessOrEqualTo_CountShouldBeLessOrEqualTo

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().BeLessOrEqualTo(3);
// new assertion:
collection.Should().HaveCountLessOrEqualTo(3);
```

### scenario: CollectionShouldHaveSameCount_ShouldHaveCountOtherCollectionCount

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };
var otherCollection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Should().HaveCount(otherCollection.Count());
// new assertion:
collection.Should().HaveSameCount(otherCollection);
```

### scenario: CollectionShouldNotHaveSameCount_CountShouldNotBeOtherCollectionCount

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };
var otherCollection = new List<int> { 1, 2, 3, 4 };

// old assertion:
collection.Count().Should().NotBe(otherCollection.Count());
// new assertion:
collection.Should().NotHaveSameCount(otherCollection);
```

### scenario: CollectionShouldContainSingle_WhereShouldHaveCount1

```cs
// arrange
var collection = new List<int> { 1 };

// old assertion:
collection.Where(i => i == 1).Should().HaveCount(1);
// new assertion:
collection.Should().ContainSingle(i => i == 1);
```

### scenario: CollectionShouldNotBeNullOrEmpty

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Should().NotBeEmpty().And.NotBeNull();
collection.Should().NotBeNull().And.NotBeEmpty();

// new assertion:
collection.Should().NotBeNullOrEmpty();
```


