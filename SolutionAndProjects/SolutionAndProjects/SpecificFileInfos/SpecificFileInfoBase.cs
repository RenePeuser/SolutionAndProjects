using System;
using System.IO;
using SolutionAndProjects.Common;

namespace SolutionAndProjects.SpecificFileInfos
{
    public abstract class SpecificFileInfoBase : SemanticType<FileInfo>
    {
        protected SpecificFileInfoBase(string path, string expectedFileExtension)
            : base(new FileInfo(path))
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The path of a file info must not be null or empty", nameof(path));
            }

            if (string.IsNullOrEmpty(expectedFileExtension))
            {
                throw new ArgumentException("The expected file extension must not be null", nameof(expectedFileExtension));
            }

            if (!path.EndsWith(expectedFileExtension))
            {
                throw new ArgumentException("The given path has not the expected file extension", nameof(path));
            }

            if (!File.Exists(path))
            {
                throw new ArgumentException("The given path does not exists", nameof(path));
            }
        }
    }
}
