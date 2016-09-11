using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using Extensions;

namespace SolutionAndProjects.Models
{
    public class ProjectFile
    {
        internal ProjectFile(
            FileInfo fileInfo,
            string assemblyName,
            IEnumerable<AssemblyReference> assemblyReferences,
            IEnumerable<ProjectReference> projectReferences,
            IEnumerable<ProjectType> projectTypes,
            IEnumerable<Import> imports,
            IEnumerable<CSharpFile> csharpFiles,
            IEnumerable<XAMLFile> xamlFiles
            )
        {
            Contract.Requires(fileInfo.IsNotNull());
            Contract.Requires(fileInfo.Exists);
            Contract.Requires(assemblyName.IsNotNullOrEmpty());
            Contract.Requires(assemblyReferences.IsNotNull());
            Contract.Requires(projectReferences.IsNotNull());
            Contract.Requires(projectTypes.IsNotNull());
            Contract.Requires(imports.IsNotNull());
            Contract.Requires(csharpFiles.IsNotNull());
            Contract.Requires(xamlFiles.IsNotNull());

            FileInfo = fileInfo;
            AssemblyName = assemblyName;
            AssemblyReferences = assemblyReferences;
            ProjectReferences = projectReferences;
            ProjectTypes = projectTypes;
            Imports = imports;
            CSharpFiles = csharpFiles;
            XAMLFiles = xamlFiles;
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
