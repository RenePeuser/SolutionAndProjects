namespace SolutionAndProjects.Models
{
    public class StaticResourceUsages
    {
        internal StaticResourceUsages(string staticResourceName)
        {
            StaticResourceName = staticResourceName;
        }

        public string StaticResourceName { get; }
    }
}