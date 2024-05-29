<!--
This is a generated file, please edit src\FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator\DocsGenerator.cs to change the contents
-->

# Nunit4 Analyzer Docs

- [AssertIsTrue](#scenario-assertistrue) - `flag.Should().BeTrue();`
- [AssertIsFalse](#scenario-assertisfalse) - `flag.Should().BeFalse();`
- [AssertNull](#scenario-assertnull) - `obj.Should().BeNull();`
- [AssertNotNull](#scenario-assertnotnull) - `obj.Should().NotBeNull();`
- [AssertIsEmpty](#scenario-assertisempty) - `collection.Should().BeEmpty();`
- [AssertIsNotEmpty](#scenario-assertisnotempty) - `collection.Should().NotBeEmpty();`
- [AssertZero](#scenario-assertzero) - `number.Should().Be(0);`
- [AssertNotZero](#scenario-assertnotzero) - `number.Should().NotBe(0);`
- [AssertAreSame](#scenario-assertaresame) - `obj1.Should().BeSameAs(obj2);`
- [AssertAreNotSame](#scenario-assertarenotsame) - `obj1.Should().NotBeSameAs(obj2);`
- [AssertGreater](#scenario-assertgreater) - `number.Should().BeGreaterThan(1);`
- [AssertGreaterOrEqual](#scenario-assertgreaterorequal) - `number.Should().BeGreaterOrEqualTo(1);`
- [AssertLess](#scenario-assertless) - `number.Should().BeLessThan(2);`
- [AssertLessOrEqual](#scenario-assertlessorequal) - `number.Should().BeLessOrEqualTo(2);`
- [CollectionAssertAreEqual](#scenario-collectionassertareequal) - `collection.Should().Equal(expected);`
- [CollectionAssertAreNotEqual](#scenario-collectionassertarenotequal) - `collection.Should().NotEqual(expected);`
- [CollectionAssertContains](#scenario-collectionassertcontains) - `collection.Should().Contain(2);`
- [CollectionAssertContains_WithCasting](#scenario-collectionassertcontains_withcasting) - `collection.Should().Contain((int)item);`
- [CollectionAssertDoesNotContain](#scenario-collectionassertdoesnotcontain) - `collection.Should().NotContain(4);`
- [CollectionAssertDoesNotContain_WithCasting](#scenario-collectionassertdoesnotcontain_withcasting) - `collection.Should().NotContain((int)item);`
- [CollectionAssertAllItemsAreInstancesOfType](#scenario-collectionassertallitemsareinstancesoftype) - `collection.Should().AllBeOfType<int>();`
- [CollectionAssertAllItemsAreInstancesOfType_WithTypeArgument](#scenario-collectionassertallitemsareinstancesoftype_withtypeargument) - `collection.Should().AllBeOfType(type);`
- [CollectionAssertAllItemsAreNotNull](#scenario-collectionassertallitemsarenotnull) - `collection.Should().NotContainNulls();`
- [CollectionAssertAllItemsAreUnique](#scenario-collectionassertallitemsareunique) - `collection.Should().OnlyHaveUniqueItems();`


## Scenarios

### scenario: AssertIsTrue

```cs
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
```

#### Failure messages

```cs
var flag = false;

// old assertion:
ClassicAssert.True(flag); /* fail message:   Assert.That(condition, Is.True)
  Expected: True
  But was:  False
 */
ClassicAssert.IsTrue(flag); /* fail message:   Assert.That(condition, Is.True)
  Expected: True
  But was:  False
 */
Assert.That(flag); /* fail message:   Assert.That(flag, Is.True)
  Expected: True
  But was:  False
 */
Assert.That(flag, Is.True); /* fail message:   Assert.That(flag, Is.True)
  Expected: True
  But was:  False
 */
Assert.That(flag, Is.Not.False); /* fail message:   Assert.That(flag, Is.Not.False)
  Expected: not False
  But was:  False
 */

// new assertion:
flag.Should().BeTrue(); /* fail message: Expected flag to be true, but found False. */
```

### scenario: AssertIsFalse

```cs
// arrange
var flag = false;

// old assertion:
ClassicAssert.IsFalse(flag);
ClassicAssert.False(flag);
Assert.That(flag, Is.False);
Assert.That(flag, Is.Not.True);

// new assertion:
flag.Should().BeFalse();
```

#### Failure messages

```cs
var flag = true;

// old assertion:
ClassicAssert.False(flag); /* fail message:   Assert.That(condition, Is.False)
  Expected: False
  But was:  True
 */
ClassicAssert.IsFalse(flag); /* fail message:   Assert.That(condition, Is.False)
  Expected: False
  But was:  True
 */
Assert.That(flag, Is.False); /* fail message:   Assert.That(flag, Is.False)
  Expected: False
  But was:  True
 */
Assert.That(flag, Is.Not.True); /* fail message:   Assert.That(flag, Is.Not.True)
  Expected: not True
  But was:  True
 */

// new assertion:
flag.Should().BeFalse(); /* fail message: Expected flag to be false, but found True. */
```

### scenario: AssertNull

```cs
// arrange
object obj = null;

// old assertion:
ClassicAssert.IsNull(obj);
ClassicAssert.Null(obj);
Assert.That(obj, Is.Null);

// new assertion:
obj.Should().BeNull();
```

#### Failure messages

```cs
object obj = "foo";

// old assertion:
ClassicAssert.Null(obj); /* fail message:   Assert.That(anObject, Is.Null)
  Expected: null
  But was:  "foo"
 */
ClassicAssert.IsNull(obj); /* fail message:   Assert.That(anObject, Is.Null)
  Expected: null
  But was:  "foo"
 */
Assert.That(obj, Is.Null); /* fail message:   Assert.That(obj, Is.Null)
  Expected: null
  But was:  "foo"
 */

// new assertion:
obj.Should().BeNull(); /* fail message: Expected obj to be <null>, but found "foo". */
```

### scenario: AssertNotNull

```cs
// arrange
object obj = "foo";

// old assertion:
ClassicAssert.IsNotNull(obj);
ClassicAssert.NotNull(obj);
Assert.That(obj, Is.Not.Null);

// new assertion:
obj.Should().NotBeNull();
```

#### Failure messages

```cs
object obj = null;

// old assertion:
ClassicAssert.NotNull(obj); /* fail message:   Assert.That(anObject, Is.Not.Null)
  Expected: not null
  But was:  null
 */
ClassicAssert.IsNotNull(obj); /* fail message:   Assert.That(anObject, Is.Not.Null)
  Expected: not null
  But was:  null
 */
Assert.That(obj, Is.Not.Null); /* fail message:   Assert.That(obj, Is.Not.Null)
  Expected: not null
  But was:  null
 */

// new assertion:
obj.Should().NotBeNull(); /* fail message: Expected obj not to be <null>. */
```

### scenario: AssertIsEmpty

```cs
// arrange
var collection = new List<int>();

// old assertion:
ClassicAssert.IsEmpty(collection);
Assert.That(collection, Is.Empty);
Assert.That(collection, Has.Count.EqualTo(0));
Assert.That(collection, Has.Count.Zero);
CollectionAssert.IsEmpty(collection);

// new assertion:
collection.Should().BeEmpty();
```

#### Failure messages

```cs
var collection = new List<int> { 1, 2, 3 };

// old assertion:
ClassicAssert.IsEmpty(collection); /* fail message:   Assert.That(collection, new EmptyCollectionConstraint())
  Expected: <empty>
  But was:  < 1, 2, 3 >
 */
Assert.That(collection, Is.Empty); /* fail message:   Assert.That(collection, Is.Empty)
  Expected: <empty>
  But was:  < 1, 2, 3 >
 */
Assert.That(collection, Has.Count.EqualTo(0)); /* fail message:   Assert.That(collection, Has.Count.EqualTo(0))
  Expected: property Count equal to 0
  But was:  3
 */
Assert.That(collection, Has.Count.Zero); /* fail message:   Assert.That(collection, Has.Count.Zero)
  Expected: property Count equal to 0
  But was:  3
 */
CollectionAssert.IsEmpty(collection); /* fail message:   Assert.That(collection, new EmptyCollectionConstraint())
  Expected: <empty>
  But was:  < 1, 2, 3 >
 */

// new assertion:
collection.Should().BeEmpty(); /* fail message: Expected collection to be empty, but found {1, 2, 3}. */
```

### scenario: AssertIsNotEmpty

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
ClassicAssert.IsNotEmpty(collection);
Assert.That(collection, Is.Not.Empty);
Assert.That(collection, Has.Count.GreaterThan(0));
Assert.That(collection, Has.Count.Not.Zero);
CollectionAssert.IsNotEmpty(collection);

// new assertion:
collection.Should().NotBeEmpty();
```

#### Failure messages

```cs
var collection = new List<int>();

// old assertion:
ClassicAssert.IsNotEmpty(collection); /* fail message:   Assert.That(collection, Is.Not.Empty)
  Expected: not <empty>
  But was:  <empty>
 */
Assert.That(collection, Is.Not.Empty); /* fail message:   Assert.That(collection, Is.Not.Empty)
  Expected: not <empty>
  But was:  <empty>
 */
Assert.That(collection, Has.Count.GreaterThan(0)); /* fail message:   Assert.That(collection, Has.Count.GreaterThan(0))
  Expected: property Count greater than 0
  But was:  0
 */
Assert.That(collection, Has.Count.Not.Zero); /* fail message:   Assert.That(collection, Has.Count.Not.Zero)
  Expected: property Count not equal to 0
  But was:  0
 */
CollectionAssert.IsNotEmpty(collection); /* fail message:   Assert.That(collection, new NotConstraint(new EmptyCollectionConstraint()))
  Expected: not <empty>
  But was:  <empty>
 */

// new assertion:
collection.Should().NotBeEmpty(); /* fail message: Expected collection not to be empty. */
```

### scenario: AssertZero

```cs
// arrange
var number = 0;

// old assertion:
ClassicAssert.Zero(number);
Assert.That(number, Is.Zero);

// new assertion:
number.Should().Be(0);
```

#### Failure messages

```cs
var number = 1;

// old assertion:
ClassicAssert.Zero(number); /* fail message:   Assert.That(actual, Is.Zero)
  Expected: 0
  But was:  1
 */
Assert.That(number, Is.Zero); /* fail message:   Assert.That(number, Is.Zero)
  Expected: 0
  But was:  1
 */

// new assertion:
number.Should().Be(0); /* fail message: Expected number to be 0, but found 1 (difference of 1). */
```

### scenario: AssertNotZero

```cs
// arrange
var number = 1;

// old assertion:
ClassicAssert.NotZero(number);
Assert.That(number, Is.Not.Zero);

// new assertion:
number.Should().NotBe(0);
```

#### Failure messages

```cs
var number = 0;

// old assertion:
ClassicAssert.NotZero(number); /* fail message:   Assert.That(actual, Is.Not.Zero)
  Expected: not equal to 0
  But was:  0
 */
Assert.That(number, Is.Not.Zero); /* fail message:   Assert.That(number, Is.Not.Zero)
  Expected: not equal to 0
  But was:  0
 */

// new assertion:
number.Should().NotBe(0); /* fail message: Did not expect number to be 0. */
```

### scenario: AssertAreSame

```cs
// arrange
var obj1 = new object();
var obj2 = obj1;

// old assertion:
ClassicAssert.AreSame(obj1, obj2);

// new assertion:
obj1.Should().BeSameAs(obj2);
```

#### Failure messages

```cs
object obj1 = 6;
object obj2 = "foo";

// old assertion:
ClassicAssert.AreSame(obj1, obj2); /* fail message:   Assert.That(actual, Is.SameAs(expected))
  Expected: same as 6
  But was:  "foo"
 */

// new assertion:
obj1.Should().BeSameAs(obj2); /* fail message: Expected obj1 to refer to "foo", but found 6. */
```

### scenario: AssertAreNotSame

```cs
// arrange
object obj1 = 6;
object obj2 = "foo";

// old assertion:
ClassicAssert.AreNotSame(obj1, obj2);

// new assertion:
obj1.Should().NotBeSameAs(obj2);
```

#### Failure messages

```cs
object obj1 = "foo";
object obj2 = "foo";

// old assertion:
ClassicAssert.AreNotSame(obj1, obj2); /* fail message:   Assert.That(actual, Is.Not.SameAs(expected))
  Expected: not same as "foo"
  But was:  "foo"
 */

// new assertion:
obj1.Should().NotBeSameAs(obj2); /* fail message: Did not expect obj1 to refer to "foo". */
```

### scenario: AssertGreater

```cs
// arrange
var number = 2;

// old assertion:
ClassicAssert.Greater(number, 1);
Assert.That(number, Is.GreaterThan(1));

// new assertion:
number.Should().BeGreaterThan(1);
```

#### Failure messages

```cs
var number = 1;

// old assertion:
ClassicAssert.Greater(number, 1); /* fail message:   Assert.That(arg1, Is.GreaterThan(arg2))
  Expected: greater than 1
  But was:  1
 */
Assert.That(number, Is.GreaterThan(1)); /* fail message:   Assert.That(number, Is.GreaterThan(1))
  Expected: greater than 1
  But was:  1
 */

// new assertion:
number.Should().BeGreaterThan(1); /* fail message: Expected number to be greater than 1, but found 1. */
```

### scenario: AssertGreaterOrEqual

```cs
// arrange
var number = 2;

// old assertion:
ClassicAssert.GreaterOrEqual(number, 1);
Assert.That(number, Is.GreaterThanOrEqualTo(1));

// new assertion:
number.Should().BeGreaterOrEqualTo(1);
```

#### Failure messages

```cs
var number = 1;

// old assertion:
ClassicAssert.GreaterOrEqual(number, 2); /* fail message:   Assert.That(arg1, Is.GreaterThanOrEqualTo(arg2))
  Expected: greater than or equal to 2
  But was:  1
 */
Assert.That(number, Is.GreaterThanOrEqualTo(2)); /* fail message:   Assert.That(number, Is.GreaterThanOrEqualTo(2))
  Expected: greater than or equal to 2
  But was:  1
 */

// new assertion:
number.Should().BeGreaterOrEqualTo(2); /* fail message: Expected number to be greater than or equal to 2, but found 1. */
```

### scenario: AssertLess

```cs
// arrange
var number = 1;

// old assertion:
ClassicAssert.Less(number, 2);
Assert.That(number, Is.LessThan(2));

// new assertion:
number.Should().BeLessThan(2);
```

#### Failure messages

```cs
var number = 2;

// old assertion:
ClassicAssert.Less(number, 1); /* fail message:   Assert.That(arg1, Is.LessThan(arg2))
  Expected: less than 1
  But was:  2
 */
Assert.That(number, Is.LessThan(1)); /* fail message:   Assert.That(number, Is.LessThan(1))
  Expected: less than 1
  But was:  2
 */

// new assertion:
number.Should().BeLessThan(1); /* fail message: Expected number to be less than 1, but found 2. */
```

### scenario: AssertLessOrEqual

```cs
// arrange
var number = 1;

// old assertion:
ClassicAssert.LessOrEqual(number, 2);
Assert.That(number, Is.LessThanOrEqualTo(2));

// new assertion:
number.Should().BeLessOrEqualTo(2);
```

#### Failure messages

```cs
var number = 2;

// old assertion:
ClassicAssert.LessOrEqual(number, 1); /* fail message:   Assert.That(arg1, Is.LessThanOrEqualTo(arg2))
  Expected: less than or equal to 1
  But was:  2
 */
Assert.That(number, Is.LessThanOrEqualTo(1)); /* fail message:   Assert.That(number, Is.LessThanOrEqualTo(1))
  Expected: less than or equal to 1
  But was:  2
 */

// new assertion:
number.Should().BeLessOrEqualTo(1); /* fail message: Expected number to be less than or equal to 1, but found 2. */
```

### scenario: CollectionAssertAreEqual

```cs
// arrange
var collection = new[] { 1, 2, 3 };
var expected = new[] { 1, 2, 3 };

// old assertion:
CollectionAssert.AreEqual(expected, collection);
Assert.That(collection, Is.EqualTo(expected));

// new assertion:
collection.Should().Equal(expected);
```

#### Failure messages

```cs
var collection = new[] { 1, 2, 3 };
var expected = new[] { 1, 2, 4 };

// old assertion:
CollectionAssert.AreEqual(expected, collection); /* fail message:   Assert.That(actual, Is.EqualTo(expected).AsCollection)
  Expected and actual are both <System.Int32[3]>
  Values differ at index [2]
  Expected: 4
  But was:  3
 */
Assert.That(collection, Is.EqualTo(expected)); /* fail message:   Assert.That(collection, Is.EqualTo(expected))
  Expected and actual are both <System.Int32[3]>
  Values differ at index [2]
  Expected: 4
  But was:  3
 */

// new assertion:
collection.Should().Equal(expected); /* fail message: Expected collection to be equal to {1, 2, 4}, but {1, 2, 3} differs at index 2. */
```

### scenario: CollectionAssertAreNotEqual

```cs
// arrange
var collection = new[] { 1, 2, 3 };
var expected = new[] { 1, 2, 4 };

// old assertion:
CollectionAssert.AreNotEqual(expected, collection);
Assert.That(collection, Is.Not.EqualTo(expected));

// new assertion:
collection.Should().NotEqual(expected);
```

#### Failure messages

```cs
var collection = new[] { 1, 2, 3 };
var expected = new[] { 1, 2, 3 };

// old assertion:
CollectionAssert.AreNotEqual(expected, collection); /* fail message:   Assert.That(actual, Is.Not.EqualTo(expected).AsCollection)
  Expected: not equal to < 1, 2, 3 >
  But was:  < 1, 2, 3 >
 */
Assert.That(collection, Is.Not.EqualTo(expected)); /* fail message:   Assert.That(collection, Is.Not.EqualTo(expected))
  Expected: not equal to < 1, 2, 3 >
  But was:  < 1, 2, 3 >
 */

// new assertion:
collection.Should().NotEqual(expected); /* fail message: Did not expect collections {1, 2, 3} and {1, 2, 3} to be equal. */
```

### scenario: CollectionAssertContains

```cs
// arrange
var collection = new[] { 1, 2, 3 };

// old assertion:
CollectionAssert.Contains(collection, 2);
Assert.That(collection, Has.Member(2));
Assert.That(collection, Does.Contain(2));
Assert.That(collection, Contains.Item(2));

// new assertion:
collection.Should().Contain(2);
```

#### Failure messages

```cs
var collection = new[] { 1, 2, 3 };

// old assertion:
CollectionAssert.Contains(collection, 4); /* fail message:   Assert.That(collection, Has.Member(actual))
  Expected: some item equal to 4
  But was:  < 1, 2, 3 >
 */
Assert.That(collection, Has.Member(4)); /* fail message:   Assert.That(collection, Has.Member(4))
  Expected: some item equal to 4
  But was:  < 1, 2, 3 >
 */
Assert.That(collection, Does.Contain(4)); /* fail message:   Assert.That(collection, Does.Contain(4))
  Expected: some item equal to 4
  But was:  < 1, 2, 3 >
 */

// new assertion:
collection.Should().Contain(4); /* fail message: Expected collection {1, 2, 3} to contain 4. */
```

### scenario: CollectionAssertContains_WithCasting

```cs
// arrange
var collection = new[] { 1, 2, 3 };
object item = 2;

// old assertion:
CollectionAssert.Contains(collection, item);
Assert.That(collection, Has.Member(item));
Assert.That(collection, Does.Contain(item));

// new assertion:
collection.Should().Contain((int)item);
```

#### Failure messages

```cs
var collection = new[] { 1, 2, 3 };
object item = 4;

// old assertion:
Assert.That(collection, Contains.Item(item)); /* fail message:   Assert.That(collection, Contains.Item(item))
  Expected: some item equal to 4
  But was:  < 1, 2, 3 >
 */
CollectionAssert.Contains(collection, item); /* fail message:   Assert.That(collection, Has.Member(actual))
  Expected: some item equal to 4
  But was:  < 1, 2, 3 >
 */
Assert.That(collection, Has.Member(item)); /* fail message:   Assert.That(collection, Has.Member(item))
  Expected: some item equal to 4
  But was:  < 1, 2, 3 >
 */
Assert.That(collection, Does.Contain(item)); /* fail message:   Assert.That(collection, Does.Contain(item))
  Expected: some item equal to 4
  But was:  < 1, 2, 3 >
 */

// new assertion:
collection.Should().Contain((int)item); /* fail message: Expected collection {1, 2, 3} to contain 4. */
```

### scenario: CollectionAssertDoesNotContain

```cs
// arrange
var collection = new[] { 1, 2, 3 };

// old assertion:
CollectionAssert.DoesNotContain(collection, 4);
Assert.That(collection, Has.No.Member(4));
Assert.That(collection, Does.Not.Contain(4));

// new assertion:
collection.Should().NotContain(4);
```

#### Failure messages

```cs
var collection = new[] { 1, 2, 3 };

// old assertion:
CollectionAssert.DoesNotContain(collection, 2); /* fail message:   Assert.That(collection, Has.No.Member(actual))
  Expected: not some item equal to 2
  But was:  < 1, 2, 3 >
 */
Assert.That(collection, Has.No.Member(2)); /* fail message:   Assert.That(collection, Has.No.Member(2))
  Expected: not some item equal to 2
  But was:  < 1, 2, 3 >
 */
Assert.That(collection, Does.Not.Contain(2)); /* fail message:   Assert.That(collection, Does.Not.Contain(2))
  Expected: not some item equal to 2
  But was:  < 1, 2, 3 >
 */

// new assertion:
collection.Should().NotContain(2); /* fail message: Expected collection {1, 2, 3} to not contain 2. */
```

### scenario: CollectionAssertDoesNotContain_WithCasting

```cs
// arrange
var collection = new[] { 1, 2, 3 };
object item = 4;

// old assertion:
CollectionAssert.DoesNotContain(collection, item);
Assert.That(collection, Has.No.Member(item));
Assert.That(collection, Does.Not.Contain(item));

// new assertion:
collection.Should().NotContain((int)item);
```

#### Failure messages

```cs
var collection = new[] { 1, 2, 3 };
object item = 2;

// old assertion:
CollectionAssert.DoesNotContain(collection, item); /* fail message:   Assert.That(collection, Has.No.Member(actual))
  Expected: not some item equal to 2
  But was:  < 1, 2, 3 >
 */
Assert.That(collection, Has.No.Member(item)); /* fail message:   Assert.That(collection, Has.No.Member(item))
  Expected: not some item equal to 2
  But was:  < 1, 2, 3 >
 */
Assert.That(collection, Does.Not.Contain(item)); /* fail message:   Assert.That(collection, Does.Not.Contain(item))
  Expected: not some item equal to 2
  But was:  < 1, 2, 3 >
 */

// new assertion:
collection.Should().NotContain((int)item); /* fail message: Expected collection {1, 2, 3} to not contain 2. */
```

### scenario: CollectionAssertAllItemsAreInstancesOfType

```cs
// arrange
var collection = new object[] { 1, 2, 3 };

// old assertion:
CollectionAssert.AllItemsAreInstancesOfType(collection, typeof(int));
Assert.That(collection, Is.All.InstanceOf(typeof(int)));
Assert.That(collection, Is.All.InstanceOf<int>());
Assert.That(collection, Has.All.InstanceOf(typeof(int)));
Assert.That(collection, Has.All.InstanceOf<int>());

// new assertion:
collection.Should().AllBeOfType<int>();
```

#### Failure messages

```cs
var collection = new object[] { 1, 2, "3" };

// old assertion:
CollectionAssert.AllItemsAreInstancesOfType(collection, typeof(int)); /* fail message:   Assert.That(collection, Is.All.InstanceOf(expectedType))
  Expected: all items instance of <System.Int32>
  But was:  < 1, 2, "3" >
  First non-matching item at index [2]:  "3"
 */
Assert.That(collection, Is.All.InstanceOf(typeof(int))); /* fail message:   Assert.That(collection, Is.All.InstanceOf(typeof(int)))
  Expected: all items instance of <System.Int32>
  But was:  < 1, 2, "3" >
  First non-matching item at index [2]:  "3"
 */
Assert.That(collection, Is.All.InstanceOf<int>()); /* fail message:   Assert.That(collection, Is.All.InstanceOf<int>())
  Expected: all items instance of <System.Int32>
  But was:  < 1, 2, "3" >
  First non-matching item at index [2]:  "3"
 */
Assert.That(collection, Has.All.InstanceOf(typeof(int))); /* fail message:   Assert.That(collection, Has.All.InstanceOf(typeof(int)))
  Expected: all items instance of <System.Int32>
  But was:  < 1, 2, "3" >
  First non-matching item at index [2]:  "3"
 */
Assert.That(collection, Has.All.InstanceOf<int>()); /* fail message:   Assert.That(collection, Has.All.InstanceOf<int>())
  Expected: all items instance of <System.Int32>
  But was:  < 1, 2, "3" >
  First non-matching item at index [2]:  "3"
 */

// new assertion:
collection.Should().AllBeOfType<int>(); /* fail message: Expected type to be "System.Int32", but found "[System.Int32, System.Int32, System.String]". */
```

### scenario: CollectionAssertAllItemsAreInstancesOfType_WithTypeArgument

```cs
// arrange
var collection = new object[] { 1, 2, 3 };
var type = typeof(int);

// old assertion:
CollectionAssert.AllItemsAreInstancesOfType(collection, type);
Assert.That(collection, Is.All.InstanceOf(type));
Assert.That(collection, Has.All.InstanceOf(type));

// new assertion:
collection.Should().AllBeOfType(type);
```

#### Failure messages

```cs
var collection = new object[] { 1, 2, "3" };
var type = typeof(int);

// old assertion:
CollectionAssert.AllItemsAreInstancesOfType(collection, type); /* fail message:   Assert.That(collection, Is.All.InstanceOf(expectedType))
  Expected: all items instance of <System.Int32>
  But was:  < 1, 2, "3" >
  First non-matching item at index [2]:  "3"
 */
Assert.That(collection, Is.All.InstanceOf(type)); /* fail message:   Assert.That(collection, Is.All.InstanceOf(type))
  Expected: all items instance of <System.Int32>
  But was:  < 1, 2, "3" >
  First non-matching item at index [2]:  "3"
 */
Assert.That(collection, Has.All.InstanceOf(type)); /* fail message:   Assert.That(collection, Has.All.InstanceOf(type))
  Expected: all items instance of <System.Int32>
  But was:  < 1, 2, "3" >
  First non-matching item at index [2]:  "3"
 */

// new assertion:
collection.Should().AllBeOfType(type); /* fail message: Expected type to be "System.Int32", but found "[System.Int32, System.Int32, System.String]". */
```

### scenario: CollectionAssertAllItemsAreNotNull

```cs
// arrange
var collection = new object[] { 1, "test", true };

// old assertion:
CollectionAssert.AllItemsAreNotNull(collection);

// new assertion:
collection.Should().NotContainNulls();
```

#### Failure messages

```cs
var collection = new object[] { 1, null, true };

// old assertion:
CollectionAssert.AllItemsAreNotNull(collection); /* fail message:   Assert.That(collection, Is.All.Not.Null)
  Expected: all items not null
  But was:  < 1, null, True >
  First non-matching item at index [1]:  null
 */

// new assertion:
collection.Should().NotContainNulls(); /* fail message: Expected collection not to contain <null>s, but found one at index 1. */
```

### scenario: CollectionAssertAllItemsAreUnique

```cs
// arrange
var collection = new[] { 1, 2, 3 };

// old assertion:
CollectionAssert.AllItemsAreUnique(collection);

// new assertion:
collection.Should().OnlyHaveUniqueItems();
```

#### Failure messages

```cs
var collection = new[] { 1, 2, 1 };

// old assertion:
CollectionAssert.AllItemsAreUnique(collection); /* fail message:   Assert.That(collection, Is.Unique)
  Expected: all items unique
  But was:  < 1, 2, 1 >
  Not unique items: < 1 >
 */

// new assertion:
collection.Should().OnlyHaveUniqueItems(); /* fail message: Expected collection to only have unique items, but item 1 is not unique. */
```


