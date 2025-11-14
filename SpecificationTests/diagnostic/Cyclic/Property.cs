using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Cyclic
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void PropertyToInterface()
        {
            // Arrange
            Container.RegisterType<I1, E1>();

            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<E1>());
        }
    }
}
