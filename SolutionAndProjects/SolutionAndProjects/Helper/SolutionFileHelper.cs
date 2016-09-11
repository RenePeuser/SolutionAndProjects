using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using Extensions;

namespace SolutionAndProjects.Helper
{
    public static class SolutionFileHelper
    {
        public static FileInfo FindSolutionFileReverse(string solutionFileName, DirectoryInfo startUpDirectory)
        {
            Contract.Requires(solutionFileName.IsNullOrEmpty(), "A solution file have not to be null or empty");
            Contract.Requires(startUpDirectory.IsNotNull(), "The start up directory must not be null");
            Contract.Requires(startUpDirectory.Exists, "The start up directory has to be an existing directory");

            var result = FindSolutionFile(solutionFileName, startUpDirectory);
            return result;
        }

        private static FileInfo FindSolutionFile(string solutionFileName, DirectoryInfo startUpDirectory)
        {
            while (startUpDirectory != null)
            {
                var solutionFile = startUpDirectory.EnumerateFiles().FirstOrDefault(item => item.Name == solutionFileName);
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
