using System.Collections.Generic;
using System.IO;

namespace SolutionAndProjects.Models
{
    public class SolutionFile
    {
        internal SolutionFile(FileInfo fileInfo, IEnumerable<ProjectFile> projectFiles, IEnumerable<ProjectFile> productiveProjectFiles, IEnumerable<ProjectFile> unitTestProjectFiles)
        {
            FileInfo = fileInfo;
            Projects = projectFiles;
            ProductiveProjects = productiveProjectFiles;
            UnitTestProjects = unitTestProjectFiles;
        }

        public FileInfo FileInfo { get; }

        public IEnumerable<ProjectFile> Projects { get; }

        public IEnumerable<ProjectFile> ProductiveProjects { get; }

        public IEnumerable<ProjectFile> UnitTestProjects { get; }
    }
}
