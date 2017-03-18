namespace SolutionAndProjects.SpecificFileInfos
{
    public class ProjectFileInfo : Models.SpecificFileInfoBase
    {
        public ProjectFileInfo(string path)
            : base(path, ".csproj")
        {
        }
    }
}
