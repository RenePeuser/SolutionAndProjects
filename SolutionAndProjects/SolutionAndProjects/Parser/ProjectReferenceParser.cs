using System.Xml.Linq;
using Extensions;
using SolutionAndProjects.Models;

namespace SolutionAndProjects.Parser
{
    internal class ProjectReferenceParser
    {
        internal static ProjectReference Parse(XElement element)
        {
            var include = element.AttributeBy("Include".ToAttributeName()).ToString();
            var copyLocal = element.ElementBy("Private".ToLocalName()).ToBool(true);
            var name = element.ElementBy("Name".ToLocalName()).ValueOrDefault(string.Empty);

            return new ProjectReference(include, copyLocal, name);
        }
    }
}
