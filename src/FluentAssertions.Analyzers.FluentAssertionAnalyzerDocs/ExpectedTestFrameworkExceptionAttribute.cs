using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs;

public class ExpectedTestFrameworkExceptionAttribute : ExpectedExceptionBaseAttribute
{
    private static readonly HashSet<Type> TestFrameworkExceptions =
    [
        typeof(Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException), // MSTest
        typeof(NUnit.Framework.AssertionException), // NUnit
    ];

    protected override void Verify(Exception exception)
    {
        Type type = exception.GetType();

        if (!TestFrameworkExceptions.Any(exceptionType => exceptionType.GetTypeInfo().IsAssignableFrom(type.GetTypeInfo())))
        {
            throw new AssertionFailedException("TestMethodWrongExceptionDerivedAllowed");
        }
    }
}