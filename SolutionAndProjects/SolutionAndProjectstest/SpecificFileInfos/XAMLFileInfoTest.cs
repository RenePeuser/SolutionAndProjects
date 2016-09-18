using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Test.SpecificFileInfos
{
    [TestClass]
    public class XAMLFileInfoTest
    {
        [TestMethod]
        public void WhenClassWasCreated_ThenExpectedValuesHasToBeSet()
        {
            // ToDo: check for xaml file
            var result = new XAMLFileInfo(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\SolutionAndProjectstest\SpecificFileInfos\CSharpFileInfoTest.xaml");

            Assert.AreEqual(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\SolutionAndProjectstest\SpecificFileInfos\CSharpFileInfoTest.xaml", result.Value.FullName);
        }
    }
}
