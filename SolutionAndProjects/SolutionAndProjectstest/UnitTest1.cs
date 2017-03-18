using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionAndProjects.Models;
using SolutionAndProjects.Parser;
using SolutionAndProjects.SpecificFileInfos;
using Extensions;

namespace SolutionAndProjects.Test
{
    [TestClass]
    public class UnitTest1
    {
        private static SolutionFile _solutionFile;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _solutionFile = SolutionFileParser.Parse(new SolutionFileInfo(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects.sln"));

        }

        [TestMethod]
        public void ExpectedProjectCount()
        {
            Assert.AreEqual(2, _solutionFile.Projects.Count());
        }

        [TestMethod]
        public void ExpectedUnitTestProjectCount()
        {
            Assert.AreEqual(2, _solutionFile.UnitTestProjects.Count());
        }

        [TestMethod]
        public void ExpectedProductiveProjectCount()
        {
            Assert.AreEqual(1, _solutionFile.ProductiveProjects.Count());
        }

        [TestMethod]
        public void ExpectedCSharpFileCount()
        {
            Assert.AreEqual(1, _solutionFile.UnitTestProjects.First().CSharpFiles.Count());
        }

        [TestMethod]
        public void ExpectedXAMLFileCount()
        {
            Assert.AreEqual(1, _solutionFile.UnitTestProjects.First().XAMLFiles.Count());
        }

        [TestMethod]
        public void ExpectedAssemblyReferenceCount()
        {
            Assert.AreEqual(8, _solutionFile.UnitTestProjects.First().AssemblyReferences.Count());
        }

        [TestMethod]
        public void ExpectedProjectRefernceCount()
        {
            Assert.AreEqual(1, _solutionFile.UnitTestProjects.First().ProjectReferences.Count());
        }

        [TestMethod]
        public void ExpectedPrpojectTypesAtProductiveProject()
        {
            Assert.IsTrue(_solutionFile.ProductiveProjects.First().ProjectTypes.SequenceEqual(new[] { ProjectType.C_Sharp }));
        }

        [TestMethod]
        public void ExpectedPrpojectTypesAtUnitTestProject()
        {
            Assert.IsTrue(_solutionFile.ProductiveProjects.First().ProjectTypes.SequenceEqual(new[] { ProjectType.Test, ProjectType.C_Sharp }));
        }

        [TestMethod]
        public void TestA()
        {
            var assemblyNames = _solutionFile.ProductiveProjects.ToString("Title", item => item.AssemblyName);
            var special = _solutionFile.ProductiveProjects.Select(project => project.AssemblyReferences.ToString("AssemblyReferences", item => item.HintPath));

            Assert.AreEqual(2, special.Count());
        }

    }

    public static class ToStringExExtensions
    {

        public static string ToStringEx<T, TSource, TItem>(this T obj, Expression<Func<TSource>> source, params Expression<Func<TItem>>[] expressions)
        {
            var sourceName = source.ExtractPropertyName();
            var compiledExpressions = expressions.Select(item => new KeyValuePair<string, Func<TItem>>(item.ExtractPropertyName(), item.Compile())).ToDictionary();


            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(sourceName);
            foreach (var keyValuePair in compiledExpressions)
            {
                stringBuilder.AppendLine($"{keyValuePair.Key} [{keyValuePair.Value}]");
            }

            return stringBuilder.ToString();

        }

    }
}