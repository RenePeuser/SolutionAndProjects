﻿using System.Xml.Linq;
using Extensions;

namespace SolutionAndProjects.Models
{
    public class AssemblyReference : ReferenceBase
    {
        private const string Version = "Version=";

        internal AssemblyReference(string include, bool copyLocal, string hintPath, bool specificVersion) : base(include, copyLocal)
        {
            HintPath = hintPath;
            SpecificVersion = specificVersion;
        }

        public string HintPath { get; }

        public bool SpecificVersion { get; }
    }
}
