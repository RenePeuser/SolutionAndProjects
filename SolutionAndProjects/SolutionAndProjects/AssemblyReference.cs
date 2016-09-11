using System.Xml.Linq;
using Extensions;

namespace SolutionAndProjects
{
    public class AssemblyReference : ReferenceBase
    {
        private const string Version = "Version=";

        internal AssemblyReference(XElement referenceElement)
            : base(referenceElement)
        {
            HintPath = referenceElement.ElementBy("HintPath".ToLocalName()).ValueOrDefault(string.Empty);

            // Hint: If the include of a reference contains a version number, than the default value is true, otherwise is false.
            var includeContainsVersion = Include.Contains(Version);
            SpecificVersion = referenceElement.ElementBy("SpecificVersion".ToLocalName()).ToBool(includeContainsVersion);
        }

        public string HintPath { get; }

        public bool SpecificVersion { get; }
    }
}
