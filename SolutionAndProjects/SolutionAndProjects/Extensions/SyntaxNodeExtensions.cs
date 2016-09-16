using System.Diagnostics.Contracts;
using Extensions;
using Microsoft.CodeAnalysis;

namespace SolutionAndProjects.Extensions
{
    public static class SyntaxNodeExtensions
    {
        public static T FindParent<T>(this SyntaxNode syntaxNode) where T : SyntaxNode
        {
            Contract.Requires(syntaxNode.IsNotNull());

            var currentNode = syntaxNode;
            var result = syntaxNode.As<T>();

            while (result == null && currentNode != null)
            {
                result = currentNode.Parent.As<T>();
                currentNode = currentNode.Parent;
            }

            return result;
        }
    }
}
