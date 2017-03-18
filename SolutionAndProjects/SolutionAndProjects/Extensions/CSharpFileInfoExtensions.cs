using System;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using SolutionAndProjects.SpecificFileInfos;

namespace SolutionAndProjects.Extensions
{
    public static class CSharpFileInfoExtensions
    {
        public static SyntaxTree ParseFile(this CSharpFileInfo csharpFileInfo)
        {
            if (csharpFileInfo == null)
            {
                throw new ArgumentNullException(nameof(csharpFileInfo));
            }

            var text = File.ReadAllText(csharpFileInfo.Value.FullName);
            var syntaxTree = CSharpSyntaxTree.ParseText(text);
            return syntaxTree;
        }
    }
}
