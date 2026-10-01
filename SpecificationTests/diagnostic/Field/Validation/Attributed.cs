using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Field.Validation
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void AttributeOnStatic()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<DependencyAttributeStaticType>();
            });
        }

        [TestMethod]
        public void OptionalAttributeOnStatic()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<OptionalDependencyAttributeStaticType>();
            });
        }

        [TestMethod]
        public void AttributeOnReadOnly()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<DependencyAttributeReadOnlyType>();
            });
        }

        [TestMethod]
        public void OptionalAttributeOnReadOnly()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<OptionalDependencyAttributeReadOnlyType>();
            });
        }

        [TestMethod]
        public void AttributeOnPrivate()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<DependencyAttributePrivateType>();
            });
        }

        [TestMethod]
        public void AttributeOnProtected()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<DependencyAttributeProtectedType>();
            });
        }

        [TestMethod]
        public void OptionalAttributeOnPrivate()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<OptionalDependencyAttributePrivateType>();
            });
        }

        [TestMethod]
        public void OptionalAttributeOnProtected()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<OptionalDependencyAttributeProtectedType>();
            });
        }
    }
}
