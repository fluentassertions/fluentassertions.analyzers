<!--
This is a generated file, please edit src\FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator\DocsGenerator.cs to change the contents
-->

# Nunit4 Analyzer Docs

- [BooleanAssertIsTrue](#scenario-booleanassertistrue) - `flag.Should().BeTrue();`


## Scenarios

### scenario: BooleanAssertIsTrue

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


