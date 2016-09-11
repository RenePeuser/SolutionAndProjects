using System.Xml.Linq;
using Extensions;
using SolutionAndProjects.Helper;
using SolutionAndProjects.Models;

namespace SolutionAndProjects.Parser
{
    internal class AssemblyReferenceParser
    {
        internal static AssemblyReference Parse(XElement element)
        {
            var include = element.AttributeBy(ParserHelper.Include).ToString();
            var copyLocal = element.ElementBy(ParserHelper.Private).ToBool(true);
            var hintPath = element.ElementBy(ParserHelper.HintPath).ValueOrDefault(string.Empty);

            // Hint: If the include of a reference contains a version number, than the default value is true, otherwise is false.
            var includeContainsVersion = include.Contains(ParserHelper.Version);
            var specificVersion = element.ElementBy(ParserHelper.SpecificVersion).ToBool(includeContainsVersion);

            return new AssemblyReference(include, copyLocal, hintPath, specificVersion);
        }
    }
}
