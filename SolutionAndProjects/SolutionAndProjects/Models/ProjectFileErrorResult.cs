using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

namespace SolutionAndProjects.Models
{
    public class ProjectFileErrorResult
    {
        public ProjectFileErrorResult(ProjectFile project, IEnumerable<string> errors)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            if (errors == null)
            {
                throw new ArgumentNullException(nameof(errors));
            }

            ProjectFile = project;
            Errors = errors;
            ErrorMessage = CreateErrorMessage();
        }

        public ProjectFile ProjectFile { get; }

        public IEnumerable<string> Errors { get; }

        public bool HasErrors => Errors.Any();

        public string ErrorMessage { get; }

        private string CreateErrorMessage()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Project: {ProjectFile.ProjectFileInfo.Value.Name}");
            stringBuilder.AppendLine();
            Errors.ForEach(item => stringBuilder.AppendLine(item));
            return stringBuilder.ToString();
        }
    }
}