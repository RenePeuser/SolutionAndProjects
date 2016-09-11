using System.IO;
using Extensions.Helpers;

namespace SolutionAndProjects.Models
{
    public class CSharpFile : SemanticType<FileInfo>
    {
        public CSharpFile(FileInfo value) : base(value)
        {
        }
    }
}
