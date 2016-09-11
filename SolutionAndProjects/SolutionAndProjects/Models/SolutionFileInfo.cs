using System.Diagnostics.Contracts;
using System.IO;
using Extensions;
using Extensions.Helpers;

namespace SolutionAndProjects.Models
{
    public class SolutionFileInfo : SemanticType<FileInfo>
    {
        private const string SolutionExtension = ".sln";

        public SolutionFileInfo(string value) : base(value.ToFileInfo())
        {
            Contract.Requires(value.IsNotNull());
            Contract.Requires(value.EndsWith(SolutionExtension));
            Contract.Requires(File.Exists(value));
        }
    }
}
