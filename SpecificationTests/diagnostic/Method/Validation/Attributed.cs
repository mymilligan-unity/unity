using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Method.Validation
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void AttributeOnStatic()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<AttributeStaticType>();
            });
        }

        [TestMethod]
        public void AttributeOnPrivate()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<AttributePrivateType>();
            });
        }

        [TestMethod]
        public void AttributeOnProtected()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<AttributeProtectedType>();
            });
        }

        [TestMethod]
        public void AttributeOnOpenGeneric()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<AttributeOpenGenericType>();
            });
        }

        [TestMethod]
        public void AttributeOnOutParam()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<AttributeOutParamType>();
            });
        }

        [TestMethod]
        public void AttributeOnRefParam()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<AttributeRefParamType>();
            });
        }
    }
}
