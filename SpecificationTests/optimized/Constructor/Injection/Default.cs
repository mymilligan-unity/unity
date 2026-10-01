using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Constructor.Injection
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public void InjectDefaultCtor()
        {
            // Arrange

            Container.RegisterType<Service>(Invoke.Constructor());

            // Act

            var instance = Container.Resolve<Service>();

            // 1 == instance.Ctor

            // Validate
            Assert.AreEqual(1, instance.Ctor);
        }

        [TestMethod]
        public void InjectDefaultCtorClosedGeneric()
        {
            // Arrange

            Container.RegisterType<Service<object>>(Invoke.Constructor());

            // Act

            var instance = Container.Resolve<Service<object>>();

            // 1 == instance.Ctor

            // Validate
            Assert.AreEqual(1, instance.Ctor);
        }


        [TestMethod]
        public void InjectDefaultCtorOpenGeneric()
        {
            // Arrange

            Container.RegisterType(typeof(Service<>), Invoke.Constructor());

            // Act
            var instance = Container.Resolve<Service<object>>();

            // Validate
            Assert.AreEqual(1, instance.Ctor);
        }
    }
}
