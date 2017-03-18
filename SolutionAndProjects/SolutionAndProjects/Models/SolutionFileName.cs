using System;
using Extensions;
using Extensions.Helpers;

namespace SolutionAndProjects.Models
{
    public class SolutionFileName : SemanticType<string>
    {
        private const string SOLUTION_FILE_EXTENSION = ".sln";

        public SolutionFileName(string value)
            : base(value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The solution file name must not be a whitespace");
            }

            if (value.IsEmpty())
            {
                throw new ArgumentException("The solution file name must not be empty");
            }

            if (!value.EndsWith(SOLUTION_FILE_EXTENSION))
            {
                throw new ArgumentException("The solution file has to has solution file extension '.sln'");
            }
        }
    }
}
