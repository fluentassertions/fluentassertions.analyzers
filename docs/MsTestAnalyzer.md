<!--
This is a generated file, please edit src\FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator\DocsGenerator.cs to change the contents
-->

# MsTest Analyzer Docs

- [BooleanAssertIsTrue](#scenario-booleanassertistrue) - `flag.Should().BeTrue();`


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
// arrange
var flag = false;

// old assertion:
Assert.IsTrue(flag); 	// fail message: Assert.IsTrue failed. 

// new assertion:
flag.Should().BeTrue(); 	// fail message: Assert.IsTrue failed. 
```


