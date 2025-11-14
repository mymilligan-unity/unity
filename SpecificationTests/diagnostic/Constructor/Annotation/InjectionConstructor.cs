using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Specification.TestData;

namespace Unity.Specification.Diagnostic.Constructor.Annotation
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void Constructor()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<Service>());
        }

        [TestMethod]
        public void MultipleConstructorsAnnotated()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<TypeWithAmbuguousAnnotations>());
        }
    }
}
