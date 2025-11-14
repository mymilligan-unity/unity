using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Field.Validation
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void AttributeOnStatic()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<DependencyAttributeStaticType>());
        }

        [TestMethod]
        public void OptionalAttributeOnStatic()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<OptionalDependencyAttributeStaticType>());
        }

        [TestMethod]
        public void AttributeOnReadOnly()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<DependencyAttributeReadOnlyType>());
        }

        [TestMethod]
        public void OptionalAttributeOnReadOnly()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<OptionalDependencyAttributeReadOnlyType>());
        }

        [TestMethod]
        public void AttributeOnPrivate()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<DependencyAttributePrivateType>());
        }

        [TestMethod]
        public void AttributeOnProtected()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<DependencyAttributeProtectedType>());
        }

        [TestMethod]
        public void OptionalAttributeOnPrivate()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<OptionalDependencyAttributePrivateType>());
        }

        [TestMethod]
        public void OptionalAttributeOnProtected()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<OptionalDependencyAttributeProtectedType>());
        }
    }
}
