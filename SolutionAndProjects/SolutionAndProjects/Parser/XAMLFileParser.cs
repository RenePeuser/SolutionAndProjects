using System;
using System.Linq;
using System.Xml.Linq;
using SolutionAndProjects.Models;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Parser
{
    public static class XAMLFileParser
    {
        public static XAMLFile Parse(XAMLFileInfo xamlFileInfo)
        {
            if (xamlFileInfo == null)
            {
                throw new ArgumentNullException(nameof(xamlFileInfo));
            }

            var document = XDocument.Load(xamlFileInfo.Value.FullName);

            var staticResourceUsages = from descdant in document.Descendants()
                                       from attribute in descdant.Attributes()
                                       where attribute.Value.StartsWith("{StaticResource ", StringComparison.Ordinal)
                                       select new StaticResourceUsages(ExtractStaticResourceName(attribute));

            var staticResourceDeclarations = from descdant in document.Descendants()
                                             from attribute in descdant.Attributes()
                                             where attribute.Name.LocalName.Equals("Key")
                                             select attribute;

            var result = new XAMLFile(xamlFileInfo, staticResourceUsages, staticResourceDeclarations);
            return result;
        }
        private static string ExtractStaticResourceName(XAttribute attribute)
        {
            string staticRessourceDeclaration = attribute.Value.Replace("ResourceKey=", string.Empty);
            int indexPosition = staticRessourceDeclaration.IndexOf(" ", StringComparison.Ordinal);
            var result = staticRessourceDeclaration.Substring(indexPosition, staticRessourceDeclaration.Length - indexPosition - 1);
            var trimResult = result.Trim();
            return trimResult;
        }
    }
}