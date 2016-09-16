using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Helper
{
    internal static class ClassCreator
    {
        internal static CSharpFileInfo CreateCSharpFile(string path)
        {
            return new CSharpFileInfo(path);
        }

        internal static XAMLFileInfo CreateXAMLFile(string path)
        {
            return new XAMLFileInfo(path);
        }
    }
}
