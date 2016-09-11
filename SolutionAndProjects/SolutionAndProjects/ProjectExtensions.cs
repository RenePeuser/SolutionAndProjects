using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Extensions;

namespace SolutionAndProjects
{
    public static class ProjectExtensions
    {
        public static IEnumerable<ProjectErrorResult> CheckAssemblyReferencesForErrors(
            this IEnumerable<Project> projects,
            Func<AssemblyReference, bool> findErrorFunc,
            Func<AssemblyReference, string> errorValue)
        {
            Contract.Requires(projects.IsNotNull());
            Contract.Requires(findErrorFunc.IsNotNull());
            Contract.Requires(errorValue.IsNotNull());

            var errorResults =
                projects.Select(
                    project =>
                    new ProjectErrorResult(
                        project,
                        project.AssemblyReferences.AnalyzeErrors(findErrorFunc, errorValue)))
                    .Where(item => item.HasErrors);
            return errorResults;
        }

        public static IEnumerable<ProjectErrorResult> CheckProjectReferencesForErrors(
            this IEnumerable<Project> projects,
            Func<ProjectReference, bool> findErrorFunc,
            Func<ProjectReference, string> errorValue)
        {
            Contract.Requires(projects.IsNotNull());
            Contract.Requires(findErrorFunc.IsNotNull());
            Contract.Requires(errorValue.IsNotNull());

            var errorResults = projects.Select(project => new ProjectErrorResult(
                                                project,
                                                project.ProjectReferences.AnalyzeErrors(findErrorFunc, errorValue)))
                                       .Where(item => item.HasErrors);
            return errorResults;
        }

        public static IEnumerable<ProjectErrorResult> CheckProjectsForErrors(
            this IEnumerable<Project> projects,
            Func<Project, bool> findErrorFunc,
            Func<Project, string> errorValue)
        {
            Contract.Requires(projects.IsNotNull());
            Contract.Requires(findErrorFunc.IsNotNull());
            Contract.Requires(errorValue.IsNotNull());

            var errorResults = projects.Select(project =>
                                                {
                                                    var analyzeResult = project.AnalyzeErrors(findErrorFunc, errorValue);
                                                    var errors = analyzeResult == null ? new string[] { } : new[] { analyzeResult };
                                                    return new ProjectErrorResult(project, errors);
                                                })
                                        .Where(item => item.HasErrors);
            return errorResults;
        }

        public static ProjectErrorResult CheckProjectForErrors(
            this Project project,
            Func<Project, bool> findErrorFunc,
            Func<Project, string> errorValue)
        {
            Contract.Requires(project.IsNotNull());
            Contract.Requires(findErrorFunc.IsNotNull());
            Contract.Requires(errorValue.IsNotNull());

            var errorResults = new ProjectErrorResult(project, new[] { project.AnalyzeErrors(findErrorFunc, errorValue) });
            return errorResults;
        }
    }
}
