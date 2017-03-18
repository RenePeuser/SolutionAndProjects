namespace SolutionAndProjects.Models
{
    public class ProjectReference : ReferenceBase
    {
        internal ProjectReference(string include, bool copyLocal, string name)
            : base(include, copyLocal)
        {
            Name = name;
        }

        public string Name { get; }
    }
}