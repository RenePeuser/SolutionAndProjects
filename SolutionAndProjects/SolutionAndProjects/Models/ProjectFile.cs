using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Extensions;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Models
{
    public class ProjectFile
    {
        internal ProjectFile(
            ProjectFileInfo projectFileInfo,
            string assemblyName,
            IEnumerable<AssemblyReference> assemblyReferences,
            IEnumerable<ProjectReference> projectReferences,
            IEnumerable<ProjectType> projectTypes,
            IEnumerable<Import> imports,
            IEnumerable<CSharpFileInfo> csharpFiles,
            IEnumerable<XAMLFileInfo> xamlFiles
            )
        {
            Contract.Requires(projectFileInfo.IsNotNull());
            Contract.Requires(assemblyName.IsNotNullOrEmpty());
            Contract.Requires(assemblyReferences.IsNotNull());
            Contract.Requires(projectReferences.IsNotNull());
            Contract.Requires(projectTypes.IsNotNull());
            Contract.Requires(imports.IsNotNull());
            Contract.Requires(csharpFiles.IsNotNull());
            Contract.Requires(xamlFiles.IsNotNull());

            ProjectFileInfo = projectFileInfo;
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

        public ProjectFileInfo ProjectFileInfo { get; }

        public IEnumerable<AssemblyReference> AssemblyReferences { get; }

        public IEnumerable<ProjectReference> ProjectReferences { get; }

        public IEnumerable<Import> Imports { get; }

        public IEnumerable<XAMLFileInfo> XAMLFiles { get; }

        public IEnumerable<CSharpFileInfo> CSharpFiles { get; }
    }
}
