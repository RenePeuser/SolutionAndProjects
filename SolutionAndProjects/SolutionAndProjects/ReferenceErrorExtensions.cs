﻿using System.Collections.Generic;
using System.Text;
using Extensions;

namespace SolutionAndProjects
{
    public static class ReferenceErrorExtensions
    {
        public static string CreateErrorMessage(this IEnumerable<ProjectErrorResult> errors, string header)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(header);
            stringBuilder.AppendLine();
            errors.ForEach(item => stringBuilder.AppendLine(item.ErrorMessage));
            return stringBuilder.ToString();
        }
    }
}
