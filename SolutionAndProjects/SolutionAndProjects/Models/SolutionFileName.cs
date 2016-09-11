using System.Diagnostics.Contracts;
using Extensions;
using Extensions.Helpers;

namespace SolutionAndProjects.Models
{
    public class SolutionFileName : SemanticType<string>
    {
        private const string SolutionFileExtension = ".sln";

        public SolutionFileName(string value) : base(value)
        {
            Contract.Requires(value.IsNotNullOrEmpty(), "The solution file name must not be null or empty");
            Contract.Requires(value.EndsWith(SolutionFileExtension), "The solution file has to has solution file extension '.sln'");
        }
    }
}
