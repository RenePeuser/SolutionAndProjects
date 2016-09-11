using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using Extensions;
using SolutionAndProjects.Models;

namespace SolutionAndProjects.Helper
{
    public static class SolutionFileHelper
    {
        public static FileInfo FindSolutionFileReverse(SolutionFileName solutionFileName, DirectoryInfo startUpDirectory)
        {
            Contract.Requires(solutionFileName.IsNotNull(), "A solution file name must not be null or empty");
            Contract.Requires(startUpDirectory.IsNotNull(), "The start up directory must not be null");
            Contract.Requires(startUpDirectory.Exists, "The start up directory has to be an existing directory");

            var result = FindSolutionFile(solutionFileName, startUpDirectory);
            return result;
        }

        private static FileInfo FindSolutionFile(SolutionFileName solutionFileName, DirectoryInfo startUpDirectory)
        {
            while (startUpDirectory != null)
            {
                var solutionFile = startUpDirectory.EnumerateFiles().FirstOrDefault(item => item.Name == solutionFileName.Value);
                if (solutionFile != null)
                {
                    return solutionFile;
                }

                startUpDirectory = startUpDirectory.Parent;
            }

            return null;
        }
    }
}
