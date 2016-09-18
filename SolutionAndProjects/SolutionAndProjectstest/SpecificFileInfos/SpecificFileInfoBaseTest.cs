using System;
using ExtendedAsserts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Test.SpecificFileInfos
{
    [TestClass]
    public class SpecificFileInfoBaseTest
    {
        [TestMethod]
        public void WhenValuesAreCorrect_ThenIsHasToBeExpectedValue()
        {
            var specificFileInfoTestClass = new SpecificFileInfoBaseTestClass(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects.sln", "sln");

            Assert.AreEqual(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects.sln", specificFileInfoTestClass.Value.FullName);
        }

        [TestMethod]
        public void WhenPathNotContainsExpectedFileExtension_ThenExceptionHasToBeThrown()
        {
            Asserts.Throws<Exception>(() => new SpecificFileInfoBaseTestClass(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects.sln", "notGood"));
        }

        [TestMethod]
        public void WhenPathIsNull_ThenExceptionHasToBeThrown()
        {
            Asserts.Throws<Exception>(() => new SpecificFileInfoBaseTestClass(null, ".sln"));
        }

        [TestMethod]
        public void WhenPathIsEmpty_ThenExceptionHasToBeThrown()
        {
            Asserts.Throws<Exception>(() => new SpecificFileInfoBaseTestClass(string.Empty, ".sln"));
        }

        [TestMethod]
        public void WhenFileExtensionIsNull_ThenExceptionHasToBeThrown()
        {
            Asserts.Throws<Exception>(() => new SpecificFileInfoBaseTestClass(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects.sln", null));
        }

        [TestMethod]
        public void WhenFileExtensionIsEmpty_ThenExceptionHasToBeThrown()
        {
            Asserts.Throws<Exception>(() => new SpecificFileInfoBaseTestClass(@"D:\GitHub\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects\SolutionAndProjects.sln", string.Empty));
        }

        private class SpecificFileInfoBaseTestClass : SpecificFileInfoBase
        {
            public SpecificFileInfoBaseTestClass(string path, string expectedExtension) : base(path, expectedExtension)
            {
            }
        }
    }
}
