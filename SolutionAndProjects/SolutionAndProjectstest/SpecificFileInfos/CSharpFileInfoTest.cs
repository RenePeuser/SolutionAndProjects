using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Test.SpecificFileInfos
{
    [TestClass]
    public class CSharpFileInfoTest
    {
        [TestMethod]
        public void WhenClassWasCreated_ThenExpectedValuesHasToBeSet()
        {
            var result = new SolutionFileInfo(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\SolutionAndProjectstest\SpecificFileInfos\CSharpFileInfoTest.cs");

            Assert.AreEqual(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\SolutionAndProjectstest\SpecificFileInfos\CSharpFileInfoTest.cs", result.Value.FullName);
        }
    }
}
