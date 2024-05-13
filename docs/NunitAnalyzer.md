<!--
This is a generated file, please edit src\FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator\DocsGenerator.cs to change the contents
-->

# Nunit Analyzer Docs

- [BooleanAssertIsTrue](#scenario-booleanassertistrue) - `flag.Should().BeTrue();`
- [BooleanAssertIsFalse](#scenario-booleanassertisfalse) - `flag.Should().BeFalse();`


## Scenarios

### scenario: BooleanAssertIsTrue

```cs
// arrange
var flag = true;

// old assertion:
Assert.IsTrue(flag);
Assert.True(flag);

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

// new assertion:
flag.Should().BeTrue(); /* fail message: Expected flag to be true, but found False. */
```

### scenario: BooleanAssertIsFalse

```cs
// arrange
var flag = false;

// old assertion:
Assert.IsFalse(flag);
Assert.False(flag);

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

// new assertion:
flag.Should().BeFalse(); /* fail message: Expected flag to be false, but found True. */
```


