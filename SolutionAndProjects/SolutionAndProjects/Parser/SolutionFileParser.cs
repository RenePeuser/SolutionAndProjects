using System.Diagnostics.Contracts;
using System.Linq;
using Extensions;
using SolutionAndProjects.Models;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Parser
{
    public static class SolutionFileParser
    {
        public static SolutionFile Parse(SolutionFileInfo solutionFileInfo)
        {
            Contract.Requires(solutionFileInfo.IsNotNull());

            var solutionFile = Microsoft.Build.Construction.SolutionFile.Parse(solutionFileInfo.Value.FullName);

            var projects = solutionFile.ProjectsInOrder.Select(item => new ProjectFileInfo(item.AbsolutePath))
                                                       .Select(ProjectFileParser.Parse)
                                                       .ToList();

            var unitTestProjects = projects.Where(item => item.ProjectTypes.Any(type => type == ProjectType.Test)).ToList();
            var productiveProjects = projects.Except(unitTestProjects);

            return new SolutionFile(solutionFileInfo, projects, productiveProjects, unitTestProjects);
        }
    }
}
