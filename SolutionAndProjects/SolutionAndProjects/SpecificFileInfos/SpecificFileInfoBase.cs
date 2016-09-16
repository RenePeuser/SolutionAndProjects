using System.Diagnostics.Contracts;
using System.IO;
using Extensions;
using Extensions.Helpers;

namespace SolutionAndProjects.SpecificFileInfos
{
    public abstract class SpecificFileInfoBase : SemanticType<FileInfo>
    {
        protected SpecificFileInfoBase(string path, string expectedExtension) : base(new FileInfo(path))
        {
            Contract.Requires(path.IsNotNullOrEmpty());
            Contract.Requires(expectedExtension.IsNotNullOrEmpty());
            Contract.Requires(path.EndsWith(expectedExtension));
            Contract.Requires(File.Exists(path));
        }
    }
}
