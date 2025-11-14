using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Constructor.Parameters
{
    public abstract partial class SpecificationTests
    {

        [TestMethod]
        public void UnresolvableParameter()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<Unresolvable>());
        }

        [TestMethod]
        public void RefParameter()
        {
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<TypeWithRefParameter>());
        }

        [TestMethod]
        public void OutParameter()
        {
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<TypeWithOutParameter>());
        }

        [TestMethod]
        public void StructParameter()
        {
            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<TypeWithStructParameter>());
        }

        [TestMethod]
        public void DynamicParameter()
        {
            // Act
            var instance = Container.Resolve<TypeWithDynamicParameter>();

            // Validate
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void NamedDynamicParameter()
        {
            // Act
            var instance = Container.Resolve<NamedTypeWithDynamicParameter>();

            // Validate
            Assert.IsNotNull(instance);
        }
    }
}
