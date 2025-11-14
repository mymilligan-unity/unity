using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Cyclic
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void ParameterToInterface()
        {
            // Arrange
            Container.RegisterType<I1, B1>();

            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<I1>());
        }
    }
}
