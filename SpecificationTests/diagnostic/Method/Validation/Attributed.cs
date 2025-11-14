using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Method.Validation
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void AttributeOnStatic()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<AttributeStaticType>());
        }

        [TestMethod]
        public void AttributeOnPrivate()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<AttributePrivateType>());
        }

        [TestMethod]
        public void AttributeOnProtected()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<AttributeProtectedType>());
        }

        [TestMethod]
        public void AttributeOnOpenGeneric()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<AttributeOpenGenericType>());
        }

        [TestMethod]
        public void AttributeOnOutParam()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<AttributeOutParamType>());
        }

        [TestMethod]
        public void AttributeOnRefParam()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<AttributeRefParamType>());
        }
    }
}
