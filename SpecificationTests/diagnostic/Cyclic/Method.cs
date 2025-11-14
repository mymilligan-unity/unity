using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Cyclic
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void MethodToInterface()
        {
            // Arrange
            Container.RegisterType<I1, F1>();

            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<F1>());
        }
    }
}
