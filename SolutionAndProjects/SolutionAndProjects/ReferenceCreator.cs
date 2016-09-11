using System.Xml.Linq;

namespace SolutionAndProjects
{
    internal static class ReferenceCreator
    {
        internal static AssemblyReference CreateAssemblyReference(XElement element)
        {
            return new AssemblyReference(element);
        }

        internal static ProjectReference CreateProjectReference(XElement element)
        {
            return new ProjectReference(element);
        }
    }
}
