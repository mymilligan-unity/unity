using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Cyclic
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void ParameterToInterface()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Arrange
                Container.RegisterType<I1, B1>();

                // Act
                Container.Resolve<I1>();
            });
        }
    }
}
