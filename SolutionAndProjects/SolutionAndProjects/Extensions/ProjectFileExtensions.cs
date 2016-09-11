using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Extensions;
using SolutionAndProjects.Analyzer;
using SolutionAndProjects.Models;

namespace SolutionAndProjects.Extensions
{
    public static class ProjectFileExtensions
    {
        public static IEnumerable<ProjectFileErrorResult> CheckAssemblyReferencesForErrors(
            this IEnumerable<ProjectFile> projects,
            Func<AssemblyReference, bool> findErrorFunc,
            Func<AssemblyReference, string> errorValue)
        {
            Contract.Requires(projects.IsNotNull());
            Contract.Requires(findErrorFunc.IsNotNull());
            Contract.Requires(errorValue.IsNotNull());

            var errorResults =
                projects.Select(
                    project =>
                    new ProjectFileErrorResult(
                        project,
                        project.AssemblyReferences.AnalyzeErrors(findErrorFunc, errorValue)))
                    .Where(item => item.HasErrors);
            return errorResults;
        }

        public static IEnumerable<ProjectFileErrorResult> CheckProjectReferencesForErrors(
            this IEnumerable<ProjectFile> projects,
            Func<ProjectReference, bool> findErrorFunc,
            Func<ProjectReference, string> errorValue)
        {
            Contract.Requires(projects.IsNotNull());
            Contract.Requires(findErrorFunc.IsNotNull());
            Contract.Requires(errorValue.IsNotNull());

            var errorResults = projects.Select(project => new ProjectFileErrorResult(
                                                project,
                                                project.ProjectReferences.AnalyzeErrors(findErrorFunc, errorValue)))
                                       .Where(item => item.HasErrors);
            return errorResults;
        }

        public static IEnumerable<ProjectFileErrorResult> CheckProjectsForErrors(
            this IEnumerable<ProjectFile> projects,
            Func<ProjectFile, bool> findErrorFunc,
            Func<ProjectFile, string> errorValue)
        {
            Contract.Requires(projects.IsNotNull());
            Contract.Requires(findErrorFunc.IsNotNull());
            Contract.Requires(errorValue.IsNotNull());

            var errorResults = projects.Select(project =>
                                                {
                                                    var analyzeResult = project.AnalyzeErrors(findErrorFunc, errorValue);
                                                    var errors = analyzeResult == null ? new string[] { } : new[] { analyzeResult };
                                                    return new ProjectFileErrorResult(project, errors);
                                                })
                                        .Where(item => item.HasErrors);
            return errorResults;
        }

        public static ProjectFileErrorResult CheckProjectForErrors(
            this ProjectFile projectFile,
            Func<ProjectFile, bool> findErrorFunc,
            Func<ProjectFile, string> errorValue)
        {
            Contract.Requires(projectFile.IsNotNull());
            Contract.Requires(findErrorFunc.IsNotNull());
            Contract.Requires(errorValue.IsNotNull());

            var errorResults = new ProjectFileErrorResult(projectFile, new[] { projectFile.AnalyzeErrors(findErrorFunc, errorValue) });
            return errorResults;
        }
    }
}
