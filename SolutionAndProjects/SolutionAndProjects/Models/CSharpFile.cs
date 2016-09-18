using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Models
{
    public class CSharpFile
    {
        public CSharpFile(CSharpFileInfo cSharpFileInfo, string nameSpace, string name)
        {
            CSharpFileInfo = cSharpFileInfo;
            NameSpace = nameSpace;
            Name = name;
        }

        public CSharpFileInfo CSharpFileInfo { get; }

        public string NameSpace { get; }

        public string Name { get; }

    }
}
