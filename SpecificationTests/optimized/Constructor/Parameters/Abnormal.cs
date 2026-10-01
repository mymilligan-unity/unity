using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Constructor.Parameters
{
    public abstract partial class SpecificationTests
    {

        [TestMethod]
        public void UnresolvableParameter()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var instance = Container.Resolve<Unresolvable>();

                // Validate
                Assert.IsNotNull(instance);
            });
        }

        [TestMethod]
        public void RefParameter()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                Container.Resolve<TypeWithRefParameter>();
            });
        }

        [TestMethod]
        public void OutParameter()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                Container.Resolve<TypeWithOutParameter>();
            });
        }

        [TestMethod]
        public void StructParameter()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var instance = Container.Resolve<TypeWithStructParameter>();

                // Validate
                Assert.IsNotNull(instance);
            });
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
