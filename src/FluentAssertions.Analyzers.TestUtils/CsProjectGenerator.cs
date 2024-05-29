using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using FluentAssertions.Execution;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

using XunitAssert = Xunit.Assert;
using System.Net.Http;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;

namespace FluentAssertions.Analyzers.TestUtils
{
    public class CsProjectGenerator
    {
        static CsProjectGenerator()
        {
            References = new[]
            {
                typeof(object), // System.Private.CoreLib
                typeof(Console), // System
                typeof(Uri), // System.Private.Uri
                typeof(Enumerable), // System.Linq
                typeof(CSharpCompilation), // Microsoft.CodeAnalysis.CSharp
                typeof(Compilation), // Microsoft.CodeAnalysis
                typeof(AssertionScope), // FluentAssertions.Core
                typeof(AssertionExtensions), // FluentAssertions
                typeof(HttpRequestMessage), // System.Net.Http
                typeof(ImmutableArray), // System.Collections.Immutable
                typeof(ConcurrentBag<>), // System.Collections.Concurrent
                typeof(ReadOnlyDictionary<,>), // System.ObjectModel
                typeof(Microsoft.VisualStudio.TestTools.UnitTesting.Assert), // MsTest
                typeof(XunitAssert), // Xunit
            }.Select(type => type.GetTypeInfo().Assembly.Location)
            .Append(GetSystemAssemblyPathByName("System.Globalization.dll"))
            .Append(GetSystemAssemblyPathByName("System.Text.RegularExpressions.dll"))
            .Append(GetSystemAssemblyPathByName("System.Runtime.Extensions.dll"))
            .Append(GetSystemAssemblyPathByName("System.Data.Common.dll"))
            .Append(GetSystemAssemblyPathByName("System.Threading.Tasks.dll"))
            .Append(GetSystemAssemblyPathByName("System.Runtime.dll"))
            .Append(GetSystemAssemblyPathByName("System.Reflection.dll"))
            .Append(GetSystemAssemblyPathByName("System.Xml.dll"))
            .Append(GetSystemAssemblyPathByName("System.Xml.XDocument.dll"))
            .Append(GetSystemAssemblyPathByName("System.Private.Xml.Linq.dll"))
            .Append(GetSystemAssemblyPathByName("System.Linq.Expressions.dll"))
            .Append(GetSystemAssemblyPathByName("System.Collections.dll"))
            .Append(GetSystemAssemblyPathByName("netstandard.dll"))
            .Append(GetSystemAssemblyPathByName("System.Xml.ReaderWriter.dll"))
            .Append(GetSystemAssemblyPathByName("System.Private.Xml.dll"))
            .Select(location => (MetadataReference)MetadataReference.CreateFromFile(location))
            .ToImmutableArray();

            string GetSystemAssemblyPathByName(string assemblyName)
            {
                var root = System.IO.Path.GetDirectoryName(typeof(object).Assembly.Location);
                return System.IO.Path.Combine(root, assemblyName);
            }
        }

        private static readonly ImmutableArray<MetadataReference> References;

        private static readonly string DefaultFilePathPrefix = "Test";
        private static readonly string CSharpDefaultFileExt = "cs";
        private static readonly string VisualBasicDefaultExt = "vb";
        private static readonly string TestProjectName = "TestProject";

        public static Document CreateDocument(CsProjectArguments arguments) => CreateProject(arguments).Documents.First();

        /// <summary>
        /// Create a project using the inputted strings as sources.
        /// </summary>
        /// <param name="sources">Classes in the form of strings</param>
        /// <param name="language">The language the source code is in</param>
        /// <returns>A Project created out of the Documents created from the source strings</returns>
        public static Project CreateProject(string[] sources, string language = LanguageNames.CSharp)
        {
            var arguments = new CsProjectArguments
            {
                Language = language,
                Sources = sources,
                TargetFramework = TargetFramework.Net8_0,
            };
            return CreateProject(arguments).AddMetadataReferences(References);
        }

        public static Project CreateProject(CsProjectArguments arguments)
        {
            string fileNamePrefix = DefaultFilePathPrefix;
            string fileExt = arguments.Language is LanguageNames.CSharp ? CSharpDefaultFileExt : VisualBasicDefaultExt;

            var projectId = ProjectId.CreateNewId(debugName: TestProjectName);

            var solution = new AdhocWorkspace()
                .CurrentSolution
                .AddProject(projectId, TestProjectName, TestProjectName, arguments.Language);
            foreach (var package in arguments.PackageReferences)
            {
                solution = solution.AddPackageReference(projectId, package);
            }

            solution = solution.AddTargetFrameworkReference(projectId, arguments.TargetFramework);

            for (int i = 0; i < arguments.Sources.Length; i++)
            {
                var newFileName = fileNamePrefix + i + "." + fileExt;
                var documentId = DocumentId.CreateNewId(projectId, debugName: newFileName);
                solution = solution.AddDocument(documentId, newFileName, SourceText.From(arguments.Sources[i]));
            }
            return solution.GetProject(projectId);
        }
    }
}
