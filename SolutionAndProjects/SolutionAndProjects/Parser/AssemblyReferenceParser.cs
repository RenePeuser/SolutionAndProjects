using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Extensions;
using SolutionAndProjects.Models;

namespace SolutionAndProjects.Parser
{
    internal class AssemblyReferenceParser
    {
        private const string Version = "Version=";

        internal static AssemblyReference Parse(XElement element)
        {
            var include = element.AttributeBy("Include".ToAttributeName()).ToString();
            var copyLocal = element.ElementBy("Private".ToLocalName()).ToBool(true);
            var hintPath = element.ElementBy("HintPath".ToLocalName()).ValueOrDefault(string.Empty);

            // Hint: If the include of a reference contains a version number, than the default value is true, otherwise is false.
            var includeContainsVersion = include.Contains(Version);
            var specificVersion = element.ElementBy("SpecificVersion".ToLocalName()).ToBool(includeContainsVersion);

            return new AssemblyReference(include, copyLocal, hintPath, specificVersion);
        }
    }
}
