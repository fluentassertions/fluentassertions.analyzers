using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

[TestClass]
public class MsTestAnalyzerTests
{
    [TestMethod]
    public void BooleanAssertIsTrue()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.IsTrue(flag);

        // new assertion:
        flag.Should().BeTrue();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void BooleanAssertIsTrue_Failure()
    {
        using var scope = new AssertionScope();
        // arrange
        var flag = false;

        // old assertion:
        Assert.IsTrue(flag);

        // new assertion:
        flag.Should().BeTrue();
    }
}