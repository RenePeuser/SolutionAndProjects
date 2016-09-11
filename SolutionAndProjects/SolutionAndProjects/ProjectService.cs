using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Extensions;

namespace SolutionAndProjects
{
    internal class ProjectService
    {
        private readonly XDocument _document;
        private IEnumerable<ProjectType> _mProjectType;
        private IEnumerable<ProjectReference> _mProjectReferences;
        private IEnumerable<AssemblyReference> _mAssemblyReferences;
        private string _mAssemblyName;
        private IEnumerable<Import> _imports;
        private IEnumerable<CSharpFile> _csharpFiles;
        private IEnumerable<XAMLFile> _xamlFiles;

        internal ProjectService(FileInfo fileInfo)
        {
            Contract.Requires(fileInfo.IsNotNull());
            Contract.Requires(fileInfo.Exists);

            FileInfo = fileInfo;
            _document = XDocument.Load(fileInfo.FullName);
        }

        internal FileInfo FileInfo { get; }

        internal IEnumerable<ProjectReference> GetProjectReferences
        {
            get
            {
                if (_mProjectReferences == null)
                {
                    _mProjectReferences = GetReferences(_document, "ProjectReference", ReferenceCreator.CreateProjectReference);
                }

                return _mProjectReferences;
            }
        }

        internal IEnumerable<AssemblyReference> GetAssemblyReferences
        {
            get
            {
                if (_mAssemblyReferences == null)
                {
                    _mAssemblyReferences = GetReferences(_document, "Reference", ReferenceCreator.CreateAssemblyReference);
                }

                return _mAssemblyReferences;
            }
        }

        internal IEnumerable<ProjectType> GetProjectTypes
        {
            get
            {
                if (_mProjectType == null)
                {
                    var projectTypeGuids = _document.ElementBy("ProjectTypeGuids".ToLocalName());
                    if (projectTypeGuids != null)
                    {
                        var result = projectTypeGuids.ValueOrDefault(string.Empty);
                        var guidArray = result.Split(';').Select(item => new Guid(item));
                        _mProjectType = guidArray.Select(ProjectTypeService.GetProjectType);
                    }
                    else
                    {
                        _mProjectType = new[] { ProjectType.Invalid };
                    }
                }

                return _mProjectType;
            }
        }

        internal string GetAssemblyName
        {
            get
            {
                if (_mAssemblyName.IsNullOrEmpty())
                {
                    _mAssemblyName = _document.ElementBy("AssemblyName".ToLocalName()).ValueOrDefault();
                }

                return _mAssemblyName;
            }
        }

        internal IEnumerable<Import> GetImports
        {
            get
            {
                if (_imports == null)
                {
                    var result = _document.ElementsBy("Import".ToLocalName());
                    _imports = result.Select(item => new Import(item.AttributeBy("Project".ToAttributeName()).ValueOrDefault())).ToList();
                }

                return _imports;
            }
        }

        internal IEnumerable<CSharpFile> GetCSharpFiles
        {
            get
            {
                if (_csharpFiles == null)
                {
                    _csharpFiles = _document.ElementsBy("Compile".ToLocalName())
                                 .Select(element => element.AttributeBy("Include".ToAttributeName())
                                 .ValueOrDefault())
                                 .Select(item => new CSharpFile(item.ToFileInfo()));
                }

                return _csharpFiles;
            }
        }

        internal IEnumerable<XAMLFile> GetXAMLFiles
        {
            get
            {
                if (_xamlFiles == null)
                {
                    _xamlFiles = _document.ElementsBy("Page".ToLocalName())
                                 .Select(element => element.AttributeBy("Include".ToAttributeName())
                                 .ValueOrDefault())
                                 .Select(item => new XAMLFile(item.ToFileInfo()));
                }

                return _xamlFiles;
            }
        }

        private static IEnumerable<T> GetReferences<T>(XDocument document, string referenceName, Func<XElement, T> convertFunc) where T : ReferenceBase
        {
            var refrences = document.ElementsBy(referenceName.ToLocalName());
            var result = refrences.Select(convertFunc);
            return result;
        }
    }
}
