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
var obj = "test";

// old assertion:
Assert.IsNull(obj); 	// fail message: Assert.IsNull failed. 

// new assertion:
obj.Should().BeNull(); 	// fail message: Expected obj to be <null>, but found "test".
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


