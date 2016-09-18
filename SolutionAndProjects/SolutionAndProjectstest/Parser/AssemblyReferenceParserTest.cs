using System.Xml.Linq;
using Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionAndProjects.Models;
using SolutionAndProjects.Parser;

namespace SolutionAndProjects.Test.Parser
{
    [TestClass]
    public class AssemblyReferenceParserTest
    {
        private static AssemblyReference _assemblyReference;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var resource =
                typeof(AssemblyReferenceParserTest).Assembly.GetManifestResourceString(
                    "SampleData.AssemblyReferenceSampleData.xml");

            var xDocument = XDocument.Parse(resource);
            var reference = xDocument.ElementBy("Reference".ToLocalName());
            _assemblyReference = AssemblyReferenceParser.Parse(reference);
        }

        [TestMethod]
        public void HintPathHasToBeExpected()
        {
            Assert.AreEqual(@"..\packages\System.IO.FileSystem.4.0.1\lib\net46\System.IO.FileSystem.dll", _assemblyReference.HintPath);
        }

        [TestMethod]
        public void IncludHasToBeExpected()
        {
            Assert.AreEqual("System.IO.FileSystem, Version=4.0.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL", _assemblyReference.Include);
        }

        [TestMethod]
        public void CopyLocalHasToBeExpected()
        {
            Assert.IsFalse(_assemblyReference.CopyLocal);
        }

        [TestMethod]
        public void SpecificVersionHasToBeTrue()
        {
            Assert.IsFalse(_assemblyReference.SpecificVersion);
        }
    }
}
