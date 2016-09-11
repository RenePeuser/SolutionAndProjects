using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using Extensions;

namespace SolutionAndProjects
{
    public class SolutionFile
    {
        public SolutionFile(FileInfo fileInfo)
        {
            Contract.Requires(fileInfo.IsNotNull());
            Contract.Requires(fileInfo.Exists, $"File '{fileInfo.FullName}' does not exists");

            FileInfo = fileInfo;

            var solutionFile = Microsoft.Build.Construction.SolutionFile.Parse(fileInfo.FullName);

            Projects = solutionFile.ProjectsInOrder.Select(item => item.AbsolutePath.ToFileInfo())
                                                   .Select(item => new Project(new ProjectService(item)))
                                                   .ToList();

            UnitTestProjects = Projects.Where(item => item.ProjectTypes.Any(type => type == ProjectType.Test)).ToList();
            ProductiveProjects = Projects.Except(UnitTestProjects);
        }

        public FileInfo FileInfo { get; }

        public IEnumerable<Project> Projects { get; }

        public IEnumerable<Project> ProductiveProjects { get; }

        public IEnumerable<Project> UnitTestProjects { get; }
    }
}
