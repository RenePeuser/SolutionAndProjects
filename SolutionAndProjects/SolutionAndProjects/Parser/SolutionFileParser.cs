using System;
using System.IO;
using System.Linq;
using SolutionAndProjects.Models;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Parser
{
    public static class SolutionFileParser
    {
        private const string ProjectFileExtension = ".csproj";

        public static SolutionFile Parse(SolutionFileInfo solutionFileInfo)
        {
            if (solutionFileInfo == null)
            {
                throw new ArgumentNullException(nameof(solutionFileInfo));
            }

            var solutionFile = Microsoft.Build.Construction.SolutionFile.Parse(solutionFileInfo.Value.FullName);

            var projects = solutionFile.ProjectsInOrder.Where(item => Path.GetExtension(item.RelativePath) == ProjectFileExtension)
                                                       // Only temporary till structure really exists !!
                                                       .Where(item => File.Exists(item.AbsolutePath))
                                                       .Select(item => new ProjectFileInfo(item.AbsolutePath))
                                                       .Select(ProjectFileParser.Parse)
                                                       .ToList();

            var unitTestProjects = projects.Where(item => item.ProjectTypes.Any(type => type == ProjectType.Test)).ToList();
            var productiveProjects = projects.Except(unitTestProjects);

            return new SolutionFile(solutionFileInfo, projects, productiveProjects, unitTestProjects);
        }
    }
}
