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

#### Failure messages

```cs
// arrange
var collection = new List<int> { };

// old assertion:
collection.Any().Should().BeTrue(); 	// fail message: Expected collection.Any() to be true, but found False.

// new assertion:
collection.Should().NotBeEmpty(); 	// fail message: Expected collection not to be empty.
```

### scenario: CollectionShouldBeEmpty

```cs
// arrange
var collection = new List<int>();

// old assertion:
collection.Any().Should().BeFalse();
collection.Count().Should().Be(0);
collection.Count.Should().Be(0);
collection.Should().HaveCount(0);

// new assertion:
collection.Should().BeEmpty();
```

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Any().Should().BeFalse(); 	// fail message: Expected collection.Any() to be false, but found True.
collection.Count().Should().Be(0); 	// fail message: Expected collection.Count() to be 0, but found 3 (difference of 3).
collection.Count.Should().Be(0); 	// fail message: Expected collection.Count to be 0, but found 3 (difference of 3).
collection.Should().HaveCount(0); 	// fail message: Expected collection to contain 0 item(s), but found 3: {1, 2, 3}.

// new assertion:
collection.Should().BeEmpty(); 	// fail message: Expected collection to be empty, but found {1, 2, 3}.
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

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 2, 3, 4, 5 };

// old assertion:
collection.Any(i => i == 4).Should().BeFalse(); 	// fail message: Expected collection.Any(i => i == 4) to be false, but found True.
collection.Where(i => i == 4).Should().BeEmpty(); 	// fail message: Expected collection.Where(i => i == 4) to be empty, but found {4}.

// new assertion:
collection.Should().NotContain(i => i == 4); 	// fail message: Expected collection {1, 2, 3, 4, 5} to not have any items matching (i == 4), but found {4}.
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

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 2, 3, 4, 5 };

// old assertion:
collection.Contains(4).Should().BeFalse(); 	// fail message: Expected collection.Contains(4) to be false, but found True.

// new assertion:
collection.Should().NotContain(4); 	// fail message: Expected collection {1, 2, 3, 4, 5} to not contain 4.
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

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 2, 3, -1 };

// old assertion:
collection.All(x => x > 0).Should().BeTrue(); 	// fail message: Expected collection.All(x => x > 0) to be true, but found False.

// new assertion:
collection.Should().OnlyContain(x => x > 0); 	// fail message: Expected collection to contain only items matching (x > 0), but {-1} do(es) not match.
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

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 3, 4, 5 };

// old assertion:
collection.Contains(2).Should().BeTrue(); 	// fail message: Expected collection.Contains(2) to be true, but found False.

// new assertion:
collection.Should().Contain(2); 	// fail message: Expected collection {1, 3, 4, 5} to contain 2.
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

#### Failure messages

```cs
// arrange
var collection = new List<int> { 3, 4, 5 };

// old assertion:
collection.Any(i => i == 2).Should().BeTrue(); 	// fail message: Expected collection.Any(i => i == 2) to be true, but found False.
collection.Where(i => i == 2).Should().NotBeEmpty(); 	// fail message: Expected collection.Where(i => i == 2) not to be empty.

// new assertion:
collection.Should().Contain(i => i == 2); 	// fail message: Expected collection {3, 4, 5} to have an item matching (i == 2).
```

### scenario: CollectionShouldHaveCount_Count

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().Be(3);
collection.Count.Should().Be(3);

// new assertion:
collection.Should().HaveCount(3);
```

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 2, 3, 4, 5 };

// old assertion:
collection.Count().Should().Be(3); 	// fail message: Expected collection.Count() to be 3, but found 5.
collection.Count.Should().Be(3); 	// fail message: Expected collection.Count to be 3, but found 5.

// new assertion:
collection.Should().HaveCount(3); 	// fail message: Expected collection to contain 3 item(s), but found 5: {1, 2, 3, 4, 5}.
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

#### Failure messages

```cs
// arrange
var collection = new int[] { 1, 2, 3, 4, 5 };

// old assertion:
collection.Length.Should().Be(3); 	// fail message: Expected collection.Length to be 3, but found 5.

// new assertion:
collection.Should().HaveCount(3); 	// fail message: Expected collection to contain 3 item(s), but found 5: {1, 2, 3, 4, 5}.
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

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 2, 3, 4 };

// old assertion:
collection.Count().Should().NotBe(4); 	// fail message: Did not expect collection.Count() to be 4.

// new assertion:
collection.Should().NotHaveCount(4); 	// fail message: Expected collection to not contain 4 item(s), but found 4.
```

### scenario: CollectionShouldContainSingle

```cs
// arrange
var collection = new List<int> { 1 };

// old assertion:
collection.Count().Should().Be(1);
collection.Count.Should().Be(1);
collection.Should().HaveCount(1);

// new assertion:
collection.Should().ContainSingle();
```

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().Be(1); 	// fail message: Expected collection.Count() to be 1, but found 3.
collection.Count.Should().Be(1); 	// fail message: Expected collection.Count to be 1, but found 3.
collection.Should().HaveCount(1); 	// fail message: Expected collection to contain 1 item(s), but found 3: {1, 2, 3}.

// new assertion:
collection.Should().ContainSingle(); 	// fail message: Expected collection to contain a single item, but found {1, 2, 3}.
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

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1 };

// old assertion:
collection.Count().Should().BeGreaterThan(2); 	// fail message: Expected collection.Count() to be greater than 2, but found 1.

// new assertion:
collection.Should().HaveCountGreaterThan(2); 	// fail message: Expected collection to contain more than 2 item(s), but found 1: {1}.
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

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 2 };

// old assertion:
collection.Count().Should().BeGreaterOrEqualTo(3); 	// fail message: Expected collection.Count() to be greater than or equal to 3, but found 2.

// new assertion:
collection.Should().HaveCountGreaterOrEqualTo(3); 	// fail message: Expected collection to contain at least 3 item(s), but found 2: {1, 2}.
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

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 2, 3, 4, 5 };

// old assertion:
collection.Count().Should().BeLessThan(4); 	// fail message: Expected collection.Count() to be less than 4, but found 5.

// new assertion:
collection.Should().HaveCountLessThan(4); 	// fail message: Expected collection to contain fewer than 4 item(s), but found 5: {1, 2, 3, 4, 5}.
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

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 2, 3, 4 };

// old assertion:
collection.Count().Should().BeLessOrEqualTo(3); 	// fail message: Expected collection.Count() to be less than or equal to 3, but found 4.

// new assertion:
collection.Should().HaveCountLessOrEqualTo(3); 	// fail message: Expected collection to contain at most 3 item(s), but found 4: {1, 2, 3, 4}.
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

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Should().HaveCount(otherCollection.Count()); 	// fail message: Expected collection to contain 4 item(s), but found 3: {1, 2, 3}.

// new assertion:
collection.Should().HaveSameCount(otherCollection); 	// fail message: Expected collection to have 4 item(s), but found 3.
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

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Count().Should().NotBe(otherCollection.Count()); 	// fail message: Did not expect collection.Count() to be 3.

// new assertion:
collection.Should().NotHaveSameCount(otherCollection); 	// fail message: Expected collection to not have 3 item(s), but found 3.
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

#### Failure messages

```cs
// arrange
var collection = new List<int> { 1, 2, 3, 1 };

// old assertion:
collection.Where(i => i == 1).Should().HaveCount(1); 	// fail message: Expected collection.Where(i => i == 1) to contain 1 item(s), but found 2: {1, 1}.

// new assertion:
collection.Should().ContainSingle(i => i == 1); 	// fail message: Expected collection to contain a single item matching (i == 1), but 2 such items were found.
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

#### Failure messages

```cs
// arrange
var collection = new List<int>();

// old assertion:
collection.Should().NotBeEmpty().And.NotBeNull(); 	// fail message: Expected collection not to be empty.
collection.Should().NotBeNull().And.NotBeEmpty(); 	// fail message: Expected collection not to be empty.

// new assertion:
collection.Should().NotBeNullOrEmpty(); 	// fail message: Expected collection not to be empty.
```


