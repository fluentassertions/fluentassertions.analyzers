<!--
This is a generated file, please edit src\FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator\DocsGenerator.cs to change the contents
-->

# FluentAssertions Analyzer Docs

- [CollectionShouldNotBeEmpty](#scenario-collectionshouldnotbeempty) - `collection.Should().NotBeEmpty();`
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
- [DictionaryShouldContainKey](#scenario-dictionaryshouldcontainkey) - `dictionary.Should().ContainKey("two");`
- [DictionaryShouldNotContainKey](#scenario-dictionaryshouldnotcontainkey) - `dictionary.Should().NotContainKey("four");`
- [DictionaryShouldContainValue](#scenario-dictionaryshouldcontainvalue) - `dictionary.Should().ContainValue(2);`
- [DictionaryShouldNotContainValue](#scenario-dictionaryshouldnotcontainvalue) - `dictionary.Should().NotContainValue(4);`
- [DictionaryShouldContainKeyAndValue](#scenario-dictionaryshouldcontainkeyandvalue) - `dictionary.Should().Contain("two", 2);`
- [DictionaryShouldContainPair](#scenario-dictionaryshouldcontainpair) - `dictionary.Should().Contain(pair);`
- [ExceptionShouldThrowWithMessage_Be](#scenario-exceptionshouldthrowwithmessage_be) - `action.Should().Throw<Exception>().WithMessage("message");`
- [ExceptionShouldThrowWithMessage_Contain](#scenario-exceptionshouldthrowwithmessage_contain) - `action.Should().Throw<Exception>().WithMessage("*mess*");`
- [ExceptionShouldThrowWithMessage_EndWith](#scenario-exceptionshouldthrowwithmessage_endwith) - `action.Should().Throw<Exception>().WithMessage("*age");`
- [ExceptionShouldThrowWithMessage_StartWith](#scenario-exceptionshouldthrowwithmessage_startwith) - `action.Should().Throw<Exception>().WithMessage("mes*");`
- [ExceptionShouldThrowExactlyWithMessage_Be](#scenario-exceptionshouldthrowexactlywithmessage_be) - `action.Should().ThrowExactly<ArgumentException>().WithMessage("message");`
- [ExceptionShouldThrowExactlyWithMessage_Contain](#scenario-exceptionshouldthrowexactlywithmessage_contain) - `action.Should().ThrowExactly<ArgumentException>().WithMessage("*mess*");`
- [ExceptionShouldThrowExactlyWithMessage_EndWith](#scenario-exceptionshouldthrowexactlywithmessage_endwith) - `action.Should().ThrowExactly<ArgumentException>().WithMessage("*age");`
- [ExceptionShouldThrowExactlyWithMessage_StartWith](#scenario-exceptionshouldthrowexactlywithmessage_startwith) - `action.Should().ThrowExactly<ArgumentException>().WithMessage("mes*");`
- [ExceptionShouldThrowExactlyWithInnerExceptionExactly_BeOfType](#scenario-exceptionshouldthrowexactlywithinnerexceptionexactly_beoftype) - `action.Should().ThrowExactly<ArgumentException>().WithInnerExceptionExactly<InvalidOperationException>();`
- [ExceptionShouldThrowWithInnerExceptionExactly_BeOfType](#scenario-exceptionshouldthrowwithinnerexceptionexactly_beoftype) - `action.Should().Throw<ArgumentException>().WithInnerExceptionExactly<InvalidOperationException>();`
- [ExceptionShouldThrowExactlyWithInnerException_BeAssignableTo](#scenario-exceptionshouldthrowexactlywithinnerexception_beassignableto) - `action.Should().ThrowExactly<ArgumentException>().WithInnerException<InvalidOperationException>();`


## Scenarios

### scenario: CollectionShouldNotBeEmpty

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
var otherCollection = new List<int> { 2, 3, 4, 5 };

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
var otherCollection = new List<int> { 4, 5, 6 };

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

### scenario: DictionaryShouldContainKey

```cs
// arrange
var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

// old assertion:
dictionary.ContainsKey("two").Should().BeTrue();

// new assertion:
dictionary.Should().ContainKey("two");
```

#### Failure messages

```cs
// arrange
var dictionary = new Dictionary<string, int> { ["one"] = 1, ["three"] = 3 };

// old assertion:
dictionary.ContainsKey("two").Should().BeTrue(); 	// fail message: Expected dictionary.ContainsKey("two") to be true, but found False.

// new assertion:
dictionary.Should().ContainKey("two"); 	// fail message: Expected dictionary {["one"] = 1, ["three"] = 3} to contain key "two".
```

### scenario: DictionaryShouldNotContainKey

```cs
// arrange
var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

// old assertion:
dictionary.ContainsKey("four").Should().BeFalse();

// new assertion:
dictionary.Should().NotContainKey("four");
```

#### Failure messages

```cs
// arrange
var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3, ["four"] = 4 };

// old assertion:
dictionary.ContainsKey("four").Should().BeFalse(); 	// fail message: Expected dictionary.ContainsKey("four") to be false, but found True.

// new assertion:
dictionary.Should().NotContainKey("four"); 	// fail message: Expected dictionary {["one"] = 1, ["two"] = 2, ["three"] = 3, ["four"] = 4} not to contain key "four", but found it anyhow.
```

### scenario: DictionaryShouldContainValue

```cs
// arrange
var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

// old assertion:
dictionary.ContainsValue(2).Should().BeTrue();

// new assertion:
dictionary.Should().ContainValue(2);
```

#### Failure messages

```cs
// arrange
var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

// old assertion:
dictionary.ContainsValue(4).Should().BeTrue(); 	// fail message: Expected dictionary.ContainsValue(4) to be true, but found False.

// new assertion:
dictionary.Should().ContainValue(4); 	// fail message: Expected dictionary {["one"] = 1, ["two"] = 2, ["three"] = 3} to contain value 4.
```

### scenario: DictionaryShouldNotContainValue

```cs
// arrange
var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

// old assertion:
dictionary.ContainsValue(4).Should().BeFalse();

// new assertion:
dictionary.Should().NotContainValue(4);
```

#### Failure messages

```cs
// arrange
var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3, ["four"] = 4 };

// old assertion:
dictionary.ContainsValue(4).Should().BeFalse(); 	// fail message: Expected dictionary.ContainsValue(4) to be false, but found True.

// new assertion:
dictionary.Should().NotContainValue(4); 	// fail message: Expected dictionary {["one"] = 1, ["two"] = 2, ["three"] = 3, ["four"] = 4} not to contain value 4, but found it anyhow.
```

### scenario: DictionaryShouldContainKeyAndValue

```cs
// arrange
var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

// old assertion:
dictionary.Should().ContainKey("two").And.ContainValue(2);

// new assertion:
dictionary.Should().Contain("two", 2);
```

#### Failure messages

```cs
// arrange
var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };

// old assertion:
dictionary.Should().ContainKey("two").And.ContainValue(4); 	// fail message: Expected dictionary {["one"] = 1, ["two"] = 2, ["three"] = 3} to contain value 4.

// new assertion:
dictionary.Should().Contain("two", 4); 	// fail message: Expected dictionary to contain value 4 at key "two", but found 2.
```

### scenario: DictionaryShouldContainPair

```cs
// arrange
var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };
var pair = new KeyValuePair<string, int>("two", 2);

// old assertion:
dictionary.Should().ContainKey(pair.Key).And.ContainValue(pair.Value);

// new assertion:
dictionary.Should().Contain(pair);
```

#### Failure messages

```cs
// arrange
var dictionary = new Dictionary<string, int> { ["one"] = 1, ["two"] = 2, ["three"] = 3 };
var pair = new KeyValuePair<string, int>("two", 4);

// old assertion:
dictionary.Should().ContainKey(pair.Key).And.ContainValue(pair.Value); 	// fail message: Expected dictionary {["one"] = 1, ["two"] = 2, ["three"] = 3} to contain value 4.

// new assertion:
dictionary.Should().Contain(pair); 	// fail message: Expected dictionary to contain value 4 at key "two", but found 2.
```

### scenario: ExceptionShouldThrowWithMessage_Be

```cs
// arrange
static void ThrowException() => throw new Exception("message");
Action action = ThrowException;

// old assertion:
action.Should().Throw<Exception>().And.Message.Should().Be("message");
action.Should().Throw<Exception>().Which.Message.Should().Be("message");

// new assertion:
action.Should().Throw<Exception>().WithMessage("message");
```

#### Failure messages

```cs
// arrange
static void ThrowException() => throw new Exception("wrong");
Action action = ThrowException;

// old assertion:
action.Should().Throw<Exception>().And.Message.Should().Be("message"); 	// fail message: Expected action to be "message" with a length of 7, but "wrong" has a length of 5, differs near "wro" (index 0).
action.Should().Throw<Exception>().Which.Message.Should().Be("message"); 	// fail message: Expected action to be "message" with a length of 7, but "wrong" has a length of 5, differs near "wro" (index 0).

// new assertion:
action.Should().Throw<Exception>().WithMessage("message"); 	// fail message: Expected exception message to match the equivalent of "message", but "wrong" does not.
```

### scenario: ExceptionShouldThrowWithMessage_Contain

```cs
// arrange
static void ThrowException() => throw new Exception("message");
Action action = ThrowException;

// old assertion:
action.Should().Throw<Exception>().And.Message.Should().Contain("mess");
action.Should().Throw<Exception>().Which.Message.Should().Contain("mess");

// new assertion:
action.Should().Throw<Exception>().WithMessage("*mess*");
```

#### Failure messages

```cs
// arrange
static void ThrowException() => throw new Exception("wrong");
Action action = ThrowException;

// old assertion:
action.Should().Throw<Exception>().And.Message.Should().Contain("mess"); 	// fail message: Expected action "wrong" to contain "mess".
action.Should().Throw<Exception>().Which.Message.Should().Contain("mess"); 	// fail message: Expected action "wrong" to contain "mess".

// new assertion:
action.Should().Throw<Exception>().WithMessage("*mess*"); 	// fail message: Expected exception message to match the equivalent of "*mess*", but "wrong" does not.
```

### scenario: ExceptionShouldThrowWithMessage_EndWith

```cs
// arrange
static void ThrowException() => throw new Exception("message");
Action action = ThrowException;

// old assertion:
action.Should().Throw<Exception>().And.Message.Should().EndWith("age");
action.Should().Throw<Exception>().Which.Message.Should().EndWith("age");

// new assertion:
action.Should().Throw<Exception>().WithMessage("*age");
```

#### Failure messages

```cs
// arrange
static void ThrowException() => throw new Exception("wrong");
Action action = ThrowException;

// old assertion:
action.Should().Throw<Exception>().And.Message.Should().EndWith("age"); 	// fail message: Expected action "wrong" to end with "age".
action.Should().Throw<Exception>().Which.Message.Should().EndWith("age"); 	// fail message: Expected action "wrong" to end with "age".

// new assertion:
action.Should().Throw<Exception>().WithMessage("*age"); 	// fail message: Expected exception message to match the equivalent of "*age", but "wrong" does not.
```

### scenario: ExceptionShouldThrowWithMessage_StartWith

```cs
// arrange
static void ThrowException() => throw new Exception("message");
Action action = ThrowException;

// old assertion:
action.Should().Throw<Exception>().And.Message.Should().StartWith("mes");
action.Should().Throw<Exception>().Which.Message.Should().StartWith("mes");

// new assertion:
action.Should().Throw<Exception>().WithMessage("mes*");
```

#### Failure messages

```cs
// arrange
static void ThrowException() => throw new Exception("wrong");
Action action = ThrowException;

// old assertion:
action.Should().Throw<Exception>().And.Message.Should().StartWith("mes"); 	// fail message: Expected action to start with "mes", but "wrong" differs near "wro" (index 0).
action.Should().Throw<Exception>().Which.Message.Should().StartWith("mes"); 	// fail message: Expected action to start with "mes", but "wrong" differs near "wro" (index 0).

// new assertion:
action.Should().Throw<Exception>().WithMessage("mes*"); 	// fail message: Expected exception message to match the equivalent of "mes*", but "wrong" does not.
```

### scenario: ExceptionShouldThrowExactlyWithMessage_Be

```cs
// arrange
static void ThrowException() => throw new ArgumentException("message");
Action action = ThrowException;

// old assertion:
action.Should().ThrowExactly<ArgumentException>().And.Message.Should().Be("message");
action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().Be("message");

// new assertion:
action.Should().ThrowExactly<ArgumentException>().WithMessage("message");
```

#### Failure messages

```cs
// arrange
static void ThrowException() => throw new ArgumentException("wrong");
Action action = ThrowException;

// old assertion:
action.Should().ThrowExactly<ArgumentException>().And.Message.Should().Be("message"); 	// fail message: Expected action to be "message" with a length of 7, but "wrong" has a length of 5, differs near "wro" (index 0).
action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().Be("message"); 	// fail message: Expected action to be "message" with a length of 7, but "wrong" has a length of 5, differs near "wro" (index 0).

// new assertion:
action.Should().ThrowExactly<ArgumentException>().WithMessage("message"); 	// fail message: Expected exception message to match the equivalent of "message", but "wrong" does not.
```

### scenario: ExceptionShouldThrowExactlyWithMessage_Contain

```cs
// arrange
static void ThrowException() => throw new ArgumentException("message");
Action action = ThrowException;

// old assertion:
action.Should().ThrowExactly<ArgumentException>().And.Message.Should().Contain("mess");
action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().Contain("mess");

// new assertion:
action.Should().ThrowExactly<ArgumentException>().WithMessage("*mess*");
```

#### Failure messages

```cs
// arrange
static void ThrowException() => throw new ArgumentException("wrong");
Action action = ThrowException;

// old assertion:
action.Should().ThrowExactly<ArgumentException>().And.Message.Should().Contain("mess"); 	// fail message: Expected action "wrong" to contain "mess".
action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().Contain("mess"); 	// fail message: Expected action "wrong" to contain "mess".

// new assertion:
action.Should().ThrowExactly<ArgumentException>().WithMessage("*mess*"); 	// fail message: Expected exception message to match the equivalent of "*mess*", but "wrong" does not.
```

### scenario: ExceptionShouldThrowExactlyWithMessage_EndWith

```cs
// arrange
static void ThrowException() => throw new ArgumentException("message");
Action action = ThrowException;

// old assertion:
action.Should().ThrowExactly<ArgumentException>().And.Message.Should().EndWith("age");
action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().EndWith("age");

// new assertion:
action.Should().ThrowExactly<ArgumentException>().WithMessage("*age");
```

#### Failure messages

```cs
// arrange
static void ThrowException() => throw new ArgumentException("wrong");
Action action = ThrowException;

// old assertion:
action.Should().ThrowExactly<ArgumentException>().And.Message.Should().EndWith("age"); 	// fail message: Expected action "wrong" to end with "age".
action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().EndWith("age"); 	// fail message: Expected action "wrong" to end with "age".

// new assertion:
action.Should().ThrowExactly<ArgumentException>().WithMessage("*age"); 	// fail message: Expected exception message to match the equivalent of "*age", but "wrong" does not.
```

### scenario: ExceptionShouldThrowExactlyWithMessage_StartWith

```cs
// arrange
static void ThrowException() => throw new ArgumentException("message");
Action action = ThrowException;

// old assertion:
action.Should().ThrowExactly<ArgumentException>().And.Message.Should().StartWith("mes");
action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().StartWith("mes");

// new assertion:
action.Should().ThrowExactly<ArgumentException>().WithMessage("mes*");
```

#### Failure messages

```cs
// arrange
static void ThrowException() => throw new ArgumentException("wrong");
Action action = ThrowException;

// old assertion:
action.Should().ThrowExactly<ArgumentException>().And.Message.Should().StartWith("mes"); 	// fail message: Expected action to start with "mes", but "wrong" differs near "wro" (index 0).
action.Should().ThrowExactly<ArgumentException>().Which.Message.Should().StartWith("mes"); 	// fail message: Expected action to start with "mes", but "wrong" differs near "wro" (index 0).

// new assertion:
action.Should().ThrowExactly<ArgumentException>().WithMessage("mes*"); 	// fail message: Expected exception message to match the equivalent of "mes*", but "wrong" does not.
```

### scenario: ExceptionShouldThrowExactlyWithInnerExceptionExactly_BeOfType

```cs
// arrange
static void ThrowException() => throw new ArgumentException("message", new InvalidOperationException());
Action action = ThrowException;

// old assertion:
action.Should().ThrowExactly<ArgumentException>().And.InnerException.Should().BeOfType<InvalidOperationException>();
action.Should().ThrowExactly<ArgumentException>().Which.InnerException.Should().BeOfType<InvalidOperationException>();

// new assertion:
action.Should().ThrowExactly<ArgumentException>().WithInnerExceptionExactly<InvalidOperationException>();
```

#### Failure messages

```cs
// arrange
static void ThrowException() => throw new ArgumentException("message", new InvalidOperationException());
Action action = ThrowException;

// old assertion:
action.Should().ThrowExactly<ArgumentException>().And.InnerException.Should().BeOfType<ArgumentException>(); 	// fail message: Expected type to be System.ArgumentException, but found System.InvalidOperationException.
action.Should().ThrowExactly<ArgumentException>().Which.InnerException.Should().BeOfType<ArgumentException>(); 	// fail message: Expected type to be System.ArgumentException, but found System.InvalidOperationException.

// new assertion:
action.Should().ThrowExactly<ArgumentException>().WithInnerExceptionExactly<ArgumentException>(); 	// fail message: Expected inner System.ArgumentException, but found System.InvalidOperationException: Operation is not valid due to the current state of the object..
```

### scenario: ExceptionShouldThrowWithInnerExceptionExactly_BeOfType

```cs
// arrange
static void ThrowException() => throw new ArgumentException("message", new InvalidOperationException());
Action action = ThrowException;

// old assertion:
action.Should().Throw<ArgumentException>().And.InnerException.Should().BeOfType<InvalidOperationException>();
action.Should().Throw<ArgumentException>().Which.InnerException.Should().BeOfType<InvalidOperationException>();

// new assertion:
action.Should().Throw<ArgumentException>().WithInnerExceptionExactly<InvalidOperationException>();
```

#### Failure messages

```cs
// arrange
static void ThrowException() => throw new ArgumentException("message", new InvalidOperationException());
Action action = ThrowException;

// old assertion:
action.Should().Throw<ArgumentException>().And.InnerException.Should().BeOfType<ArgumentException>(); 	// fail message: Expected type to be System.ArgumentException, but found System.InvalidOperationException.
action.Should().Throw<ArgumentException>().Which.InnerException.Should().BeOfType<ArgumentException>(); 	// fail message: Expected type to be System.ArgumentException, but found System.InvalidOperationException.

// new assertion:
action.Should().Throw<ArgumentException>().WithInnerExceptionExactly<ArgumentException>(); 	// fail message: Expected inner System.ArgumentException, but found System.InvalidOperationException: Operation is not valid due to the current state of the object..
```

### scenario: ExceptionShouldThrowExactlyWithInnerException_BeAssignableTo

```cs
// arrange
static void ThrowException() => throw new ArgumentException("message", new InvalidOperationException());
Action action = ThrowException;

// old assertion:
action.Should().ThrowExactly<ArgumentException>().And.InnerException.Should().BeAssignableTo<InvalidOperationException>();
action.Should().ThrowExactly<ArgumentException>().Which.InnerException.Should().BeAssignableTo<InvalidOperationException>();

// new assertion:
action.Should().ThrowExactly<ArgumentException>().WithInnerException<InvalidOperationException>();
```

#### Failure messages

```cs
// arrange
static void ThrowException() => throw new ArgumentException("message", new InvalidOperationException());
Action action = ThrowException;

// old assertion:
action.Should().ThrowExactly<ArgumentException>().And.InnerException.Should().BeAssignableTo<ArgumentException>(); 	// fail message: Expected action to be assignable to System.ArgumentException, but System.InvalidOperationException is not.
action.Should().ThrowExactly<ArgumentException>().Which.InnerException.Should().BeAssignableTo<ArgumentException>(); 	// fail message: Expected action to be assignable to System.ArgumentException, but System.InvalidOperationException is not.

// new assertion:
action.Should().ThrowExactly<ArgumentException>().WithInnerException<ArgumentException>(); 	// fail message: Expected inner System.ArgumentException, but found System.InvalidOperationException: Operation is not valid due to the current state of the object..
```


