using System.Collections.Generic;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Models
{
    public class SolutionFile
    {
        internal SolutionFile(SolutionFileInfo solutionFileInfo, IEnumerable<ProjectFile> projectFiles, IEnumerable<ProjectFile> productiveProjectFiles, IEnumerable<ProjectFile> unitTestProjectFiles)
        {
            SolutionFileInfo = solutionFileInfo;
            Projects = projectFiles;
            ProductiveProjects = productiveProjectFiles;
            UnitTestProjects = unitTestProjectFiles;
        }

        public SolutionFileInfo SolutionFileInfo { get; }

        public IEnumerable<ProjectFile> Projects { get; }

        public IEnumerable<ProjectFile> ProductiveProjects { get; }

        public IEnumerable<ProjectFile> UnitTestProjects { get; }
    }
}
