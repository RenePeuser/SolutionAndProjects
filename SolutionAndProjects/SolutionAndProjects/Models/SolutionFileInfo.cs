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
            Contract.Requires(Value.IsNotNull());
            Contract.Requires(Value.Exists);
            Contract.Requires(Value.Extension.Equals(SolutionExtension));
        }
    }
}
