using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Method.Attribute
{
    public abstract partial class SpecificationTests : TestFixtureBase
    {
        [TestMethod]
        public void NoParameters()
        {
            // Act
            var result = Container.Resolve<TypeNoParameters>();

            // Verify
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void WithParameters()
        {
            // Act
            var result = Container.Resolve<TypeWithParameter>();

            // Verify
            Assert.IsNotNull(result);
            Assert.AreEqual(Name, result.Data);
        }

        [TestMethod]
        public void WithRefParameters()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<TypeWithRefParameter>();

                // Verify
                Assert.Fail();
            });
        }

        [TestMethod]
        public void WithOutParameters()
        {
            Assert.ThrowsExactly<ResolutionFailedException>(() =>
            {
                // Act
                var result = Container.Resolve<TypeWithOutParameter>();

                // Verify
                Assert.Fail();
            });
        }
    }
}
