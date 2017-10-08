using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.BestPractices.Tests
{
    [TestClass]
    public class CollectionTests
    {
        [TestMethod]
        [Description("actual.Any().Should().BeTrue();")]
        [Implemented]
        public void CollectionsShouldNotBeEmpty_TestAnalyzer()
        {
            var source = GenerateCode.EnumerableAssertion($"{GenerateCode.VariableName}.Any().Should().BeTrue();");

            DiagnosticVerifier.VerifyCSharpDiagnostic<CollectionsShouldNotBeEmptyAnalyzer>(source, new DiagnosticResult
            {
                Id = CollectionsShouldNotBeEmptyAnalyzer.DiagnosticId,
                Message = string.Format(CollectionsShouldNotBeEmptyAnalyzer.Message, GenerateCode.VariableName),
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 7,13)
                },
                Severity = DiagnosticSeverity.Info
            });
        }

        [TestMethod]
        [Description("old: actual.Any().Should().BeTrue(); new: actual.Should().NotBeEmpty();")]
        [Implemented]
        public void CollectionsShouldNotBeEmpty_TestCodeFix()
        {
            var oldSource = GenerateCode.EnumerableAssertion($"{GenerateCode.VariableName}.Any().Should().BeTrue();");
            var newSource = GenerateCode.EnumerableAssertion($"{GenerateCode.VariableName}.Should().NotBeEmpty();");

            DiagnosticVerifier.VerifyCSharpFix<CollectionsShouldNotBeEmptyCodeFix, CollectionsShouldNotBeEmptyAnalyzer>(oldSource, newSource);
        }

        [TestMethod]
        [Description("actual.Any().Should().BeFalse();")]
        [Implemented]
        public void CollectionsShouldBeEmpty_TestAnalyzer()
        {
            var source = GenerateCode.EnumerableAssertion($"{GenerateCode.VariableName}.Any().Should().BeFalse();");

            DiagnosticVerifier.VerifyCSharpDiagnostic<CollectionsShouldBeEmptyAnalyzer>(source, new DiagnosticResult
            {
                Id = CollectionsShouldBeEmptyAnalyzer.DiagnosticId,
                Message = string.Format(CollectionsShouldBeEmptyAnalyzer.Message, GenerateCode.VariableName),
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 7,13)
                },
                Severity = DiagnosticSeverity.Info
            });
        }

        [TestMethod]
        [Description("old: actual.Any().Should().BeFalse(); new: actual.Should().BeEmpty();")]
        [Implemented]
        public void CollectionsShouldBeEmpty_TestCodeFix()
        {
            var oldSource = GenerateCode.EnumerableAssertion($"{GenerateCode.VariableName}.Any().Should().BeFalse();");
            var newSource = GenerateCode.EnumerableAssertion($"{GenerateCode.VariableName}.Should().BeEmpty();");

            DiagnosticVerifier.VerifyCSharpFix<CollectionsShouldBeEmptyCodeFix, CollectionsShouldBeEmptyAnalyzer>(oldSource, newSource);
        }

        [TestMethod]
        [Description("actual.Any(x => x.BooleanProperty).Should().BeTrue();")]
        [Implemented]
        public void CollectionShouldContainProperty_TestAnalyzer()
        {
            var source = GenerateCode.EnumerableAssertion($"{GenerateCode.VariableName}.Any(x => x.{GenerateCode.ComplexClassBooleanpropertyName}).Should().BeTrue();");

            DiagnosticVerifier.VerifyCSharpDiagnostic<CollectionShouldContainPropertyAnalyzer>(source, new DiagnosticResult
            {
                Id = CollectionShouldContainPropertyAnalyzer.DiagnosticId,
                Message = string.Format(CollectionShouldContainPropertyAnalyzer.Message, GenerateCode.VariableName),
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 7,13)
                },
                Severity = DiagnosticSeverity.Info
            });
        }

        [TestMethod]
        [Description("old: actual.Any(x => x.BooleanProperty).Should().BeTrue(); new: actual.Should().Contain(x => x.BooleanProperty);")]
        [Implemented]
        public void CollectionShouldContainProperty_TestCodeFix()
        {
            var oldSource = GenerateCode.EnumerableAssertion($"{GenerateCode.VariableName}.Any(x => x.{GenerateCode.ComplexClassBooleanpropertyName}).Should().BeTrue();");
            var newSource = GenerateCode.EnumerableAssertion($"{GenerateCode.VariableName}.Should().Contain(x => x.{GenerateCode.ComplexClassBooleanpropertyName});");

            DiagnosticVerifier.VerifyCSharpFix<CollectionShouldContainPropertyCodeFix, CollectionShouldContainPropertyAnalyzer>(oldSource, newSource);
        }

        [TestMethod]
        [Description("actual.Any(x => x.BooleanProperty).Should().BeFalse();")]
        [Implemented]
        public void CollectionShouldNotContainProperty_TestAnalyzer()
        {
            var source = GenerateCode.EnumerableAssertion($"{GenerateCode.VariableName}.Any(x => x.{GenerateCode.ComplexClassBooleanpropertyName}).Should().BeFalse();");

            DiagnosticVerifier.VerifyCSharpDiagnostic<CollectionShouldNotContainPropertyAnalyzer>(source, new DiagnosticResult
            {
                Id = CollectionShouldNotContainPropertyAnalyzer.DiagnosticId,
                Message = string.Format(CollectionShouldNotContainPropertyAnalyzer.Message, GenerateCode.VariableName),
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 7,13)
                },
                Severity = DiagnosticSeverity.Info
            });
        }

        [TestMethod]
        [Description("old: actual.Any(x => x.BooleanProperty).Should().BeFalse(); new: actual.Should().NotContain(x => x.BooleanProperty);")]
        [Implemented]
        public void CollectionShouldNotContainProperty_TestCodeFix()
        {
            var oldSource = GenerateCode.EnumerableAssertion($"{GenerateCode.VariableName}.Any(x => x.{GenerateCode.ComplexClassBooleanpropertyName}).Should().BeFalse();");
            var newSource = GenerateCode.EnumerableAssertion($"{GenerateCode.VariableName}.Should().NotContain(x => x.{GenerateCode.ComplexClassBooleanpropertyName});");

            DiagnosticVerifier.VerifyCSharpFix<CollectionShouldNotContainPropertyCodeFix, CollectionShouldNotContainPropertyAnalyzer>(oldSource, newSource);
        }

        [TestMethod]
        [Description("actual.All(x => x.BooleanProperty).Should().BeTrue();")]
        [NotImplemented]
        public void CollectionShouldOnlyContainProperty_TestAnalyzer()
        {
            var source = $"{GenerateCode.VariableName}.Any(x => x.{GenerateCode.ComplexClassBooleanpropertyName}).Should().BeFalse();";

            DiagnosticVerifier.VerifyCSharpDiagnostic<CollectionShouldContainPropertyAnalyzer>(source, new DiagnosticResult
            {
                Id = CollectionShouldContainPropertyAnalyzer.DiagnosticId,
                Message = string.Format(CollectionShouldContainPropertyAnalyzer.Message, GenerateCode.VariableName),
                Locations = new DiagnosticResultLocation[]
                {
                    new DiagnosticResultLocation("Test0.cs", 7,13)
                },
                Severity = DiagnosticSeverity.Info
            });
        }

        [TestMethod]
        [Description("old: actual.All(x => x.BooleanProperty).Should().BeTrue(); new: actual.Should().OnlyContain(x => x.BooleanProperty);")]
        [NotImplemented]
        public void CollectionShouldOnlyContainProperty_TestCodeFix()
        {
            var oldSource = $"{GenerateCode.VariableName}.Any(x => x.{GenerateCode.ComplexClassBooleanpropertyName}).Should().BeFalse();";
            var newSource = $"{GenerateCode.VariableName}.Should()Not.Contain(x => x.{GenerateCode.ComplexClassBooleanpropertyName});";

            DiagnosticVerifier.VerifyCSharpFix<CollectionShouldContainPropertyCodeFix, CollectionShouldContainPropertyAnalyzer>(oldSource, newSource);
        }
        
        [TestMethod]
        [Description("actual.Contains(expected).Should().BeTrue();")]
        [NotImplemented]
        public void CollectionShouldContainItem_TestAnalyzer()
        {
            
        }
        
        [TestMethod]
        [Description("old: actual.Contains(expected).Should().BeTrue(); new: actual.Should().Contain(expected);")]
        [NotImplemented]
        public void CollectionShouldContainItem_TestCodeFix()
        {
            
        }
        
        [TestMethod]
        [Description("actual.Contains(unexpected).Should().BeTrue();")]
        [NotImplemented]
        public void CollectionShouldNotContainItem_TestAnalyzer()
        {
            
        }
        
        [TestMethod]
        [Description("old: actual.Contains(unexpected).Should().BeTrue(); new: actual.Should().NotContain(unexpected);")]
        [NotImplemented]
        public void CollectionShouldNotContainItem_TestCodeFix()
        {
            
        }
        
        [TestMethod]
        [Description("actual.Count().Should().Be(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCount_TestAnalyzer()
        {
            
        }
        
        [TestMethod]
        [Description("old: actual.Count().Should().Be(k); new: actual.Should().HaveCount(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCount_TestCodeFix()
        {
            
        }
        
        [TestMethod]
        [Description("actual.Count().Should().BeGreaterThan(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountGreaterThan_TestAnalyzer()
        {
            
        }
        
        [TestMethod]
        [Description("old: actual.Count().Should().BeGreaterThan(k); new: actual.Should().HaveCountGreaterThan(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountGreaterThan_TestCodeFix()
        {
            
        }
        
        [TestMethod]
        [Description("actual.Count().Should().BeGreaterOrEqualTo(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountGreaterOrEqualTo_TestAnalyzer()
        {
            
        }
        
        [TestMethod]
        [Description("old: actual.Count().Should().BeGreaterOrEqualTo(k); new: actual.Should().HaveCountGreaterOrEqualTo(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountGreaterOrEqualTo_TestCodeFix()
        {
            
        }
        
        [TestMethod]
        [Description("actual.Count().Should().BeLessThan(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessThan_TestAnalyzer()
        {
            
        }
        
        [TestMethod]
        [Description("old: actual.Count().Should().BeLessThan(k); new: actual.Should().HaveCountLessThan(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessThan_TestCodeFix()
        {
            
        }
        
        [TestMethod]
        [Description("actual.Count().Should().BeLessOrEqualTo(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessOrEqualTo_TestAnalyzer()
        {
            
        }
        
        [TestMethod]
        [Description("old: actual.Count().Should().BeLessOrEqualTo(k); new: actual.Should().HaveCountLessOrEqualTo(k);")]
        [NotImplemented]
        public void CollectionShouldHaveCountLessOrEqualTo_TestCodeFix()
        {
            
        }
        
        [TestMethod]
        [Description("actual.Count().Should().NotBe(k);")]
        [NotImplemented]
        public void CollectionShouldNotHaveCount_TestAnalyzer()
        {
            
        }
        
        [TestMethod]
        [Description("old: actual.Count().Should().NotBe(k); new: actual.Should().NotHaveCount(k);")]
        [NotImplemented]
        public void CollectionShouldNotHaveCount_TestCodeFix()
        {
            
        }
        
        [TestMethod]
        [Description("actual.Should().HaveCount(1);")]
        [NotImplemented]
        public void CollectionShouldContainSingle_TestAnalyzer()
        {
            
        }
        
        [TestMethod]
        [Description("old: actual.Should().HaveCount(1); new: actual.Should().ContainSingle();")]
        [NotImplemented]
        public void CollectionShouldContainSingle_TestCodeFix()
        {
            
        }
        
        // actual.Should().HaveCount(0);
    }
}
