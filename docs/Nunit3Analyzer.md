<!--
This is a generated file, please edit src\FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator\DocsGenerator.cs to change the contents
-->

# Nunit3 Analyzer Docs

- [AssertIsTrue](#scenario-assertistrue) - `flag.Should().BeTrue();`
- [AssertIsFalse](#scenario-assertisfalse) - `flag.Should().BeFalse();`
- [AssertNull](#scenario-assertnull) - `obj.Should().BeNull();`
- [AssertNotNull](#scenario-assertnotnull) - `obj.Should().NotBeNull();`
- [AssertIsEmpty](#scenario-assertisempty) - `collection.Should().BeEmpty();`
- [AssertIsNotEmpty](#scenario-assertisnotempty) - `collection.Should().NotBeEmpty();`
- [AssertZero](#scenario-assertzero) - `number.Should().Be(0);`
- [AssertNotZero](#scenario-assertnotzero) - `number.Should().NotBe(0);`


## Scenarios

### scenario: AssertIsTrue

```cs
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
```

#### Failure messages

```cs
var flag = false;

// old assertion:
Assert.True(flag); /* fail message:   Expected: True
  But was:  False
 */
Assert.IsTrue(flag); /* fail message:   Expected: True
  But was:  False
 */
Assert.That(flag); /* fail message:   Expected: True
  But was:  False
 */
Assert.That(flag, Is.True); /* fail message:   Expected: True
  But was:  False
 */
Assert.That(flag, Is.Not.False); /* fail message:   Expected: not False
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
Assert.IsFalse(flag);
Assert.False(flag);
Assert.That(flag, Is.False);
Assert.That(flag, Is.Not.True);

// new assertion:
flag.Should().BeFalse();
```

#### Failure messages

```cs
var flag = true;

// old assertion:
Assert.False(flag); /* fail message:   Expected: False
  But was:  True
 */
Assert.IsFalse(flag); /* fail message:   Expected: False
  But was:  True
 */
Assert.That(flag, Is.False); /* fail message:   Expected: False
  But was:  True
 */
Assert.That(flag, Is.Not.True); /* fail message:   Expected: not True
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
Assert.IsNull(obj);
Assert.Null(obj);
Assert.That(obj, Is.Null);

// new assertion:
obj.Should().BeNull();
```

#### Failure messages

```cs
object obj = "foo";

// old assertion:
Assert.Null(obj); /* fail message:   Expected: null
  But was:  "foo"
 */
Assert.IsNull(obj); /* fail message:   Expected: null
  But was:  "foo"
 */
Assert.That(obj, Is.Null); /* fail message:   Expected: null
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
Assert.IsNotNull(obj);
Assert.NotNull(obj);
Assert.That(obj, Is.Not.Null);

// new assertion:
obj.Should().NotBeNull();
```

#### Failure messages

```cs
object obj = null;

// old assertion:
Assert.NotNull(obj); /* fail message:   Expected: not null
  But was:  null
 */
Assert.IsNotNull(obj); /* fail message:   Expected: not null
  But was:  null
 */
Assert.That(obj, Is.Not.Null); /* fail message:   Expected: not null
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
Assert.IsEmpty(collection);
Assert.That(collection, Is.Empty);
CollectionAssert.IsEmpty(collection);

// new assertion:
collection.Should().BeEmpty();
```

#### Failure messages

```cs
var collection = new List<int> { 1, 2, 3 };

// old assertion:
Assert.IsEmpty(collection); /* fail message:   Expected: <empty>
  But was:  < 1, 2, 3 >
 */
Assert.That(collection, Is.Empty); /* fail message:   Expected: <empty>
  But was:  < 1, 2, 3 >
 */
CollectionAssert.IsEmpty(collection); /* fail message:   Expected: <empty>
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
Assert.IsNotEmpty(collection);
Assert.That(collection, Is.Not.Empty);
CollectionAssert.IsNotEmpty(collection);

// new assertion:
collection.Should().NotBeEmpty();
```

#### Failure messages

```cs
var collection = new List<int>();

// old assertion:
Assert.IsNotEmpty(collection); /* fail message:   Expected: not <empty>
  But was:  <empty>
 */
Assert.That(collection, Is.Not.Empty); /* fail message:   Expected: not <empty>
  But was:  <empty>
 */
CollectionAssert.IsNotEmpty(collection); /* fail message:   Expected: not <empty>
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
Assert.Zero(number);
Assert.That(number, Is.Zero);

// new assertion:
number.Should().Be(0);
```

#### Failure messages

```cs
var number = 1;

// old assertion:
Assert.Zero(number); /* fail message:   Expected: 0
  But was:  1
 */
Assert.That(number, Is.Zero); /* fail message:   Expected: 0
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
Assert.NotZero(number);
Assert.That(number, Is.Not.Zero);

// new assertion:
number.Should().NotBe(0);
```

#### Failure messages

```cs
var number = 0;

// old assertion:
Assert.NotZero(number); /* fail message:   Expected: not equal to 0
  But was:  0
 */
Assert.That(number, Is.Not.Zero); /* fail message:   Expected: not equal to 0
  But was:  0
 */

// new assertion:
number.Should().NotBe(0); /* fail message: Did not expect number to be 0. */
```


