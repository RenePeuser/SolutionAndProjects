using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Extensions;
using Extensions.Helpers;
using SolutionAndProjects.Models;

namespace SolutionAndProjects.Parser
{
    internal class ProjectFileParser
    {
        internal static ProjectFile Parse(FileInfo fileInfo)
        {
            var document = XDocument.Load(fileInfo.FullName);
            var projectReferences = GetReferences(document, "ProjectReference", ProjectReferenceParser.Parse);
            var assemblyReferences = GetReferences(document, "Reference", AssemblyReferenceParser.Parse);
            var projectTypes = AnalyzeProjectTypes(document);
            var assemblyName = document.ElementBy("AssemblyName".ToLocalName()).ValueOrDefault();
            var imports = GetAllImports(document);
            var csharpFiles = GetSpecificFiles(document, "Compile".ToLocalName(), "Include".ToAttributeName(), ClassCreator.CreateCSharpFile);
            var xamlFiles = GetSpecificFiles(document, "Page".ToLocalName(), "Include".ToAttributeName(), ClassCreator.CreateXAMLFile);
            return new ProjectFile(fileInfo, assemblyName, assemblyReferences, projectReferences, projectTypes, imports, csharpFiles, xamlFiles);
        }

        private static IEnumerable<ProjectType> AnalyzeProjectTypes(XDocument document)
        {
            var projectTypeGuids = document.ElementBy("ProjectTypeGuids".ToLocalName());
            if (projectTypeGuids == null) return new[] { ProjectType.Invalid };

            var result = projectTypeGuids.ValueOrDefault(string.Empty);
            var guidArray = result.Split(';').Select(item => new Guid(item));
            return guidArray.Select(ProjectTypeService.GetProjectType);
        }

        private static IEnumerable<Import> GetAllImports(XDocument document)
        {
            var result = document.ElementsBy("Import".ToLocalName());
            var imports = result.Select(item => new Import(item.AttributeBy("Project".ToAttributeName()).ValueOrDefault())).ToList();
            return imports;
        }

        private static IEnumerable<T> GetReferences<T>(XDocument document, string referenceName, Func<XElement, T> convertFunc) where T : ReferenceBase
        {
            var refrences = document.ElementsBy(referenceName.ToLocalName());
            var result = refrences.Select(convertFunc);
            return result;
        }

        private static IEnumerable<T> GetSpecificFiles<T>(XDocument document, LocalName localName, AttributeName attributeName, Func<FileInfo, T> creatorFunc)
        {
            var result = document.ElementsBy(localName)
                                 .Select(element => element.AttributeBy(attributeName)
                                 .ValueOrDefault())
                                 .Select(item => creatorFunc(item.ToFileInfo()));
            return result;
        }
    }
}
