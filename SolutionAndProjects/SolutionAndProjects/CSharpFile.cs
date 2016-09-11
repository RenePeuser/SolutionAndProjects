using System.IO;
using Extensions.Helpers;

namespace SolutionAndProjects
{
    public class CSharpFile : SemanticType<FileInfo>
    {
        public CSharpFile(FileInfo value) : base(value)
        {
        }
    }
}
