using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

namespace TestNamespace
{
	class TestClass
	{
		void TestMethod(IEnumerable<TestComplexClass> actual)
		{
            actual.Any(x => x.BooleanProperty).Should().BeTrue();

            actual.Should().Contain(x => x.BooleanProperty);
		}
	}

    class TestComplexClass
    {
        public bool BooleanProperty { get; set; }
    }
}