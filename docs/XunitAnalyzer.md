<!--
This is a generated file, please edit src\FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator\DocsGenerator.cs to change the contents
-->

# Xunit Analyzer Docs

- [AssertTrue](#scenario-asserttrue) - `flag.Should().BeTrue();`
- [AssertFalse](#scenario-assertfalse) - `flag.Should().BeFalse();`
- [AssertSame](#scenario-assertsame) - `obj1.Should().BeSameAs(obj2);`
- [AssertNotSame](#scenario-assertnotsame) - `obj1.Should().NotBeSameAs(obj2);`
- [AssertDoubleEqual](#scenario-assertdoubleequal) - `actual.Should().BeApproximately(expected, tolerance);`
- [AssertDateTimeEqual](#scenario-assertdatetimeequal) - `actual.Should().BeCloseTo(expected, TimeSpan.FromDays(3));`
- [AssertObjectEqual](#scenario-assertobjectequal) - `actual.Should().Be(expected);`
- [AssertObjectEqualWithComparer](#scenario-assertobjectequalwithcomparer) - `actual.Should().BeEquivalentTo(expected, options => options.Using(EqualityComparer<object>.Default));`
- [AssertObjectNotEqual](#scenario-assertobjectnotequal) - `actual.Should().NotBe(expected);`
- [AssertObjectNotEqualWithComparer](#scenario-assertobjectnotequalwithcomparer) - `actual.Should().NotBeEquivalentTo(expected, options => options.Using(EqualityComparer<object>.Default));`
- [AssertStrictEqual](#scenario-assertstrictequal) - `actual.Should().Be(expected);`
- [AssertNotStrictEqual](#scenario-assertnotstrictequal) - `actual.Should().NotBe(expected);`


## Scenarios

### scenario: AssertTrue

```cs
// arrange
var flag = true;

// old assertion:
Assert.True(flag);

// new assertion:
flag.Should().BeTrue();
```

#### Failure messages

```cs
var flag = false;

// old assertion:
Assert.True(flag); /* fail message: Assert.True() Failure
Expected: True
Actual:   False */

// new assertion:
flag.Should().BeTrue(); /* fail message: Expected flag to be True, but found False. */
```

### scenario: AssertFalse

```cs
// arrange
var flag = false;

// old assertion:
Assert.False(flag);

// new assertion:
flag.Should().BeFalse();
```

#### Failure messages

```cs
var flag = true;

// old assertion:
Assert.False(flag); /* fail message: Assert.False() Failure
Expected: False
Actual:   True */

// new assertion:
flag.Should().BeFalse(); /* fail message: Expected flag to be False, but found True. */
```

### scenario: AssertSame

```cs
// arrange
var obj1 = new object();
var obj2 = obj1;

// old assertion:
Assert.Same(obj1, obj2);

// new assertion:
obj1.Should().BeSameAs(obj2);
```

#### Failure messages

```cs
object obj1 = 6;
object obj2 = "foo";

// old assertion:
Assert.Same(obj1, obj2); /* fail message: Assert.Same() Failure: Values are not the same instance
Expected: 6
Actual:   "foo" */

// new assertion:
obj1.Should().BeSameAs(obj2); /* fail message: Expected obj1 to refer to "foo", but found 6. */
```

### scenario: AssertNotSame

```cs
// arrange
object obj1 = 6;
object obj2 = "foo";

// old assertion:
Assert.NotSame(obj1, obj2);

// new assertion:
obj1.Should().NotBeSameAs(obj2);
```

#### Failure messages

```cs
object obj1 = "foo";
object obj2 = "foo";

// old assertion:
Assert.NotSame(obj1, obj2); /* fail message: Assert.NotSame() Failure: Values are the same instance */

// new assertion:
obj1.Should().NotBeSameAs(obj2); /* fail message: Did not expect obj1 to refer to "foo". */
```

### scenario: AssertDoubleEqual

```cs
// arrange
double actual = 3.14;
double expected = 3.141;
double tolerance = 0.00159;

// old assertion:
Assert.Equal(expected, actual, tolerance);

// new assertion:
actual.Should().BeApproximately(expected, tolerance);
```

#### Failure messages

```cs
double actual = 3.14;
double expected = 4.2;
double tolerance = 0.0001;

// old assertion:
Assert.Equal(expected, actual, tolerance); /* fail message: Assert.Equal() Failure: Values are not within tolerance 0.0001
Expected: 4.2000000000000002
Actual:   3.1400000000000001 */

// new assertion:
actual.Should().BeApproximately(expected, tolerance); /* fail message: Expected actual to approximate 4.2 +/- 0.0001, but 3.14 differed by 1.06. */
```

### scenario: AssertDateTimeEqual

```cs
// arrange
var actual = new DateTime(2021, 1, 1);
var expected = new DateTime(2021, 1, 2);

// old assertion:
Assert.Equal(expected, actual, TimeSpan.FromDays(3));

// new assertion:
actual.Should().BeCloseTo(expected, TimeSpan.FromDays(3));
```

#### Failure messages

```cs
var actual = new DateTime(2021, 1, 1);
var expected = new DateTime(2021, 1, 2);

// old assertion:
Assert.Equal(expected, actual, TimeSpan.FromHours(3)); /* fail message: Assert.Equal() Failure: Values differ
Expected: 2021-01-02T00:00:00.0000000
Actual:   2021-01-01T00:00:00.0000000 (difference 1.00:00:00 is larger than 03:00:00) */

// new assertion:
actual.Should().BeCloseTo(expected, TimeSpan.FromHours(3)); /* fail message: Expected actual to be within 3h from <2021-01-02>, but <2021-01-01> was off by 1d. */
```

### scenario: AssertObjectEqual

```cs
// arrange
object actual = "foo";
object expected = "foo";

// old assertion:
Assert.Equal(expected, actual);

// new assertion:
actual.Should().Be(expected);
```

#### Failure messages

```cs
object actual = "foo";
object expected = 6;

// old assertion:
Assert.Equal(expected, actual); /* fail message: Assert.Equal() Failure: Values differ
Expected: 6
Actual:   foo */

// new assertion:
actual.Should().Be(expected); /* fail message: Expected actual to be 6, but found "foo". */
```

### scenario: AssertObjectEqualWithComparer

```cs
// arrange
object actual = "foo";
object expected = "foo";

// old assertion:
Assert.Equal(expected, actual, EqualityComparer<object>.Default);

// new assertion:
actual.Should().BeEquivalentTo(expected, options => options.Using(EqualityComparer<object>.Default));
```

#### Failure messages

```cs
object actual = "foo";
object expected = 6;

// old assertion:
Assert.Equal(expected, actual, EqualityComparer<object>.Default); /* fail message: Assert.Equal() Failure: Values differ
Expected: 6
Actual:   foo */

// new assertion:
actual.Should().BeEquivalentTo(expected, options => options.Using(EqualityComparer<object>.Default)); /* fail message: Expected actual to be 6, but found "foo".

With configuration:
- Use declared types and members
- Compare enums by value
- Compare tuples by their properties
- Compare anonymous types by their properties
- Compare records by their members
- Include non-browsable members
- Match member by name (or throw)
- Use System.Collections.Generic.ObjectEqualityComparer`1[System.Object] for objects of type System.Object
- Be strict about the order of items in byte arrays
- Without automatic conversion.
 */
```

### scenario: AssertObjectNotEqual

```cs
// arrange
object actual = "foo";
object expected = 6;

// old assertion:
Assert.NotEqual(expected, actual);

// new assertion:
actual.Should().NotBe(expected);
```

#### Failure messages

```cs
object actual = "foo";
object expected = "foo";

// old assertion:
Assert.NotEqual(expected, actual); /* fail message: Assert.NotEqual() Failure: Strings are equal
Expected: Not "foo"
Actual:       "foo" */

// new assertion:
actual.Should().NotBe(expected); /* fail message: Did not expect actual to be equal to "foo". */
```

### scenario: AssertObjectNotEqualWithComparer

```cs
// arrange
object actual = "foo";
object expected = 6;

// old assertion:
Assert.NotEqual(expected, actual, EqualityComparer<object>.Default);

// new assertion:
actual.Should().NotBeEquivalentTo(expected, options => options.Using(EqualityComparer<object>.Default));
```

#### Failure messages

```cs
object actual = "foo";
object expected = "foo";

// old assertion:
Assert.NotEqual(expected, actual, EqualityComparer<object>.Default); /* fail message: Assert.NotEqual() Failure: Strings are equal
Expected: Not "foo"
Actual:       "foo" */

// new assertion:
actual.Should().NotBeEquivalentTo(expected, options => options.Using(EqualityComparer<object>.Default)); /* fail message: Expected actual not to be equivalent to "foo", but they are. */
```

### scenario: AssertStrictEqual

```cs
// arrange
object actual = "foo";
object expected = "foo";

// old assertion:
Assert.StrictEqual(expected, actual);

// new assertion:
actual.Should().Be(expected);
```

#### Failure messages

```cs
object actual = "foo";
object expected = 6;

// old assertion:
Assert.StrictEqual(expected, actual); /* fail message: Assert.StrictEqual() Failure: Values differ
Expected: 6
Actual:   "foo" */

// new assertion:
actual.Should().Be(expected); /* fail message: Expected actual to be 6, but found "foo". */
```

### scenario: AssertNotStrictEqual

```cs
// arrange
object actual = "foo";
object expected = 6;

// old assertion:
Assert.NotStrictEqual(expected, actual);

// new assertion:
actual.Should().NotBe(expected);
```

#### Failure messages

```cs
object actual = "foo";
object expected = "foo";

// old assertion:
Assert.NotStrictEqual(expected, actual); /* fail message: Assert.NotStrictEqual() Failure: Values are equal
Expected: Not "foo"
Actual:       "foo" */

// new assertion:
actual.Should().NotBe(expected); /* fail message: Did not expect actual to be equal to "foo". */
```


