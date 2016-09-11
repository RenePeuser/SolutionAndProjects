using Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionAndProjects.Parser;

namespace SolutionAndProjectstest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solutionFile = SolutionFileParser.Parse(@"D:\Projects\TestApplication\TestApplication.sln".ToFileInfo());
        }
    }
}