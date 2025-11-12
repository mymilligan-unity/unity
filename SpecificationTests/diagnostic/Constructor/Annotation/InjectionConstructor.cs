using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Specification.TestData;

namespace Unity.Specification.Diagnostic.Constructor.Annotation
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ResolutionFailedException))]
        public void Constructor()
        {
            // Act
            var instance = Container.Resolve<Service>();

            // 2 == instance.Ctor

            // Assert
            Assert.AreEqual(2, instance.Ctor);
        }

        [TestMethod]
        [ExpectedException(typeof(ResolutionFailedException))]
        public void MultipleConstructorsAnnotated()
        {
            // Act
            var instance = Container.Resolve<TypeWithAmbuguousAnnotations>();

            // 2 == instance.Ctor

            // Assert
            Assert.AreEqual(Container, instance.Container);
        }
    }
}
