using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Method.Parameters
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void RefParameter()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                Container.Resolve<TypeWithMethodWithRefParameter>();
            });
        }

        [TestMethod]
        public void OutParameter()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                Container.Resolve<TypeWithMethodWithOutParameter>();
            });
        }
    }
}
