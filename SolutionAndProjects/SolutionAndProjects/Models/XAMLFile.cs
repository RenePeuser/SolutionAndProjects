using System.IO;
using Extensions.Helpers;

namespace SolutionAndProjects.Models
{
    public class XAMLFile : SemanticType<FileInfo>
    {
        public XAMLFile(FileInfo value) : base(value)
        {
        }
    }
}
