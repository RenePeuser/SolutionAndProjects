using System.Diagnostics.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionAndProjects.Models;
using SolutionAndProjects.Parser;

namespace SolutionAndProjectstest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solutionFile = SolutionFileParser.Parse(new SolutionFileInfo(@"D:\Projects\TestApplication\TestApplication.sln"));
            Assert.IsNotNull(solutionFile);
        }
    }
}