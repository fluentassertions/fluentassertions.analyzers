<!--
This is a generated file, please edit src\FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator\DocsGenerator.cs to change the contents
-->

# MsTest Analyzer Docs

- [BooleanAssertIsTrue](#scenario-booleanassertistrue) - `flag.Should().BeTrue();`
- [BooleanAssertIsFalse](#scenario-booleanassertisfalse) - `flag.Should().BeFalse();`
- [ObjectAssertIsNull](#scenario-objectassertisnull) - `obj.Should().BeNull();`
- [ObjectAssertIsNotNull](#scenario-objectassertisnotnull) - `obj.Should().NotBeNull();`
- [ReferenceTypeAssertIsInstanceOfType](#scenario-referencetypeassertisinstanceoftype) - `obj.Should().BeOfType<List<object>>();`
- [ReferenceTypeAssertIsNotInstanceOfType](#scenario-referencetypeassertisnotinstanceoftype) - `obj.Should().NotBeOfType<List<object>>();`
- [AssertObjectAreEqual](#scenario-assertobjectareequal) - `obj1.Should().Be(obj2);`
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


## Scenarios

### scenario: BooleanAssertIsTrue

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
Assert.IsTrue(flag); 	// fail message: Assert.IsTrue failed. 

// new assertion:
flag.Should().BeTrue(); 	// fail message: Expected flag to be true, but found False.
```

### scenario: BooleanAssertIsFalse

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
Assert.IsFalse(flag); 	// fail message: Assert.IsFalse failed. 

// new assertion:
flag.Should().BeFalse(); 	// fail message: Expected flag to be false, but found True.
```

### scenario: ObjectAssertIsNull

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
Assert.IsNull(obj); 	// fail message: Assert.IsNull failed. 

// new assertion:
obj.Should().BeNull(); 	// fail message: Expected obj to be <null>, but found "foo".
```

### scenario: ObjectAssertIsNotNull

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
Assert.IsNotNull(obj); 	// fail message: Assert.IsNotNull failed. 

// new assertion:
obj.Should().NotBeNull(); 	// fail message: Expected obj not to be <null>.
```

### scenario: ReferenceTypeAssertIsInstanceOfType

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
Assert.IsInstanceOfType(obj, typeof(List<object>)); 	// fail message: Assert.IsInstanceOfType failed.  Expected type:<System.Collections.Generic.List`1[System.Object]>. Actual type:<System.Collections.Generic.List`1[System.Int32]>.
Assert.IsInstanceOfType<List<object>>(obj); 	// fail message: Assert.IsInstanceOfType failed.  Expected type:<System.Collections.Generic.List`1[System.Object]>. Actual type:<System.Collections.Generic.List`1[System.Int32]>.

// new assertion:
obj.Should().BeOfType<List<object>>(); 	// fail message: Expected type to be System.Collections.Generic.List`1[[System.Object, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], but found System.Collections.Generic.List`1[[System.Int32, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]].
```

### scenario: ReferenceTypeAssertIsNotInstanceOfType

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
Assert.IsNotInstanceOfType(obj, typeof(List<object>)); 	// fail message: Assert.IsNotInstanceOfType failed. Wrong Type:<System.Collections.Generic.List`1[System.Object]>. Actual type:<System.Collections.Generic.List`1[System.Object]>. 
Assert.IsNotInstanceOfType<List<object>>(obj); 	// fail message: Assert.IsNotInstanceOfType failed. Wrong Type:<System.Collections.Generic.List`1[System.Object]>. Actual type:<System.Collections.Generic.List`1[System.Object]>. 

// new assertion:
obj.Should().NotBeOfType<List<object>>(); 	// fail message: Expected type not to be [System.Collections.Generic.List`1[[System.Object, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e], but it is.
```

### scenario: AssertObjectAreEqual

```cs
// arrange
object obj1 = "foo";
object obj2 = "foo";

// old assertion:
Assert.AreEqual(obj1, obj2);

// new assertion:
obj1.Should().Be(obj2);
```

#### Failure messages

```cs
object obj1 = "foo";
object obj2 = 42;

// old assertion:
Assert.AreEqual(obj1, obj2); 	// fail message: Assert.AreEqual failed. Expected:<foo (System.String)>. Actual:<42 (System.Int32)>. 

// new assertion:
obj1.Should().Be(obj2); 	// fail message: Expected obj1 to be 42, but found "foo".
```

### scenario: AssertOptionalIntegerAreEqual

```cs
// arrange
int? number1 = 42;
int? number2 = 42;

// old assertion:
Assert.AreEqual(number1, number2);

// new assertion:
number1.Should().Be(number2);
```

#### Failure messages

```cs
int? number1 = 42;
int? number2 = 6;

// old assertion:
Assert.AreEqual(number1, number2); 	// fail message: Assert.AreEqual failed. Expected:<42>. Actual:<6>. 

// new assertion:
number1.Should().Be(number2); 	// fail message: Expected number1 to be 6, but found 42 (difference of 36).
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
Assert.AreEqual(number, null); 	// fail message: Assert.AreEqual failed. Expected:<42>. Actual:<(null)>. 
Assert.AreEqual(null, number); 	// fail message: Assert.AreEqual failed. Expected:<(null)>. Actual:<42>. 

// new assertion:
number.Should().BeNull(); 	// fail message: Did not expect a value, but found 42.
```

### scenario: AssertDoubleAreEqual

```cs
// arrange
double number1 = 3.14;
double number2 = 3.141;
double delta = 0.00159;

// old assertion:
Assert.AreEqual(number1, number2, delta);

// new assertion:
number1.Should().BeApproximately(number2, delta);
```

#### Failure messages

```cs
double number1 = 3.14;
double number2 = 4.2;
double delta = 0.0001;

// old assertion:
Assert.AreEqual(number1, number2, delta); 	// fail message: Assert.AreEqual failed. Expected a difference no greater than <0.0001> between expected value <3.14> and actual value <4.2>. 

// new assertion:
number1.Should().BeApproximately(number2, delta); 	// fail message: Expected number1 to approximate 4.2 +/- 0.0001, but 3.14 differed by 1.06.
```

### scenario: AssertFloatAreEqual

```cs
// arrange
float number1 = 3.14f;
float number2 = 3.141f;
float delta = 0.00159f;

// old assertion:
Assert.AreEqual(number1, number2, delta);

// new assertion:
number1.Should().BeApproximately(number2, delta);
```

#### Failure messages

```cs
float number1 = 3.14f;
float number2 = 4.2f;
float delta = 0.0001f;

// old assertion:
Assert.AreEqual(number1, number2, delta); 	// fail message: Assert.AreEqual failed. Expected a difference no greater than <0.0001> between expected value <3.14> and actual value <4.2>. 

// new assertion:
number1.Should().BeApproximately(number2, delta); 	// fail message: Expected number1 to approximate 4.2F +/- 0.0001F, but 3.14F differed by 1.0599997F.
```

### scenario: AssertStringAreEqual_CaseSensitive

```cs
// arrange
string str1 = "foo";
string str2 = "foo";

// old assertion:
Assert.AreEqual(str1, str2);
Assert.AreEqual(str1, str2, ignoreCase: false);
Assert.AreEqual(str1, str2, ignoreCase: false, culture: CultureInfo.CurrentCulture);

// new assertion:
str1.Should().Be(str2);
```

#### Failure messages

```cs
string str1 = "foo";
string str2 = "FoO";

// old assertion:
Assert.AreEqual(str1, str2); 	// fail message: Assert.AreEqual failed. Expected:<foo>. Actual:<FoO>. 
Assert.AreEqual(str1, str2, ignoreCase: false); 	// fail message: Assert.AreEqual failed. Expected:<foo>. Actual:<FoO>. 
Assert.AreEqual(str1, str2, ignoreCase: false, culture: CultureInfo.CurrentCulture); 	// fail message: Assert.AreEqual failed. Expected:<foo>. Actual:<FoO>. 

// new assertion:
str1.Should().Be(str2); 	// fail message: Expected str1 to be "FoO", but "foo" differs near "foo" (index 0).
```

### scenario: AssertStringAreEqual_IgnoreCase

```cs
// arrange
string str1 = "foo";
string str2 = "FoO";

// old assertion:
Assert.AreEqual(str1, str2, ignoreCase: true);
Assert.AreEqual(str1, str2, ignoreCase: true, culture: CultureInfo.CurrentCulture);

// new assertion:
str1.Should().BeEquivalentTo(str2);
```

#### Failure messages

```cs
string str1 = "foo";
string str2 = "bar";

// old assertion:
Assert.AreEqual(str1, str2, ignoreCase: true); 	// fail message: Assert.AreEqual failed. Expected:<foo>. Actual:<bar>. 
Assert.AreEqual(str1, str2, ignoreCase: true, culture: CultureInfo.CurrentCulture); 	// fail message: Assert.AreEqual failed. Expected:<foo>. Actual:<bar>. 

// new assertion:
str1.Should().BeEquivalentTo(str2); 	// fail message: Expected str1 to be equivalent to "bar", but "foo" differs near "foo" (index 0).
```

### scenario: AssertObjectAreNotEqual

```cs
// arrange
object obj1 = "foo";
object obj2 = "bar";

// old assertion:
Assert.AreNotEqual(obj1, obj2);

// new assertion:
obj1.Should().NotBe(obj2);
```

#### Failure messages

```cs
object obj1 = "foo";
object obj2 = "foo";

// old assertion:
Assert.AreNotEqual(obj1, obj2); 	// fail message: Assert.AreNotEqual failed. Expected any value except:<foo>. Actual:<foo>. 

// new assertion:
obj1.Should().NotBe(obj2); 	// fail message: Did not expect obj1 to be equal to "foo".
```

### scenario: AssertOptionalIntegerAreNotEqual

```cs
// arrange
int? number1 = 42;
int? number2 = 6;

// old assertion:
Assert.AreNotEqual(number1, number2);

// new assertion:
number1.Should().NotBe(number2);
```

#### Failure messages

```cs
int? number1 = 42;
int? number2 = 42;

// old assertion:
Assert.AreNotEqual(number1, number2); 	// fail message: Assert.AreNotEqual failed. Expected any value except:<42>. Actual:<42>. 

// new assertion:
number1.Should().NotBe(number2); 	// fail message: Did not expect number1 to be 42.
```

### scenario: AssertDoubleAreNotEqual

```cs
// arrange
double number1 = 3.14;
double number2 = 4.2;
double delta = 0.0001;

// old assertion:
Assert.AreNotEqual(number1, number2, delta);

// new assertion:
number1.Should().NotBeApproximately(number2, delta);
```

#### Failure messages

```cs
double number1 = 3.14;
double number2 = 3.141;
double delta = 0.00159;

// old assertion:
Assert.AreNotEqual(number1, number2, delta); 	// fail message: Assert.AreNotEqual failed. Expected a difference greater than <0.00159> between expected value <3.14> and actual value <3.141>. 

// new assertion:
number1.Should().NotBeApproximately(number2, delta); 	// fail message: Expected number1 to not approximate 3.141 +/- 0.00159, but 3.14 only differed by 0.0009999999999998899.
```

### scenario: AssertFloatAreNotEqual

```cs
// arrange
float number1 = 3.14f;
float number2 = 4.2f;
float delta = 0.0001f;

// old assertion:
Assert.AreNotEqual(number1, number2, delta);

// new assertion:
number1.Should().NotBeApproximately(number2, delta);
```

#### Failure messages

```cs
float number1 = 3.14f;
float number2 = 3.141f;
float delta = 0.00159f;

// old assertion:
Assert.AreNotEqual(number1, number2, delta); 	// fail message: Assert.AreNotEqual failed. Expected a difference greater than <0.00159> between expected value <3.14> and actual value <3.141>. 

// new assertion:
number1.Should().NotBeApproximately(number2, delta); 	// fail message: Expected number1 to not approximate 3.141F +/- 0.00159F, but 3.14F only differed by 0.0009999275F.
```

### scenario: AssertStringAreNotEqual_CaseSensitive

```cs
// arrange
string str1 = "foo";
string str2 = "bar";

// old assertion:
Assert.AreNotEqual(str1, str2);
Assert.AreNotEqual(str1, str2, ignoreCase: false);
Assert.AreNotEqual(str1, str2, ignoreCase: false, culture: CultureInfo.CurrentCulture);

// new assertion:
str1.Should().NotBe(str2);
```

#### Failure messages

```cs
string str1 = "foo";
string str2 = "foo";

// old assertion:
Assert.AreNotEqual(str1, str2); 	// fail message: Assert.AreNotEqual failed. Expected any value except:<foo>. Actual:<foo>. 
Assert.AreNotEqual(str1, str2, ignoreCase: false); 	// fail message: Assert.AreNotEqual failed. Expected any value except:<foo>. Actual:<foo>. 
Assert.AreNotEqual(str1, str2, ignoreCase: false, culture: CultureInfo.CurrentCulture); 	// fail message: Assert.AreNotEqual failed. Expected any value except:<foo>. Actual:<foo>. 

// new assertion:
str1.Should().NotBe(str2); 	// fail message: Expected str1 not to be "foo".
```

### scenario: AssertStringAreNotEqual_IgnoreCase

```cs
// arrange
string str1 = "foo";
string str2 = "bar";

// old assertion:
Assert.AreNotEqual(str1, str2, ignoreCase: true);
Assert.AreNotEqual(str1, str2, ignoreCase: true, culture: CultureInfo.CurrentCulture);

// new assertion:
str1.Should().NotBeEquivalentTo(str2);
```

#### Failure messages

```cs
string str1 = "foo";
string str2 = "FoO";

// old assertion:
Assert.AreNotEqual(str1, str2, ignoreCase: true); 	// fail message: Assert.AreNotEqual failed. Expected any value except:<foo>. Actual:<FoO>. 
Assert.AreNotEqual(str1, str2, ignoreCase: true, culture: CultureInfo.CurrentCulture); 	// fail message: Assert.AreNotEqual failed. Expected any value except:<foo>. Actual:<FoO>. 

// new assertion:
str1.Should().NotBeEquivalentTo(str2); 	// fail message: Expected str1 not to be equivalent to "FoO", but they are.
```


