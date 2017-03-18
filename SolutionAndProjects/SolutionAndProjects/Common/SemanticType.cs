namespace SolutionAndProjects.Common
{
    public abstract class SemanticType<T>
    {
        protected SemanticType(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }
}
