using System;
using System.Xml.Linq;
using Extensions;

namespace SolutionAndProjects
{
    public class ProjectReference : ReferenceBase
    {
        internal ProjectReference(XElement referenceElement)
            : base(referenceElement)
        {
            Name = referenceElement.ElementBy("Name".ToLocalName()).ValueOrDefault(string.Empty);
        }

        public string Name { get; }
    }
}
