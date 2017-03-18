namespace SolutionAndProjects.SpecificFileInfos
{
    public class SolutionFileInfo : Models.SpecificFileInfoBase
    {
        public SolutionFileInfo(string path)
            : base(path, ".sln")
        {
        }
    }
}
