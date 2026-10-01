using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Cyclic
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void MethodToInterface()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Arrange
                Container.RegisterType<I1, F1>();

                // Act
                Container.Resolve<F1>();
            });
        }
    }
}
