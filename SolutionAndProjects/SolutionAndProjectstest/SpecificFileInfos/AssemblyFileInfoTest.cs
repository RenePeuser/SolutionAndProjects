using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Test.SpecificFileInfos
{
    [TestClass]
    public class AssemblyFileInfoTest
    {
        [TestMethod]
        public void WhenClassWasCreated_ThenExpectedValuesHasToBeSet()
        {
            var result = new SolutionFileInfo(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\ExternalLibs\Extensions.dll");

            Assert.AreEqual(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\ExternalLibs\Extensions.dll", result.Value.FullName);
        }
    }
}
