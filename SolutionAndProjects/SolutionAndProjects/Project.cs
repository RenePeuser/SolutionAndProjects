using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using Extensions;

namespace SolutionAndProjects
{
    public class Project
    {
        internal Project(ProjectService projectService)
        {
            Contract.Requires(projectService.IsNotNull());

            AssemblyReferences = projectService.GetAssemblyReferences.ToList();
            ProjectReferences = projectService.GetProjectReferences.ToList();
            ProjectTypes = projectService.GetProjectTypes;
            AssemblyName = projectService.GetAssemblyName;
            Imports = projectService.GetImports;
            FileInfo = projectService.FileInfo;
            CSharpFiles = projectService.GetCSharpFiles;
            XAMLFiles = projectService.GetXAMLFiles;
        }

        public string AssemblyName { get; }

        public IEnumerable<ProjectType> ProjectTypes { get; }

        public FileInfo FileInfo { get; }

        public IEnumerable<AssemblyReference> AssemblyReferences { get; }

        public IEnumerable<ProjectReference> ProjectReferences { get; }

        public IEnumerable<Import> Imports { get; }

        public IEnumerable<XAMLFile> XAMLFiles { get; set; }

        public IEnumerable<CSharpFile> CSharpFiles { get; set; }
    }
}
