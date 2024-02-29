using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

[TestClass]
public class FluentAssertionsAnalyzerTests
{
    [TestMethod]
    public void CollectionsShouldNotBeEmpty()
    {
        // arrange
        var collection = new List<int> { 1, 2, 3 };

        // old assertion:
        collection.Any().Should().BeTrue();
        // new assertion:
        collection.Should().NotBeEmpty();
    }

    [TestMethod]
    public void CollectionsShouldBeEmpty()
    {
        // arrange
        var collection = new List<int>();

        // old assertion:
        collection.Any().Should().BeFalse();
        // new assertion:
        collection.Should().BeEmpty();
    }
}