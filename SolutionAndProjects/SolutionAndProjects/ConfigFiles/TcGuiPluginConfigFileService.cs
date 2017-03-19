using System;
using System.Collections.Generic;
using System.Linq;
using SolutionAndProjects.Models;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.ConfigFiles
{
    public static class TcGuiPluginConfigFileService
    {
        private const string ConfigFileExtension = ".config.xml";

        public static IEnumerable<ConfigFileInfo> GetAllConfigFiles(this IEnumerable<ProjectFile> projects)
        {
            if (projects == null)
            {
                throw new ArgumentNullException(nameof(projects));
            }

            var configXmlFiles = projects.SelectMany(item => item.ContentItems)
                                         .Where(item => item.Include.EndsWith(ConfigFileExtension))
                                         .Select(item => new ConfigFileInfo(item.FileInfo.FullName));
            return configXmlFiles;
        }
    }
}
