using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace SolutionAndProjects.Extensions
{
    public static class SyntaxTreeExtensions
    {
        public static IEnumerable<T> AllOf<T>(this SyntaxTree syntaxTree) where T : SyntaxNode
        {
            if (syntaxTree == null)
            {
                throw new ArgumentNullException(nameof(syntaxTree));
            }

            var result = syntaxTree.GetRoot().DescendantNodes().OfType<T>();
            return result;
        }
    }
}
