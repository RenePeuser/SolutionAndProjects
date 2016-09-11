using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using Extensions;

namespace SolutionAndProjects
{
    public class ProjectErrorResult
    {
        public ProjectErrorResult(Project project, IEnumerable<string> errors)
        {
            Contract.Requires(project.IsNotNull());
            Contract.Requires(errors.IsNotNull());

            Project = project;
            Errors = errors;
            ErrorMessage = CreateErrorMessage();
            HasErrors = Errors.Any();
        }

        public Project Project { get; }

        public IEnumerable<string> Errors { get; }
        
        public bool HasErrors { get; }

        public string ErrorMessage { get; }

        private string CreateErrorMessage()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "Project: {0}", Project.FileInfo.Name));
            stringBuilder.AppendLine();
            Errors.ForEach(item => stringBuilder.AppendLine(item));
            return stringBuilder.ToString();
        }
    }
}
