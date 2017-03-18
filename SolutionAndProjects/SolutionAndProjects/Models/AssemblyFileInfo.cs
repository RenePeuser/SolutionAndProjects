namespace SolutionAndProjects.Models
{
    public class AssemblyFileInfo : SpecificFileInfoBase
    {
        public AssemblyFileInfo(string path)
            : base(path, ".dll")
        {
        }
    }
}
