<!--
This is a generated file, please edit src\FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator\DocsGenerator.cs to change the contents
-->

# MsTest Analyzer Docs

- [AssertIsTrue](#scenario-assertistrue) - `flag.Should().BeTrue();`
- [AssertIsFalse](#scenario-assertisfalse) - `flag.Should().BeFalse();`
- [AssertIsNull](#scenario-assertisnull) - `obj.Should().BeNull();`
- [AssertIsNotNull](#scenario-assertisnotnull) - `obj.Should().NotBeNull();`
- [AssertIsInstanceOfType](#scenario-assertisinstanceoftype) - `obj.Should().BeOfType<List<object>>();`
- [AssertIsNotInstanceOfType](#scenario-assertisnotinstanceoftype) - `obj.Should().NotBeOfType<List<object>>();`
- [AssertObjectAreEqual](#scenario-assertobjectareequal) - `obj1.Should().Be(obj2);`
- [AssertObjectAreEqual_LiteralValue](#scenario-assertobjectareequal_literalvalue) - `obj1.Should().Be("foo");`
- [AssertOptionalIntegerAreEqual](#scenario-assertoptionalintegerareequal) - `number1.Should().Be(number2);`
- [AssertOptionalIntegerAndNullAreEqual](#scenario-assertoptionalintegerandnullareequal) - `number.Should().BeNull();`
- [AssertDoubleAreEqual](#scenario-assertdoubleareequal) - `number1.Should().BeApproximately(number2, delta);`
- [AssertFloatAreEqual](#scenario-assertfloatareequal) - `number1.Should().BeApproximately(number2, delta);`
- [AssertStringAreEqual_CaseSensitive](#scenario-assertstringareequal_casesensitive) - `str1.Should().Be(str2);`
- [AssertStringAreEqual_IgnoreCase](#scenario-assertstringareequal_ignorecase) - `str1.Should().BeEquivalentTo(str2);`
- [AssertObjectAreNotEqual](#scenario-assertobjectarenotequal) - `obj1.Should().NotBe(obj2);`
- [AssertOptionalIntegerAreNotEqual](#scenario-assertoptionalintegerarenotequal) - `number1.Should().NotBe(number2);`
- [AssertDoubleAreNotEqual](#scenario-assertdoublearenotequal) - `number1.Should().NotBeApproximately(number2, delta);`
- [AssertFloatAreNotEqual](#scenario-assertfloatarenotequal) - `number1.Should().NotBeApproximately(number2, delta);`
- [AssertStringAreNotEqual_CaseSensitive](#scenario-assertstringarenotequal_casesensitive) - `str1.Should().NotBe(str2);`
- [AssertStringAreNotEqual_IgnoreCase](#scenario-assertstringarenotequal_ignorecase) - `str1.Should().NotBeEquivalentTo(str2);`
- [AssertAreSame](#scenario-assertaresame) - `obj1.Should().BeSameAs(obj2);`
- [AssertAreNotSame](#scenario-assertarenotsame) - `obj1.Should().NotBeSameAs(obj2);`
- [CollectionAssertAllItemsAreInstancesOfType](#scenario-collectionassertallitemsareinstancesoftype) - `list.Should().AllBeOfType<int>();`
- [CollectionAssertAreEqual](#scenario-collectionassertareequal) - `list1.Should().Equal(list2);`
- [CollectionAssertAreNotEqual](#scenario-collectionassertarenotequal) - `list1.Should().NotEqual(list2);`
- [CollectionAssertAreEquivalent](#scenario-collectionassertareequivalent) - `list1.Should().BeEquivalentTo(list2);`
- [CollectionAssertAreNotEquivalent](#scenario-collectionassertarenotequivalent) - `list1.Should().NotBeEquivalentTo(list2);`
- [CollectionAssertAllItemsAreNotNull](#scenario-collectionassertallitemsarenotnull) - `list.Should().NotContainNulls();`
- [CollectionAssertAllItemsAreUnique](#scenario-collectionassertallitemsareunique) - `list.Should().OnlyHaveUniqueItems();`
- [CollectionAssertContains](#scenario-collectionassertcontains) - `list.Should().Contain(2);`
- [CollectionAssertDoesNotContain](#scenario-collectionassertdoesnotcontain) - `list.Should().NotContain(4);`
- [CollectionAssertIsSubsetOf](#scenario-collectionassertissubsetof) - `list2.Should().BeSubsetOf(list1);`
- [CollectionAssertIsNotSubsetOf](#scenario-collectionassertisnotsubsetof) - `list2.Should().NotBeSubsetOf(list1);`
- [AssertThrowsException](#scenario-assertthrowsexception) - `action.Should().ThrowExactly<InvalidOperationException>();`
- [AssertThrowsExceptionAsync](#scenario-assertthrowsexceptionasync) - `await action.Should().ThrowExactlyAsync<InvalidOperationException>();`
- [StringAssertContains](#scenario-stringassertcontains) - `str.Should().Contain("oo");`
- [StringAssertStartsWith](#scenario-stringassertstartswith) - `str.Should().StartWith("fo");`
- [StringAssertEndsWith](#scenario-stringassertendswith) - `str.Should().EndWith("oo");`
- [StringAssertMatches](#scenario-stringassertmatches) - `str.Should().MatchRegex(pattern);`
- [StringAssertDoesNotMatch](#scenario-stringassertdoesnotmatch) - `str.Should().NotMatchRegex(pattern);`


## Scenarios

### scenario: AssertIsTrue

```cs
// arrange
var flag = true;

// old assertion:
Assert.IsTrue(flag);

// new assertion:
flag.Should().BeTrue();
```

#### Failure messages

```cs
var flag = false;

// old assertion:
Assert.IsTrue(flag); /* fail message: Assert.IsTrue failed.  */

// new assertion:
flag.Should().BeTrue(); /* fail message: Expected flag to be true, but found False. */
```

### scenario: AssertIsFalse

```cs
// arrange
var flag = false;

// old assertion:
Assert.IsFalse(flag);

// new assertion:
flag.Should().BeFalse();
```

#### Failure messages

```cs
var flag = true;

// old assertion:
Assert.IsFalse(flag); /* fail message: Assert.IsFalse failed.  */

// new assertion:
flag.Should().BeFalse(); /* fail message: Expected flag to be false, but found True. */
```

### scenario: AssertIsNull

```cs
// arrange
object obj = null;

// old assertion:
Assert.IsNull(obj);

// new assertion:
obj.Should().BeNull();
```

#### Failure messages

```cs
var obj = "foo";

// old assertion:
Assert.IsNull(obj); /* fail message: Assert.IsNull failed.  */

// new assertion:
obj.Should().BeNull(); /* fail message: Expected obj to be <null>, but found "foo". */
```

### scenario: AssertIsNotNull

```cs
// arrange
var obj = new object();

// old assertion:
Assert.IsNotNull(obj);

// new assertion:
obj.Should().NotBeNull();
```

#### Failure messages

```cs
object obj = null;

// old assertion:
Assert.IsNotNull(obj); /* fail message: Assert.IsNotNull failed.  */

// new assertion:
obj.Should().NotBeNull(); /* fail message: Expected obj not to be <null>. */
```

### scenario: AssertIsInstanceOfType

```cs
// arrange
var obj = new List<object>();

// old assertion:
Assert.IsInstanceOfType(obj, typeof(List<object>));
Assert.IsInstanceOfType<List<object>>(obj);

// new assertion:
obj.Should().BeOfType<List<object>>();
```

#### Failure messages

```cs
var obj = new List<int>();

// old assertion:
Assert.IsInstanceOfType(obj, typeof(List<object>)); /* fail message: Assert.IsInstanceOfType failed.  Expected type:<System.Collections.Generic.List`1[System.Object]>. Actual type:<System.Collections.Generic.List`1[System.Int32]>. */
Assert.IsInstanceOfType<List<object>>(obj); /* fail message: Assert.IsInstanceOfType failed.  Expected type:<System.Collections.Generic.List`1[System.Object]>. Actual type:<System.Collections.Generic.List`1[System.Int32]>. */

// new assertion:
obj.Should().BeOfType<List<object>>(); /* fail message: Expected type to be System.Collections.Generic.List`1[[System.Object, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], but found System.Collections.Generic.List`1[[System.Int32, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]. */
```

### scenario: AssertIsNotInstanceOfType

```cs
// arrange
var obj = new List<int>();

// old assertion:
Assert.IsNotInstanceOfType(obj, typeof(List<object>));
Assert.IsNotInstanceOfType<List<object>>(obj);

// new assertion:
obj.Should().NotBeOfType<List<object>>();
```

#### Failure messages

```cs
var obj = new List<object>();

// old assertion:
Assert.IsNotInstanceOfType(obj, typeof(List<object>)); /* fail message: Assert.IsNotInstanceOfType failed. Wrong Type:<System.Collections.Generic.List`1[System.Object]>. Actual type:<System.Collections.Generic.List`1[System.Object]>.  */
Assert.IsNotInstanceOfType<List<object>>(obj); /* fail message: Assert.IsNotInstanceOfType failed. Wrong Type:<System.Collections.Generic.List`1[System.Object]>. Actual type:<System.Collections.Generic.List`1[System.Object]>.  */

// new assertion:
obj.Should().NotBeOfType<List<object>>(); /* fail message: Expected type not to be [System.Collections.Generic.List`1[[System.Object, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e], but it is. */
```

### scenario: AssertObjectAreEqual

```cs
// arrange
object obj1 = "foo";
object obj2 = "foo";

// old assertion:
Assert.AreEqual(obj2, obj1);

// new assertion:
obj1.Should().Be(obj2);
```

#### Failure messages

```cs
object obj1 = "foo";
object obj2 = 42;

// old assertion:
Assert.AreEqual(obj2, obj1); /* fail message: Assert.AreEqual failed. Expected:<42 (System.Int32)>. Actual:<foo (System.String)>.  */

// new assertion:
obj1.Should().Be(obj2); /* fail message: Expected obj1 to be 42, but found "foo". */
```

### scenario: AssertObjectAreEqual_LiteralValue

```cs
// arrange
object obj1 = "foo";

// old assertion:
Assert.AreEqual(obj1, "foo");

// new assertion:
obj1.Should().Be("foo");
```

#### Failure messages

```cs
object obj1 = "foo";

// old assertion:
Assert.AreEqual(obj1, "bar"); /* fail message: Assert.AreEqual failed. Expected:<foo>. Actual:<bar>.  */

// new assertion:
obj1.Should().Be("bar"); /* fail message: Expected obj1 to be "bar", but found "foo". */
```

### scenario: AssertOptionalIntegerAreEqual

```cs
// arrange
int? number1 = 42;
int? number2 = 42;

// old assertion:
Assert.AreEqual(number2, number1);

// new assertion:
number1.Should().Be(number2);
```

#### Failure messages

```cs
int? number1 = 42;
int? number2 = 6;

// old assertion:
Assert.AreEqual(number2, number1); /* fail message: Assert.AreEqual failed. Expected:<6>. Actual:<42>.  */

// new assertion:
number1.Should().Be(number2); /* fail message: Expected number1 to be 6, but found 42 (difference of 36). */
```

### scenario: AssertOptionalIntegerAndNullAreEqual

```cs
// arrange
int? number = null;

// old assertion:
Assert.AreEqual(number, null);
Assert.AreEqual(null, number);

// new assertion:
number.Should().BeNull();
```

#### Failure messages

```cs
int? number = 42;

// old assertion:
Assert.AreEqual(number, null); /* fail message: Assert.AreEqual failed. Expected:<42>. Actual:<(null)>.  */
Assert.AreEqual(null, number); /* fail message: Assert.AreEqual failed. Expected:<(null)>. Actual:<42>.  */

// new assertion:
number.Should().BeNull(); /* fail message: Did not expect a value, but found 42. */
```

### scenario: AssertDoubleAreEqual

```cs
// arrange
double number1 = 3.14;
double number2 = 3.141;
double delta = 0.00159;

// old assertion:
Assert.AreEqual(number2, number1, delta);

// new assertion:
number1.Should().BeApproximately(number2, delta);
```

#### Failure messages

```cs
double number1 = 3.14;
double number2 = 4.2;
double delta = 0.0001;

// old assertion:
Assert.AreEqual(number2, number1, delta); /* fail message: Assert.AreEqual failed. Expected a difference no greater than <0.0001> between expected value <4.2> and actual value <3.14>.  */

// new assertion:
number1.Should().BeApproximately(number2, delta); /* fail message: Expected number1 to approximate 4.2 +/- 0.0001, but 3.14 differed by 1.06. */
```

### scenario: AssertFloatAreEqual

```cs
// arrange
float number1 = 3.14f;
float number2 = 3.141f;
float delta = 0.00159f;

// old assertion:
Assert.AreEqual(number2, number1, delta);

// new assertion:
number1.Should().BeApproximately(number2, delta);
```

#### Failure messages

```cs
float number1 = 3.14f;
float number2 = 4.2f;
float delta = 0.0001f;

// old assertion:
Assert.AreEqual(number2, number1, delta); /* fail message: Assert.AreEqual failed. Expected a difference no greater than <0.0001> between expected value <4.2> and actual value <3.14>.  */

// new assertion:
number1.Should().BeApproximately(number2, delta); /* fail message: Expected number1 to approximate 4.2F +/- 0.0001F, but 3.14F differed by 1.0599997F. */
```

### scenario: AssertStringAreEqual_CaseSensitive

```cs
// arrange
string str1 = "foo";
string str2 = "foo";

// old assertion:
Assert.AreEqual(str2, str1);
Assert.AreEqual(str2, str1, ignoreCase: false);
Assert.AreEqual(str2, str1, ignoreCase: false, culture: CultureInfo.CurrentCulture);

// new assertion:
str1.Should().Be(str2);
```

#### Failure messages

```cs
string str1 = "foo";
string str2 = "FoO";

// old assertion:
Assert.AreEqual(str2, str1); /* fail message: Assert.AreEqual failed. Expected:<FoO>. Actual:<foo>.  */
Assert.AreEqual(str2, str1, ignoreCase: false); /* fail message: Assert.AreEqual failed. Expected:<FoO>. Actual:<foo>.  */
Assert.AreEqual(str2, str1, ignoreCase: false, culture: CultureInfo.CurrentCulture); /* fail message: Assert.AreEqual failed. Expected:<FoO>. Actual:<foo>.  */

// new assertion:
str1.Should().Be(str2); /* fail message: Expected str1 to be "FoO", but "foo" differs near "foo" (index 0). */
```

### scenario: AssertStringAreEqual_IgnoreCase

```cs
// arrange
string str1 = "foo";
string str2 = "FoO";

// old assertion:
Assert.AreEqual(str2, str1, ignoreCase: true);
Assert.AreEqual(str2, str1, ignoreCase: true, culture: CultureInfo.CurrentCulture);

// new assertion:
str1.Should().BeEquivalentTo(str2);
```

#### Failure messages

```cs
string str1 = "foo";
string str2 = "bar";

// old assertion:
Assert.AreEqual(str2, str1, ignoreCase: true); /* fail message: Assert.AreEqual failed. Expected:<bar>. Actual:<foo>.  */
Assert.AreEqual(str2, str1, ignoreCase: true, culture: CultureInfo.CurrentCulture); /* fail message: Assert.AreEqual failed. Expected:<bar>. Actual:<foo>.  */

// new assertion:
str1.Should().BeEquivalentTo(str2); /* fail message: Expected str1 to be equivalent to "bar", but "foo" differs near "foo" (index 0). */
```

### scenario: AssertObjectAreNotEqual

```cs
// arrange
object obj1 = "foo";
object obj2 = "bar";

// old assertion:
Assert.AreNotEqual(obj2, obj1);

// new assertion:
obj1.Should().NotBe(obj2);
```

#### Failure messages

```cs
object obj1 = "foo";
object obj2 = "foo";

// old assertion:
Assert.AreNotEqual(obj2, obj1); /* fail message: Assert.AreNotEqual failed. Expected any value except:<foo>. Actual:<foo>.  */

// new assertion:
obj1.Should().NotBe(obj2); /* fail message: Did not expect obj1 to be equal to "foo". */
```

### scenario: AssertOptionalIntegerAreNotEqual

```cs
// arrange
int? number1 = 42;
int? number2 = 6;

// old assertion:
Assert.AreNotEqual(number2, number1);

// new assertion:
number1.Should().NotBe(number2);
```

#### Failure messages

```cs
int? number1 = 42;
int? number2 = 42;

// old assertion:
Assert.AreNotEqual(number2, number1); /* fail message: Assert.AreNotEqual failed. Expected any value except:<42>. Actual:<42>.  */

// new assertion:
number1.Should().NotBe(number2); /* fail message: Did not expect number1 to be 42. */
```

### scenario: AssertDoubleAreNotEqual

```cs
// arrange
double number1 = 3.14;
double number2 = 4.2;
double delta = 0.0001;

// old assertion:
Assert.AreNotEqual(number2, number1, delta);

// new assertion:
number1.Should().NotBeApproximately(number2, delta);
```

#### Failure messages

```cs
double number1 = 3.14;
double number2 = 3.141;
double delta = 0.00159;

// old assertion:
Assert.AreNotEqual(number2, number1, delta); /* fail message: Assert.AreNotEqual failed. Expected a difference greater than <0.00159> between expected value <3.141> and actual value <3.14>.  */

// new assertion:
number1.Should().NotBeApproximately(number2, delta); /* fail message: Expected number1 to not approximate 3.141 +/- 0.00159, but 3.14 only differed by 0.0009999999999998899. */
```

### scenario: AssertFloatAreNotEqual

```cs
// arrange
float number1 = 3.14f;
float number2 = 4.2f;
float delta = 0.0001f;

// old assertion:
Assert.AreNotEqual(number2, number1, delta);

// new assertion:
number1.Should().NotBeApproximately(number2, delta);
```

#### Failure messages

```cs
float number1 = 3.14f;
float number2 = 3.141f;
float delta = 0.00159f;

// old assertion:
Assert.AreNotEqual(number2, number1, delta); /* fail message: Assert.AreNotEqual failed. Expected a difference greater than <0.00159> between expected value <3.141> and actual value <3.14>.  */

// new assertion:
number1.Should().NotBeApproximately(number2, delta); /* fail message: Expected number1 to not approximate 3.141F +/- 0.00159F, but 3.14F only differed by 0.0009999275F. */
```

### scenario: AssertStringAreNotEqual_CaseSensitive

```cs
// arrange
string str1 = "foo";
string str2 = "bar";

// old assertion:
Assert.AreNotEqual(str2, str1);
Assert.AreNotEqual(str2, str1, ignoreCase: false);
Assert.AreNotEqual(str2, str1, ignoreCase: false, culture: CultureInfo.CurrentCulture);

// new assertion:
str1.Should().NotBe(str2);
```

#### Failure messages

```cs
string str1 = "foo";
string str2 = "foo";

// old assertion:
Assert.AreNotEqual(str2, str1); /* fail message: Assert.AreNotEqual failed. Expected any value except:<foo>. Actual:<foo>.  */
Assert.AreNotEqual(str2, str1, ignoreCase: false); /* fail message: Assert.AreNotEqual failed. Expected any value except:<foo>. Actual:<foo>.  */
Assert.AreNotEqual(str2, str1, ignoreCase: false, culture: CultureInfo.CurrentCulture); /* fail message: Assert.AreNotEqual failed. Expected any value except:<foo>. Actual:<foo>.  */

// new assertion:
str1.Should().NotBe(str2); /* fail message: Expected str1 not to be "foo". */
```

### scenario: AssertStringAreNotEqual_IgnoreCase

```cs
// arrange
string str1 = "foo";
string str2 = "bar";

// old assertion:
Assert.AreNotEqual(str2, str1, ignoreCase: true);
Assert.AreNotEqual(str2, str1, ignoreCase: true, culture: CultureInfo.CurrentCulture);

// new assertion:
str1.Should().NotBeEquivalentTo(str2);
```

#### Failure messages

```cs
string str1 = "foo";
string str2 = "FoO";

// old assertion:
Assert.AreNotEqual(str2, str1, ignoreCase: true); /* fail message: Assert.AreNotEqual failed. Expected any value except:<FoO>. Actual:<foo>.  */
Assert.AreNotEqual(str2, str1, ignoreCase: true, culture: CultureInfo.CurrentCulture); /* fail message: Assert.AreNotEqual failed. Expected any value except:<FoO>. Actual:<foo>.  */

// new assertion:
str1.Should().NotBeEquivalentTo(str2); /* fail message: Expected str1 not to be equivalent to "FoO", but they are. */
```

### scenario: AssertAreSame

```cs
// arrange
var obj1 = new object();
var obj2 = obj1;

// old assertion:
Assert.AreSame(obj2, obj1);

// new assertion:
obj1.Should().BeSameAs(obj2);
```

#### Failure messages

```cs
object obj1 = 6;
object obj2 = "foo";

// old assertion:
Assert.AreSame(obj2, obj1); /* fail message: Assert.AreSame failed.  */

// new assertion:
obj1.Should().BeSameAs(obj2); /* fail message: Expected obj1 to refer to "foo", but found 6. */
```

### scenario: AssertAreNotSame

```cs
// arrange
object obj1 = 6;
object obj2 = "foo";

// old assertion:
Assert.AreNotSame(obj2, obj1);

// new assertion:
obj1.Should().NotBeSameAs(obj2);
```

#### Failure messages

```cs
object obj1 = "foo";
object obj2 = "foo";

// old assertion:
Assert.AreNotSame(obj2, obj1); /* fail message: Assert.AreNotSame failed.  */

// new assertion:
obj1.Should().NotBeSameAs(obj2); /* fail message: Did not expect obj1 to refer to "foo". */
```

### scenario: CollectionAssertAllItemsAreInstancesOfType

```cs
// arrange
var list = new List<object> { 1, 2, 3 };

// old assertion:
CollectionAssert.AllItemsAreInstancesOfType(list, typeof(int));

// new assertion:
list.Should().AllBeOfType<int>();
```

#### Failure messages

```cs
var list = new List<object> { 1, 2, "foo" };

// old assertion:
CollectionAssert.AllItemsAreInstancesOfType(list, typeof(int)); /* fail message: CollectionAssert.AllItemsAreInstancesOfType failed. Element at index 2 is not of expected type. Expected type:<System.Int32>. Actual type:<System.String>. */

// new assertion:
list.Should().AllBeOfType<int>(); /* fail message: Expected type to be "System.Int32", but found "[System.Int32, System.Int32, System.String]". */
```

### scenario: CollectionAssertAreEqual

```cs
// arrange
var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 1, 2, 3 };

// old assertion:
CollectionAssert.AreEqual(list2, list1);

// new assertion:
list1.Should().Equal(list2);
```

#### Failure messages

```cs
var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 1, 2, 4 };

// old assertion:
CollectionAssert.AreEqual(list2, list1); /* fail message: CollectionAssert.AreEqual failed. (Element at index 2 do not match.) */

// new assertion:
list1.Should().Equal(list2); /* fail message: Expected list1 to be equal to {1, 2, 4}, but {1, 2, 3} differs at index 2. */
```

### scenario: CollectionAssertAreNotEqual

```cs
// arrange
var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 1, 2, 4 };

// old assertion:
CollectionAssert.AreNotEqual(list2, list1);

// new assertion:
list1.Should().NotEqual(list2);
```

#### Failure messages

```cs
var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 1, 2, 3 };

// old assertion:
CollectionAssert.AreNotEqual(list2, list1); /* fail message: CollectionAssert.AreNotEqual failed. (Both collection contain same elements.) */

// new assertion:
list1.Should().NotEqual(list2); /* fail message: Did not expect collections {1, 2, 3} and {1, 2, 3} to be equal. */
```

### scenario: CollectionAssertAreEquivalent

```cs
// arrange
var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 3, 2, 1 };

// old assertion:
CollectionAssert.AreEquivalent(list2, list1);

// new assertion:
list1.Should().BeEquivalentTo(list2);
```

#### Failure messages

```cs
var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 2, 3, 4 };

// old assertion:
CollectionAssert.AreEquivalent(list2, list1); /* fail message: CollectionAssert.AreEquivalent failed. The expected collection contains 1 occurrence(s) of <4>. The actual collection contains 0 occurrence(s).  */

// new assertion:
list1.Should().BeEquivalentTo(list2); /* fail message: Expected list1[2] to be 4, but found 1.

With configuration:
- Use declared types and members
- Compare enums by value
- Compare tuples by their properties
- Compare anonymous types by their properties
- Compare records by their members
- Include non-browsable members
- Include all non-private properties
- Include all non-private fields
- Match member by name (or throw)
- Be strict about the order of items in byte arrays
- Without automatic conversion.
 */
```

### scenario: CollectionAssertAreNotEquivalent

```cs
// arrange
var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 2, 3, 4 };

// old assertion:
CollectionAssert.AreNotEquivalent(list2, list1);

// new assertion:
list1.Should().NotBeEquivalentTo(list2);
```

#### Failure messages

```cs
var list1 = new List<int> { 1, 2, 3 };
var list2 = new List<int> { 2, 3, 1 };

// old assertion:
CollectionAssert.AreNotEquivalent(list2, list1); /* fail message: CollectionAssert.AreNotEquivalent failed. Both collections contain the same elements.  */

// new assertion:
list1.Should().NotBeEquivalentTo(list2); /* fail message: Expected list1 {1, 2, 3} not to be equivalent to collection {2, 3, 1}. */
```

### scenario: CollectionAssertAllItemsAreNotNull

```cs
// arrange
var list = new List<object> { 1, "foo", true };

// old assertion:
CollectionAssert.AllItemsAreNotNull(list);

// new assertion:
list.Should().NotContainNulls();
```

#### Failure messages

```cs
var list = new List<object> { 1, null, true };

// old assertion:
CollectionAssert.AllItemsAreNotNull(list); /* fail message: CollectionAssert.AllItemsAreNotNull failed.  */

// new assertion:
list.Should().NotContainNulls(); /* fail message: Expected list not to contain <null>s, but found one at index 1. */
```

### scenario: CollectionAssertAllItemsAreUnique

```cs
// arrange
var list = new List<int> { 1, 2, 3 };

// old assertion:
CollectionAssert.AllItemsAreUnique(list);

// new assertion:
list.Should().OnlyHaveUniqueItems();
```

#### Failure messages

```cs
var list = new List<int> { 1, 2, 1 };

// old assertion:
CollectionAssert.AllItemsAreUnique(list); /* fail message: CollectionAssert.AllItemsAreUnique failed. Duplicate item found:<1>.  */

// new assertion:
list.Should().OnlyHaveUniqueItems(); /* fail message: Expected list to only have unique items, but item 1 is not unique. */
```

### scenario: CollectionAssertContains

```cs
// arrange
var list = new List<int> { 1, 2, 3 };

// old assertion:
CollectionAssert.Contains(list, 2);

// new assertion:
list.Should().Contain(2);
```

#### Failure messages

```cs
var list = new List<int> { 1, 2, 3 };

// old assertion:
CollectionAssert.Contains(list, 4); /* fail message: CollectionAssert.Contains failed.  */

// new assertion:
list.Should().Contain(4); /* fail message: Expected list {1, 2, 3} to contain 4. */
```

### scenario: CollectionAssertDoesNotContain

```cs
// arrange
var list = new List<int> { 1, 2, 3 };

// old assertion:
CollectionAssert.DoesNotContain(list, 4);

// new assertion:
list.Should().NotContain(4);
```

#### Failure messages

```cs
var list = new List<int> { 1, 2, 3 };

// old assertion:
CollectionAssert.DoesNotContain(list, 2); /* fail message: CollectionAssert.DoesNotContain failed.  */

// new assertion:
list.Should().NotContain(2); /* fail message: Expected list {1, 2, 3} to not contain 2. */
```

### scenario: CollectionAssertIsSubsetOf

```cs
// arrange
var list1 = new List<int> { 1, 2, 3, 4 };
var list2 = new List<int> { 2, 3 };

// old assertion:
CollectionAssert.IsSubsetOf(list2, list1);

// new assertion:
list2.Should().BeSubsetOf(list1);
```

#### Failure messages

```cs
var list1 = new List<int> { 1, 2, 3, 4 };
var list2 = new List<int> { 2, 3, 5 };

// old assertion:
CollectionAssert.IsSubsetOf(list2, list1); /* fail message: CollectionAssert.IsSubsetOf failed.  */

// new assertion:
list2.Should().BeSubsetOf(list1); /* fail message: Expected list2 to be a subset of {1, 2, 3, 4}, but items {5} are not part of the superset. */
```

### scenario: CollectionAssertIsNotSubsetOf

```cs
// arrange
var list1 = new List<int> { 1, 2, 3, 4 };
var list2 = new List<int> { 2, 3, 5 };

// old assertion:
CollectionAssert.IsNotSubsetOf(list2, list1);

// new assertion:
list2.Should().NotBeSubsetOf(list1);
```

#### Failure messages

```cs
var list1 = new List<int> { 1, 2, 3, 4 };
var list2 = new List<int> { 2, 3 };

// old assertion:
CollectionAssert.IsNotSubsetOf(list2, list1); /* fail message: CollectionAssert.IsNotSubsetOf failed.  */

// new assertion:
list2.Should().NotBeSubsetOf(list1); /* fail message: Did not expect list2 {2, 3} to be a subset of {1, 2, 3, 4}. */
```

### scenario: AssertThrowsException

```cs
// arrange
static void ThrowException() => throw new InvalidOperationException();
Action action = ThrowException;

// old assertion:
Assert.ThrowsException<InvalidOperationException>(action);

// new assertion:
action.Should().ThrowExactly<InvalidOperationException>();
```

#### Failure messages

```cs
static void ThrowException() => throw new InvalidOperationException();
Action action = ThrowException;

// old assertion:
Assert.ThrowsException<ArgumentException>(action); /* fail message: Assert.ThrowsException failed. Threw exception InvalidOperationException, but exception ArgumentException was expected. 
Exception Message: Operation is not valid due to the current state of the object.
Stack Trace:    at FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs.MsTestAnalyzerTests.<AssertThrowsException_Failure_OldAssertion>g__ThrowException|109_0() in /Users/runner/work/fluentassertions.analyzers/src/FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs/MsTestAnalyzerTests.cs:line 1298
   at Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException[T](Action action, String message, Object[] parameters) */

// new assertion:
action.Should().ThrowExactly<ArgumentException>(); /* fail message: Expected type to be System.ArgumentException, but found System.InvalidOperationException. */
```

### scenario: AssertThrowsExceptionAsync

```cs
// arrange
static Task ThrowExceptionAsync() => throw new InvalidOperationException();
Func<Task> action = ThrowExceptionAsync;

// old assertion:
await Assert.ThrowsExceptionAsync<InvalidOperationException>(action);

// new assertion:
await action.Should().ThrowExactlyAsync<InvalidOperationException>();
```

#### Failure messages

```cs
static Task ThrowExceptionAsync() => throw new InvalidOperationException();
Func<Task> action = ThrowExceptionAsync;

// old assertion:
await Assert.ThrowsExceptionAsync<ArgumentException>(action); /* fail message: Assert.ThrowsException failed. Threw exception InvalidOperationException, but exception ArgumentException was expected. 
Exception Message: Operation is not valid due to the current state of the object.
Stack Trace:    at FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs.MsTestAnalyzerTests.<AssertThrowsExceptionAsync_Failure_OldAssertion>g__ThrowExceptionAsync|112_0() in /Users/runner/work/fluentassertions.analyzers/src/FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs/MsTestAnalyzerTests.cs:line 1334
   at Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsExceptionAsync[T](Func`1 action, String message, Object[] parameters) */

// new assertion:
await action.Should().ThrowExactlyAsync<ArgumentException>(); /* fail message: Expected type to be System.ArgumentException, but found System.InvalidOperationException. */
```

### scenario: StringAssertContains

```cs
// arrange
var str = "foo";

// old assertion:
StringAssert.Contains(str, "oo");

// new assertion:
str.Should().Contain("oo");
```

#### Failure messages

```cs
var str = "foo";

// old assertion:
StringAssert.Contains(str, "bar"); /* fail message: StringAssert.Contains failed. String 'foo' does not contain string 'bar'. . */

// new assertion:
str.Should().Contain("bar"); /* fail message: Expected str "foo" to contain "bar". */
```

### scenario: StringAssertStartsWith

```cs
// arrange
var str = "foo";

// old assertion:
StringAssert.StartsWith(str, "fo");

// new assertion:
str.Should().StartWith("fo");
```

#### Failure messages

```cs
var str = "foo";

// old assertion:
StringAssert.StartsWith(str, "oo"); /* fail message: StringAssert.StartsWith failed. String 'foo' does not start with string 'oo'. . */

// new assertion:
str.Should().StartWith("oo"); /* fail message: Expected str to start with "oo", but "foo" differs near "foo" (index 0). */
```

### scenario: StringAssertEndsWith

```cs
// arrange
var str = "foo";

// old assertion:
StringAssert.EndsWith(str, "oo");

// new assertion:
str.Should().EndWith("oo");
```

#### Failure messages

```cs
var str = "foo";

// old assertion:
StringAssert.EndsWith(str, "fo"); /* fail message: StringAssert.EndsWith failed. String 'foo' does not end with string 'fo'. . */

// new assertion:
str.Should().EndWith("fo"); /* fail message: Expected str "foo" to end with "fo". */
```

### scenario: StringAssertMatches

```cs
// arrange
var str = "foo";
var pattern = new Regex("f.o");

// old assertion:
StringAssert.Matches(str, pattern);

// new assertion:
str.Should().MatchRegex(pattern);
```

#### Failure messages

```cs
var str = "foo";
var pattern = new Regex("b.r");

// old assertion:
StringAssert.Matches(str, pattern); /* fail message: StringAssert.Matches failed. String 'foo' does not match pattern 'b.r'. . */

// new assertion:
str.Should().MatchRegex(pattern); /* fail message: Expected str to match regex "b.r", but "foo" does not match. */
```

### scenario: StringAssertDoesNotMatch

```cs
// arrange
var str = "foo";
var pattern = new Regex("b.r");

// old assertion:
StringAssert.DoesNotMatch(str, pattern);

// new assertion:
str.Should().NotMatchRegex(pattern);
```

#### Failure messages

```cs
var str = "foo";
var pattern = new Regex("f.o");

// old assertion:
StringAssert.DoesNotMatch(str, pattern); /* fail message: StringAssert.DoesNotMatch failed. String 'foo' matches pattern 'f.o'. . */

// new assertion:
str.Should().NotMatchRegex(pattern); /* fail message: Did not expect str to match regex "f.o", but "foo" matches. */
```


