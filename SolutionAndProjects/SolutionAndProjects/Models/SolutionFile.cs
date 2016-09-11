using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using Extensions;

namespace SolutionAndProjects.Models
{
    public class SolutionFile
    {
        internal SolutionFile(FileInfo fileInfo, IEnumerable<ProjectFile> projectFiles, IEnumerable<ProjectFile> productiveProjectFiles, IEnumerable<ProjectFile> unitTestProjectFiles)
        {
            Contract.Requires(fileInfo.IsNotNull());
            Contract.Requires(fileInfo.Exists);
            Contract.Requires(projectFiles.IsNotNull());
            Contract.Requires(productiveProjectFiles.IsNotNull());
            Contract.Requires(unitTestProjectFiles.IsNotNull());

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
