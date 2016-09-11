using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using Extensions;

namespace SolutionAndProjects.Models
{
    public class ProjectFileErrorResult
    {
        public ProjectFileErrorResult(ProjectFile projectFile, IEnumerable<string> errors)
        {
            Contract.Requires(projectFile.IsNotNull());
            Contract.Requires(errors.IsNotNull());

            ProjectFile = projectFile;
            Errors = errors;
            ErrorMessage = CreateErrorMessage();
            HasErrors = Errors.Any();
        }

        public ProjectFile ProjectFile { get; }

        public IEnumerable<string> Errors { get; }
        
        public bool HasErrors { get; }

        public string ErrorMessage { get; }

        private string CreateErrorMessage()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "ProjectFile: {0}", ProjectFile.FileInfo.Name));
            stringBuilder.AppendLine();
            Errors.ForEach(item => stringBuilder.AppendLine(item));
            return stringBuilder.ToString();
        }
    }
}
