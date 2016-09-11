using Extensions.Helpers;

namespace SolutionAndProjects.Helper
{
    internal static class ParserHelper
    {
        internal static string Version { get; } = "Version=";

        internal static LocalName HintPath { get; } = new LocalName("HintPath");

        internal static LocalName SpecificVersion { get; } = new LocalName("SpecificVersion");

        internal static AttributeName Include { get; } = new AttributeName("Include");

        internal static LocalName Private { get; } = new LocalName("Private");

        internal static LocalName Name { get; } = new LocalName("Name");

        internal static AttributeName Project { get; } = new AttributeName("Project");

        internal static LocalName AssemblyName { get; } = new LocalName("AssemblyName");

        internal static LocalName Compile { get; } = new LocalName("Compile");

        internal static LocalName Page { get; } = new LocalName("Page");

        internal static LocalName ProjectTypeGuids { get; } = new LocalName("ProjectTypeGuids");

        internal static LocalName Import { get; } = new LocalName("Import");

        internal static LocalName ProjectReference { get; } = new LocalName("ProjectReference");

        internal static LocalName Reference { get; } = new LocalName("Reference");
    }
}
