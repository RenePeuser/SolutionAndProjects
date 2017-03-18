using System;
using System.Collections.Generic;
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
            IEnumerable<CSharpFileInfo> csharpFileInfos,
            IEnumerable<XAMLFileInfo> xamlFileInfos,
            IEnumerable<ProjectContentItem> projectContentItems,
            string targetFrameworkVersion)
        {
            if (projectFileInfo == null)
            {
                throw new ArgumentNullException(nameof(projectFileInfo));
            }

            if (string.IsNullOrEmpty(assemblyName))
            {
                throw new ArgumentException("The assembly name must not be null or empty", nameof(assemblyName));
            }

            if (assemblyReferences == null)
            {
                throw new ArgumentNullException(nameof(assemblyReferences));
            }

            if (projectReferences == null)
            {
                throw new ArgumentNullException(nameof(projectReferences));
            }

            if (projectTypes == null)
            {
                throw new ArgumentNullException(nameof(projectTypes));
            }

            if (imports == null)
            {
                throw new ArgumentNullException(nameof(imports));
            }

            if (csharpFileInfos == null)
            {
                throw new ArgumentNullException(nameof(csharpFileInfos));
            }

            if (xamlFileInfos == null)
            {
                throw new ArgumentNullException(nameof(xamlFileInfos));
            }

            if (projectContentItems == null)
            {
                throw new ArgumentNullException(nameof(projectContentItems));
            }

            if (targetFrameworkVersion == null)
            {
                throw new ArgumentNullException(nameof(targetFrameworkVersion));
            }

            ProjectFileInfo = projectFileInfo;
            AssemblyName = assemblyName;
            AssemblyReferences = assemblyReferences;
            ProjectReferences = projectReferences;
            ProjectTypes = projectTypes;
            Imports = imports;
            CSharpFileInfos = csharpFileInfos;
            XAMLFileInfos = xamlFileInfos;
            ContentItems = projectContentItems;
            TargetFrameworkVersion = targetFrameworkVersion;
        }

        public string AssemblyName { get; }

        public IEnumerable<ProjectType> ProjectTypes { get; }

        public ProjectFileInfo ProjectFileInfo { get; }

        public IEnumerable<AssemblyReference> AssemblyReferences { get; }

        public IEnumerable<ProjectReference> ProjectReferences { get; }

        public IEnumerable<Import> Imports { get; }

        public IEnumerable<XAMLFileInfo> XAMLFileInfos { get; }

        public IEnumerable<CSharpFileInfo> CSharpFileInfos { get; }

        public IEnumerable<ProjectContentItem> ContentItems { get; }

        public string TargetFrameworkVersion { get; }
    }
}