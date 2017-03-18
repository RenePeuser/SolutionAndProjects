using System;
using System.IO;
using System.Linq;
using SolutionAndProjects.Models;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Helper
{
    public static class SolutionFileHelper
    {
        public static SolutionFileInfo FindSolutionFileReverse(string solutionFileName, DirectoryInfo startUpDirectory)
        {
            if (string.IsNullOrEmpty(solutionFileName))
            {
                throw new ArgumentException("A solution file have not to be null or empty");
            }

            if (startUpDirectory == null)
            {
                throw new ArgumentNullException(nameof(startUpDirectory));
            }

            if (!startUpDirectory.Exists)
            {
                throw new ArgumentException("The start up directory have to be a existing directory");
            }

            var result = FindSolutionFile(solutionFileName, startUpDirectory);
            return result;
        }

        private static SolutionFileInfo FindSolutionFile(string solutionFileName, DirectoryInfo startUpDirectory)
        {
            while (startUpDirectory != null)
            {
                var solutionFile = startUpDirectory.EnumerateFiles().FirstOrDefault(item => item.Name == solutionFileName);
                if (solutionFile != null)
                {
                    return new SolutionFileInfo(solutionFile.FullName);
                }

                startUpDirectory = startUpDirectory.Parent;
            }

            return null;
        }
    }
}
