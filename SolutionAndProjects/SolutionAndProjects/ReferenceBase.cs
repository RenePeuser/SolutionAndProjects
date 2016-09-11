using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Extensions;

namespace SolutionAndProjects
{
    public abstract class ReferenceBase
    {
        protected ReferenceBase(XElement referenceElement)
        {
            Contract.Requires(referenceElement.IsNotNull());

            Include = referenceElement.AttributeBy("Include".ToAttributeName()).ToString();
            CopyLocal = referenceElement.ElementBy("Private".ToLocalName()).ToBool(true);
        }

        public string Include { get; }

        public bool CopyLocal { get; }
    }
}
