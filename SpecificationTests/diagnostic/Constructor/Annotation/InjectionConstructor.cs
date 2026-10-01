using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Specification.TestData;

namespace Unity.Specification.Diagnostic.Constructor.Annotation
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void Constructor()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var instance = Container.Resolve<Service>();

                // 2 == instance.Ctor

                // Assert
                Assert.AreEqual(2, instance.Ctor);
            });
        }

        [TestMethod]
        public void MultipleConstructorsAnnotated()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var instance = Container.Resolve<TypeWithAmbuguousAnnotations>();

                // 2 == instance.Ctor

                // Assert
                Assert.AreEqual(Container, instance.Container);
            });
        }
    }
}
