using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Constructor.Attribute
{
    public abstract partial class SpecificationTests : Specification.Constructor.Attribute.SpecificationTests
    {
        [TestMethod]
        public override void MultipleConstructorsAnnotated() => Assert.ThrowsExactly<ResolutionFailedException>(() => base.MultipleConstructorsAnnotated());
    }
}
