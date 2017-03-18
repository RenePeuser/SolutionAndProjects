using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Test.SpecificFileInfos
{
    [TestClass]
    public class SolutionFileInfoTest
    {
        [TestMethod]
        public void WhenClassWasCreated_ThenExpectedValuesHasToBeSet()
        {
            var result = new SolutionFileInfo(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects.sln");

            Assert.AreEqual(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects.sln", result.Value.FullName);
        }
    }
}
