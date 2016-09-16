using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionAndProjects;
using SolutionAndProjects.Models;
using SolutionAndProjects.Parser;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjectstest
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
            Assert.AreEqual(1, _solutionFile.UnitTestProjects.Count());
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
    }
}