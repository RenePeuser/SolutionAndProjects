namespace SolutionAndProjects.Models
{
    public abstract class ReferenceBase
    {
        protected ReferenceBase(string include, bool copyLocal)
        {
            Include = include;
            CopyLocal = copyLocal;
        }

        public string Include { get; }

        public bool CopyLocal { get; }
    }
}