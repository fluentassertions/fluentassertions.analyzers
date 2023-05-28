using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using FluentAssertions.Execution;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

using XunitAssert = Xunit.Assert;

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
                typeof(Enumerable), // System.Linq
                typeof(CSharpCompilation), // Microsoft.CodeAnalysis.CSharp
                typeof(Compilation), // Microsoft.CodeAnalysis
                typeof(AssertionScope), // FluentAssertions.Core
                typeof(AssertionExtensions), // FluentAssertions
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
        // based on http://code.fitness/post/2017/02/using-csharpscript-with-netstandard.html
        public static string GetSystemAssemblyPathByName(string assemblyName)
        {
            var root = System.IO.Path.GetDirectoryName(typeof(object).Assembly.Location);
            return System.IO.Path.Combine(root, assemblyName);
        }

        private static readonly ImmutableArray<MetadataReference> References;

        private static readonly string DefaultFilePathPrefix = "Test";
        private static readonly string CSharpDefaultFileExt = "cs";
        private static readonly string VisualBasicDefaultExt = "vb";
        private static readonly string TestProjectName = "TestProject";

        /// <summary>
        /// Given an array of strings as sources and a language, turn them into a project and return the documents and spans of it.
        /// </summary>
        /// <param name="sources">Classes in the form of strings</param>
        /// <param name="language">The language the source code is in</param>
        /// <returns>A Tuple containing the Documents produced from the sources and their TextSpans if relevant</returns>
        public static Document[] GetDocuments(string[] sources, string language)
        {
            if (language != LanguageNames.CSharp && language != LanguageNames.VisualBasic)
            {
                throw new ArgumentException("Unsupported Language");
            }

            var project = CreateProject(sources, language);
            var documents = project.Documents.ToArray();

            if (sources.Length != documents.Length)
            {
                throw new SystemException("Amount of sources did not match amount of Documents created");
            }

            return documents;
        }

        /// <summary>
        /// Create a Document from a string through creating a project that contains it.
        /// </summary>
        /// <param name="source">Classes in the form of a string</param>
        /// <param name="language">The language the source code is in</param>
        /// <returns>A Document created from the source string</returns>
        public static Document CreateDocument(string source, string language = LanguageNames.CSharp)
        {
            return CreateProject(new[] { source }, language).Documents.First();
        }

        /// <summary>
        /// Create a project using the inputted strings as sources.
        /// </summary>
        /// <param name="sources">Classes in the form of strings</param>
        /// <param name="language">The language the source code is in</param>
        /// <returns>A Project created out of the Documents created from the source strings</returns>
        public static Project CreateProject(string[] sources, string language = LanguageNames.CSharp)
        {
            string fileNamePrefix = DefaultFilePathPrefix;
            string fileExt = language == LanguageNames.CSharp ? CSharpDefaultFileExt : VisualBasicDefaultExt;

            var projectId = ProjectId.CreateNewId(debugName: TestProjectName);

            var solution = new AdhocWorkspace()
                .CurrentSolution
                .AddProject(projectId, TestProjectName, TestProjectName, language)
                .AddMetadataReferences(projectId, References);

            int count = 0;
            foreach (var source in sources)
            {
                var newFileName = fileNamePrefix + count + "." + fileExt;
                var documentId = DocumentId.CreateNewId(projectId, debugName: newFileName);
                solution = solution.AddDocument(documentId, newFileName, SourceText.From(source));
                count++;
            }
            return solution.GetProject(projectId);
        }
    }
}

