using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionAndProjects.Analyzer
{
    internal static class ProjectFileErrorAnalyzer
    {
        internal static IEnumerable<string> AnalyzeErrors<T>(this IEnumerable<T> source, Func<T, bool> filterFunc, Func<T, string> errorValue)
        {
            var errors = source.Where(filterFunc);
            var result = errors.Select(errorValue);
            return result;
        }

        internal static string AnalyzeErrors<T>(this T source, Func<T, bool> filterFunc, Func<T, string> errorValue)
        {
            return filterFunc(source) ? errorValue(source) : null;
        }
    }
}
