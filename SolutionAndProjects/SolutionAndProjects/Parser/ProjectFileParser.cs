using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Extensions;
using Extensions.Helpers;
using SolutionAndProjects.Helper;
using SolutionAndProjects.Models;

namespace SolutionAndProjects.Parser
{
    internal static class ProjectFileParser
    {

        internal static ProjectFile Parse(this ProjectFileInfo projectFileInfo)
        {
            var document = XDocument.Load(projectFileInfo.Value.FullName);
            var projectReferences = GetReferences(document, ParserHelper.ProjectReference, ProjectReferenceParser.Parse);
            var assemblyReferences = GetReferences(document, ParserHelper.Reference, AssemblyReferenceParser.Parse);
            var projectTypes = AnalyzeProjectTypes(document);
            var assemblyName = document.ElementBy(ParserHelper.AssemblyName).ValueOrDefault();
            var imports = GetAllImports(document);
            var csharpFiles = GetSpecificFiles(document, ParserHelper.Compile, ParserHelper.Include, ClassCreator.CreateCSharpFile);
            var xamlFiles = GetSpecificFiles(document, ParserHelper.Page, ParserHelper.Include, ClassCreator.CreateXAMLFile);
            return new ProjectFile(projectFileInfo, assemblyName, assemblyReferences, projectReferences, projectTypes, imports, csharpFiles, xamlFiles);
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

        private static IEnumerable<T> GetSpecificFiles<T>(XDocument document, LocalName localName, AttributeName attributeName, Func<string, T> creatorFunc)
        {
            var result = document.ElementsBy(localName)
                                 .Select(element => element.AttributeBy(attributeName)
                                 .ValueOrDefault())
                                 .Select(item => creatorFunc(item));
            return result;
        }
    }
}
