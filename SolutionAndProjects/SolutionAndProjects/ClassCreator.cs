using System.IO;
using System.Xml.Linq;
using SolutionAndProjects.Models;

namespace SolutionAndProjects
{
    internal static class ClassCreator
    {
        internal static CSharpFile CreateCSharpFile(FileInfo fileInfo)
        {
            return new CSharpFile(fileInfo);
        }

        internal static XAMLFile CreateXAMLFile(FileInfo fileInfo)
        {
            return new XAMLFile(fileInfo);
        }
    }
}
