// <copyright file="TestAnalyzerConfigOptionsProvider.cs">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Gérald Barré - https://github.com/meziantou</author>

using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FluentAssertions.Analyzers.TestUtils;

public sealed class TestAnalyzerConfigOptionsProvider : AnalyzerConfigOptionsProvider
{
    public static TestAnalyzerConfigOptionsProvider Empty { get; } = new(ImmutableDictionary<string, string>.Empty);

    private readonly IDictionary<string, string> _values;
    public TestAnalyzerConfigOptionsProvider(IDictionary<string, string> values) => _values = values;

    public override AnalyzerConfigOptions GlobalOptions => new TestAnalyzerConfigOptions(_values);
    public override AnalyzerConfigOptions GetOptions(SyntaxTree tree) => new TestAnalyzerConfigOptions(_values);
    public override AnalyzerConfigOptions GetOptions(AdditionalText textFile) => new TestAnalyzerConfigOptions(_values);

    private sealed class TestAnalyzerConfigOptions : AnalyzerConfigOptions
    {
        private readonly IDictionary<string, string> _values;

        public TestAnalyzerConfigOptions(IDictionary<string, string> values) => _values = values;

        public override bool TryGetValue(string key, out string value)
        {
            return _values.TryGetValue(key, out value);
        }
    }
}