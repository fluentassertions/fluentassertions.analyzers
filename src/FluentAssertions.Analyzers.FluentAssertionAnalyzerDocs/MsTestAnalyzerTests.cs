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
    public void BooleanAssertIsTrue_Failure_OldAssertion()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.IsTrue(flag);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void BooleanAssertIsTrue_Failure_NewAssertion()
    {
        // arrange
        var flag = false;

        // new assertion:
        flag.Should().BeTrue();
    }

    [TestMethod]
    public void BooleanAssertIsFalse()
    {
        // arrange
        var flag = false;

        // old assertion:
        Assert.IsFalse(flag);

        // new assertion:
        flag.Should().BeFalse();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void BooleanAssertIsFalse_Failure_OldAssertion()
    {
        // arrange
        var flag = true;

        // old assertion:
        Assert.IsFalse(flag);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void BooleanAssertIsFalse_Failure_NewAssertion()
    {
        // arrange
        var flag = true;

        // new assertion:
        flag.Should().BeFalse();
    }

    [TestMethod]
    public void ObjectAssertIsNull()
    {
        // arrange
        object obj = null;

        // old assertion:
        Assert.IsNull(obj);

        // new assertion:
        obj.Should().BeNull();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void ObjectAssertIsNull_Failure_OldAssertion()
    {
        // arrange
        var obj = "test";

        // old assertion:
        Assert.IsNull(obj);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void ObjectAssertIsNull_Failure_NewAssertion()
    {
        // arrange
        var obj = "test";

        // new assertion:
        obj.Should().BeNull();
    }

    [TestMethod]
    public void ObjectAssertIsNotNull()
    {
        // arrange
        var obj = new object();

        // old assertion:
        Assert.IsNotNull(obj);

        // new assertion:
        obj.Should().NotBeNull();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void ObjectAssertIsNotNull_Failure_OldAssertion()
    {
        // arrange
        object obj = null;

        // old assertion:
        Assert.IsNotNull(obj);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void ObjectAssertIsNotNull_Failure_NewAssertion()
    {
        // arrange
        object obj = null;

        // new assertion:
        obj.Should().NotBeNull();
    }

    [TestMethod]
    public void ReferenceTypeAssertIsInstanceOfType()
    {
        // arrange
        var obj = new List<object>();

        // old assertion:
        Assert.IsInstanceOfType(obj, typeof(List<object>));
        Assert.IsInstanceOfType<List<object>>(obj);

        // new assertion:
        obj.Should().BeOfType<List<object>>();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void ReferenceTypeAssertIsInstanceOfType_Failure_OldAssertion_0()
    {
        // arrange
        var obj = new List<int>();

        // old assertion:
        Assert.IsInstanceOfType(obj, typeof(List<object>));
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void ReferenceTypeAssertIsInstanceOfType_Failure_OldAssertion_1()
    {
        // arrange
        var obj = new List<int>();

        // old assertion:
        Assert.IsInstanceOfType<List<object>>(obj);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void ReferenceTypeAssertIsInstanceOfType_Failure_NewAssertion()
    {
        // arrange
        var obj = new List<int>();

        // new assertion:
        obj.Should().BeOfType<List<object>>();
    }

    [TestMethod]
    public void ReferenceTypeAssertIsNotInstanceOfType()
    {
        // arrange
        var obj = new List<int>();

        // old assertion:
        Assert.IsNotInstanceOfType(obj, typeof(List<object>));
        Assert.IsNotInstanceOfType<List<object>>(obj);

        // new assertion:
        obj.Should().NotBeOfType<List<object>>();
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void ReferenceTypeAssertIsNotInstanceOfType_Failure_OldAssertion_0()
    {
        // arrange
        var obj = new List<object>();

        // old assertion:
        Assert.IsNotInstanceOfType(obj, typeof(List<object>));
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void ReferenceTypeAssertIsNotInstanceOfType_Failure_OldAssertion_1()
    {
        // arrange
        var obj = new List<object>();

        // old assertion:
        Assert.IsNotInstanceOfType<List<object>>(obj);
    }

    [TestMethod, ExpectedException(typeof(AssertFailedException))]
    public void ReferenceTypeAssertIsNotInstanceOfType_Failure_NewAssertion()
    {
        // arrange
        var obj = new List<object>();

        // new assertion:
        obj.Should().NotBeOfType<List<object>>();
    }
}