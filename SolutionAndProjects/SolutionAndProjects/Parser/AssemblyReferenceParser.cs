using System.Xml.Linq;
using Extensions;
using SolutionAndProjects.Helper;
using SolutionAndProjects.Models;

namespace SolutionAndProjects.Parser
{
    internal static class AssemblyReferenceParser
    {
        internal static AssemblyReference Parse(XElement element)
        {
            var include = element.AttributeBy(ParserHelper.Include).Value;

            var hintPath = element.ElementBy(ParserHelper.HintPath).ValueOrDefault(string.Empty);
            var copyLocal = element.ElementBy(ParserHelper.Private).ToBool(hintPath.IsNotEmpty());

            var includeContainsVersion = include.Contains(ParserHelper.Version);
            var specificVersion = element.ElementBy(ParserHelper.SpecificVersion).ToBool(includeContainsVersion);

            return new AssemblyReference(include, copyLocal, hintPath, specificVersion);
        }
    }
}
