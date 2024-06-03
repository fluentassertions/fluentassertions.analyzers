<!--
This is a generated file, please edit src\FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator\DocsGenerator.cs to change the contents
-->

# Xunit Analyzer Docs

- [AssertTrue](#scenario-asserttrue) - `flag.Should().BeTrue();`
- [AssertFalse](#scenario-assertfalse) - `flag.Should().BeFalse();`


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
flag.Should().BeTrue(); /* fail message: Expected flag to be true, but found False. */
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
flag.Should().BeFalse(); /* fail message: Expected flag to be false, but found True. */
```


