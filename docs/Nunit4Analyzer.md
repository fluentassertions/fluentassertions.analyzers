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
- [CollectionAssertAreEqual](#scenario-collectionassertareequal) - `collection.Should().Equal(expected);`
- [CollectionAssertAreNotEqual](#scenario-collectionassertarenotequal) - `collection.Should().NotEqual(expected);`
- [CollectionAssertContains](#scenario-collectionassertcontains) - `collection.Should().Contain(2);`
- [CollectionAssertContains_WithCasting](#scenario-collectionassertcontains_withcasting) - `collection.Should().Contain((int)item);`
- [CollectionAssertDoesNotContain](#scenario-collectionassertdoesnotcontain) - `collection.Should().NotContain(4);`
- [CollectionAssertDoesNotContain_WithCasting](#scenario-collectionassertdoesnotcontain_withcasting) - `collection.Should().NotContain((int)item);`


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

### scenario: CollectionAssertAreEqual

```cs
// arrange
var collection = new[] { 1, 2, 3 };
var expected = new [] { 1, 2, 3 };

// old assertion:
CollectionAssert.AreEqual(expected, collection);

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

// new assertion:
collection.Should().NotEqual(expected); /* fail message: Did not expect collections {1, 2, 3} and {1, 2, 3} to be equal. */
```

### scenario: CollectionAssertContains

```cs
// arrange
var collection = new[] { 1, 2, 3 };

// old assertion:
CollectionAssert.Contains(collection, 2);

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

// new assertion:
collection.Should().Contain((int)item);
```

#### Failure messages

```cs
var collection = new[] { 1, 2, 3 };
object item = 4;

// old assertion:
CollectionAssert.Contains(collection, item); /* fail message:   Assert.That(collection, Has.Member(actual))
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

// new assertion:
collection.Should().NotContain((int)item); /* fail message: Expected collection {1, 2, 3} to not contain 2. */
```


