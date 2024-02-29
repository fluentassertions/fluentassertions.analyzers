# FluentAssertions Analyzer Docs
## method: CollectionsShouldNotBeEmpty

```cs
// arrange
var collection = new List<int> { 1, 2, 3 };

// old assertion:
collection.Any().Should().BeTrue();
// new assertion:
collection.Should().NotBeEmpty();
```

## method: CollectionsShouldBeEmpty

```cs
// arrange
var collection = new List<int>();

// old assertion:
collection.Any().Should().BeFalse();
// new assertion:
collection.Should().BeEmpty();
```

