using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Cyclic
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void FieldToInterface()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Arrange
                Container.RegisterType<I1, D1>();

                // Act
                Container.Resolve<D1>();
            });
        }
    }
}
