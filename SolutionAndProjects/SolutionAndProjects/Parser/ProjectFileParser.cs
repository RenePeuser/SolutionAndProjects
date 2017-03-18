using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Extensions;
using Extensions.Helpers;
using SolutionAndProjects.Helper;
using SolutionAndProjects.Models;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Parser
{
    internal static class ProjectFileParser
    {
        internal static ProjectFile Parse(ProjectFileInfo projectFileInfo)
        {
            var document = XDocument.Load(projectFileInfo.Value.FullName);
            var projectReferences = GetReferences(document, ParserHelper.ProjectReference, ProjectReferenceParser.Parse);
            var assemblyReferences = GetReferences(document, ParserHelper.Reference, AssemblyReferenceParser.Parse);
            var projectTypes = AnalyzeProjectTypes(document);
            var assemblyName = document.ElementBy(ParserHelper.AssemblyName).ValueOrDefault();
            var imports = GetAllImports(document);
            var csharpFiles = GetSpecificFiles(document, projectFileInfo, ParserHelper.Compile, ParserHelper.Include, ClassCreator.CreateCSharpFile);
            var xamlFiles = GetSpecificFiles(document, projectFileInfo, ParserHelper.Page, ParserHelper.Include, ClassCreator.CreateXAMLFile);
            var contentItems = GetContentItems(document, projectFileInfo);
            var targetFrameworkVersion = document.ElementBy(ParserHelper.TargetFrameworkVersion).ValueOrDefault();
            return new ProjectFile(projectFileInfo, assemblyName, assemblyReferences, projectReferences, projectTypes, imports, csharpFiles, xamlFiles, contentItems, targetFrameworkVersion);
        }

        private static IEnumerable<ProjectType> AnalyzeProjectTypes(XDocument document)
        {
            var projectTypeGuids = document.ElementBy(ParserHelper.ProjectTypeGuids);
            if (projectTypeGuids == null)
            {
                return new[] { ProjectType.Invalid };
            }

            var result = projectTypeGuids.ValueOrDefault(string.Empty);
            var guidArray = result.Split(';').Select(item => new Guid(item));
            return guidArray.Select(ProjectTypeParser.GetProjectType);
        }

        private static IEnumerable<Import> GetAllImports(XDocument document)
        {
            var result = document.ElementsBy(ParserHelper.Import);
            var imports = result.Select(item => new Import(item.AttributeBy(ParserHelper.Project).ValueOrDefault())).ToList();
            return imports;
        }

        private static IEnumerable<T> GetReferences<T>(XDocument document, LocalName localName, Func<XElement, T> convertFunc) where T : ReferenceBase
        {
            var refrences = document.ElementsBy(localName);
            var result = refrences.Select(convertFunc);
            return result;
        }

        private static IEnumerable<T> GetSpecificFiles<T>(XDocument document, ProjectFileInfo projectFileInfo, LocalName localName, AttributeName attributeName, Func<string, T> creatorFunc)
        {
            var projectDirectoryPath = projectFileInfo.Value.Directory.FullName;
            var result = document.ElementsBy(localName)
                                 .Select(element => element.AttributeBy(attributeName).ValueOrDefault())
                                 .Select(item => Path.Combine(projectDirectoryPath, item))
                                 .Select(creatorFunc);
            return result;
        }

        private static IEnumerable<ProjectContentItem> GetContentItems(XDocument document, ProjectFileInfo projectFileInfo)
        {
            var projectFileDirectoryPath = projectFileInfo.Value.Directory.FullName;
            var result = document.ElementsBy(ParserHelper.Content);
            var contentItems = result.Select(
                item =>
                {
                    var include = item.AttributeBy(ParserHelper.Include).ValueOrDefault();
                    var fileInfo = new FileInfo(Path.Combine(projectFileDirectoryPath, include));
                    return new ProjectContentItem(include, fileInfo);
                });

            return contentItems;
        }
    }
}
