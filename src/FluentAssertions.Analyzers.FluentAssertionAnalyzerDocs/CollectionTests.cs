using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

[TestClass]
public class CollectionTests
{
    [TestMethod]
    public void CollectionsShouldNotBeEmpty()
    {
        // arrange
        IList<TestComplexClass> collection = new List<TestComplexClass>
        {
            new TestComplexClass { BooleanProperty = true, Message = 1 },
            new TestComplexClass { BooleanProperty = false, Message = 2 }
        };

        // assert
        collection.Any().Should().BeTrue();
    }

    public class TestComplexClass
    {
        public bool BooleanProperty { get; set; }
        public int Message { get; set; }
    }
}