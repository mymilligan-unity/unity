using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Method.Parameters
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void RefParameter()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<TypeWithMethodWithRefParameter>());
        }

        [TestMethod]
        public void OutParameter()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<TypeWithMethodWithOutParameter>());
        }
    }
}
