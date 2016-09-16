using SolutionAndProjects.Models;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Parser
{
    public static class CSharpFileParser
    {
        public static CSharpFile Parse(this CSharpFileInfo csharpFileInfo)
        {
            // Add parsing mechanism what is interesting for you.
            return new CSharpFile(null, null, null);
        }
    }
}
