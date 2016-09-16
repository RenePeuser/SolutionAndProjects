using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Models
{
    public class ProjectFileInfo : SpecificFileInfoBase
    {
        public ProjectFileInfo(string path) : base(path, ".csproj")
        {
        }
    }
}
