using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Cyclic
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void PropertyToInterface()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Arrange
                Container.RegisterType<I1, E1>();

                // Act
                Container.Resolve<E1>();
            });
        }
    }
}
