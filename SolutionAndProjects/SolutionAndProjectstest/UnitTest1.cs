using Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionAndProjects;

namespace SolutionAndProjectstest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solutionFile =
                new SolutionFile(
                    @"D:\Projects\TestApplication\TestApplication.sln".ToFileInfo());
        }
    }
}