using System.Globalization;

namespace SolutionAndProjects.Models
{
    public class Class
    {
        public Class(string className, string nameSpace)
        {
            ClassName = className;
            NameSpace = nameSpace;
            FullQualifiedName = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", nameSpace, className);
        }

        public string ClassName { get; }

        public string NameSpace { get; }

        public string FullQualifiedName { get; }
    }
}