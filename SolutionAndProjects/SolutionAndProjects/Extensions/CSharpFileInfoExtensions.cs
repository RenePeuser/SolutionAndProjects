using System.Diagnostics.Contracts;
using System.IO;
using Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Extensions
{
    public static class CSharpFileInfoExtensions
    {
        public static SyntaxTree ParseFile(this CSharpFileInfo csharpFileInfo)
        {
            Contract.Requires(csharpFileInfo.IsNotNull());

            var text = File.ReadAllText(csharpFileInfo.Value.FullName);
            var syntaxTree = CSharpSyntaxTree.ParseText(text);
            return syntaxTree;
        }
    }
}
