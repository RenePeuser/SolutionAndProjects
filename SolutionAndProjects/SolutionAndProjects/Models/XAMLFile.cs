using System.Collections.Generic;
using System.Xml.Linq;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Models
{
    public class XAMLFile
    {
        internal XAMLFile(XAMLFileInfo xamlFileInfo, IEnumerable<StaticResourceUsages> staticResourceUsages, IEnumerable<XAttribute> staticResourceDeclarations)
        {
            XAMLFileInfo = xamlFileInfo;
            StaticResourceUsages = staticResourceUsages;
            StaticResourceDeclarations = staticResourceDeclarations;
        }

        public XAMLFileInfo XAMLFileInfo { get; }

        public IEnumerable<XAttribute> StaticResourceDeclarations { get; }

        public IEnumerable<StaticResourceUsages> StaticResourceUsages { get; }
    }
}