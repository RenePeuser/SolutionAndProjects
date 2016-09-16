using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Extensions;
using Microsoft.CodeAnalysis;

namespace SolutionAndProjects.Extensions
{
    public static class SyntaxTreeExtensions
    {
        public static IEnumerable<T> AllOf<T>(this SyntaxTree syntaxTree) where T : SyntaxNode
        {
            Contract.Requires(syntaxTree.IsNotNull());

            var result = syntaxTree.GetRoot().DescendantNodes().OfType<T>();
            return result;
        }
    }
}
