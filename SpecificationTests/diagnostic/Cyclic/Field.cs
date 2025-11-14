using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Cyclic
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void FieldToInterface()
        {
            // Arrange
            Container.RegisterType<I1, D1>();

            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<D1>());
        }
    }
}
