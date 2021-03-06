// <copyright file="ProjectFileErrorAnalyzerTest.cs">Copyright ©  2016</copyright>
using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionAndProjects.Analyzer;

namespace SolutionAndProjects.Analyzer.Tests
{
    /// <summary>This class contains parameterized unit tests for ProjectFileErrorAnalyzer</summary>
    [PexClass(typeof(ProjectFileErrorAnalyzer))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ProjectFileErrorAnalyzerTest
    {
        /// <summary>Test stub for AnalyzeErrors(IEnumerable`1&lt;!!0&gt;, Func`2&lt;!!0,Boolean&gt;, Func`2&lt;!!0,String&gt;)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        internal IEnumerable<string> AnalyzeErrorsTest<T>(
            IEnumerable<T> source,
            Func<T, bool> filterFunc,
            Func<T, string> errorValue
        )
        {
            IEnumerable<string> result
               = ProjectFileErrorAnalyzer.AnalyzeErrors<T>(source, filterFunc, errorValue);
            return result;
            // TODO: add assertions to method ProjectFileErrorAnalyzerTest.AnalyzeErrorsTest(IEnumerable`1<!!0>, Func`2<!!0,Boolean>, Func`2<!!0,String>)
        }

        /// <summary>Test stub for AnalyzeErrors(!!0, Func`2&lt;!!0,Boolean&gt;, Func`2&lt;!!0,String&gt;)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        internal string AnalyzeErrorsTest01<T>(
            T source,
            Func<T, bool> filterFunc,
            Func<T, string> errorValue
        )
        {
            string result
               = ProjectFileErrorAnalyzer.AnalyzeErrors<T>(source, filterFunc, errorValue);
            return result;
            // TODO: add assertions to method ProjectFileErrorAnalyzerTest.AnalyzeErrorsTest01(!!0, Func`2<!!0,Boolean>, Func`2<!!0,String>)
        }
    }
}
