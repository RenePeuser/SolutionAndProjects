using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Extensions;
using SolutionAndProjects.Models;

namespace SolutionAndProjects.Extensions
{
    public static class ReferenceErrorExtensions
    {
        public static string CreateErrorMessage(this IEnumerable<ProjectFileErrorResult> errors, string header, params string[] arguments)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
            string message = string.Format(CultureInfo.InvariantCulture, header, arguments);
            stringBuilder.AppendLine(message);
            stringBuilder.AppendLine();
            errors.ForEach(item => stringBuilder.AppendLine(item.ErrorMessage));
            return stringBuilder.ToString();
        }
    }
}
