using System;
using System.Collections.Generic;
using System.Linq;
using SolutionAndProjects.Analyzer;
using SolutionAndProjects.Models;

namespace SolutionAndProjects.Extensions
{
    [CLSCompliant(false)]
    public static class ProjectFileExtensions
    {
        public static IEnumerable<ProjectFileErrorResult> CheckAssemblyReferencesForErrors(
            this IEnumerable<ProjectFile> projects,
            Func<AssemblyReference, bool> findErrorFunc,
            Func<AssemblyReference, string> errorValue)
        {
            if (projects == null)
            {
                throw new ArgumentNullException(nameof(projects));
            }

            if (findErrorFunc == null)
            {
                throw new ArgumentNullException(nameof(findErrorFunc));
            }

            if (errorValue == null)
            {
                throw new ArgumentNullException(nameof(errorValue));
            }

            var errorResults =
                projects.Select(
                    project =>
                    new ProjectFileErrorResult(
                        project,
                        ProjectFileErrorAnalyzer.AnalyzeErrors(project.AssemblyReferences, findErrorFunc, errorValue)))
                    .Where(item => item.HasErrors);
            return errorResults;
        }

        public static IEnumerable<ProjectFileErrorResult> CheckProjectReferencesForErrors(
            this IEnumerable<ProjectFile> projects,
            Func<ProjectReference, bool> findErrorFunc,
            Func<ProjectReference, string> errorValue)
        {
            if (projects == null)
            {
                throw new ArgumentNullException(nameof(projects));
            }

            if (findErrorFunc == null)
            {
                throw new ArgumentNullException(nameof(findErrorFunc));
            }

            if (errorValue == null)
            {
                throw new ArgumentNullException(nameof(errorValue));
            }

            var errorResults = projects.Select(project => new ProjectFileErrorResult(
                                                project,
                                                ProjectFileErrorAnalyzer.AnalyzeErrors(project.ProjectReferences, findErrorFunc, errorValue)))
                                       .Where(item => item.HasErrors);
            return errorResults;
        }

        public static IEnumerable<ProjectFileErrorResult> CheckProjectReferencesForErrors(
            this ProjectFile project,
            Func<ProjectReference, bool> findErrorFunc,
            Func<ProjectReference, string> errorValue)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            if (findErrorFunc == null)
            {
                throw new ArgumentNullException(nameof(findErrorFunc));
            }

            if (errorValue == null)
            {
                throw new ArgumentNullException(nameof(errorValue));
            }

            var result = ProjectFileErrorAnalyzer.AnalyzeErrors(project.ProjectReferences, findErrorFunc, errorValue).ToList();
            var errorResults = result.Select(item => new ProjectFileErrorResult(project, result));
            return errorResults;
        }

        public static IEnumerable<ProjectFileErrorResult> CheckAssemblyReferencesForErrors(
            this ProjectFile project,
            Func<AssemblyReference, bool> findErrorFunc,
            Func<AssemblyReference, string> errorValue)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            if (findErrorFunc == null)
            {
                throw new ArgumentNullException(nameof(findErrorFunc));
            }

            if (errorValue == null)
            {
                throw new ArgumentNullException(nameof(errorValue));
            }

            var result = ProjectFileErrorAnalyzer.AnalyzeErrors(project.AssemblyReferences, findErrorFunc, errorValue).ToList();
            var errorResults = result.Select(item => new ProjectFileErrorResult(project, result));
            return errorResults;
        }

        public static IEnumerable<ProjectFileErrorResult> CheckProjectsForErrors(
            this IEnumerable<ProjectFile> projects,
            Func<ProjectFile, bool> findErrorFunc,
            Func<ProjectFile, string> errorValue)
        {
            if (projects == null)
            {
                throw new ArgumentNullException(nameof(projects));
            }

            if (findErrorFunc == null)
            {
                throw new ArgumentNullException(nameof(findErrorFunc));
            }

            if (errorValue == null)
            {
                throw new ArgumentNullException(nameof(errorValue));
            }

            var errorResults = projects.Select(project =>
            {
                var analyzeResult = ProjectFileErrorAnalyzer.AnalyzeErrors(project, findErrorFunc, errorValue);
                var errors = analyzeResult == null ? new string[] { } : new[] { analyzeResult };
                return new ProjectFileErrorResult(project, errors);
            })
                                        .Where(item => item.HasErrors);
            return errorResults;
        }
    }
}