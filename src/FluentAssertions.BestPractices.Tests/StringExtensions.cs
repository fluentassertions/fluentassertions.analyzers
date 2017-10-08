using System;
using System.Collections.Generic;

namespace FluentAssertions.BestPractices.Tests
{
    public static class StringExtensions
    {
        public static string Join(this IEnumerable<string> lines) => string.Join(Environment.NewLine, lines);
    }
}
