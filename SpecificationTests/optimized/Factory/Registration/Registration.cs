using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unity.Specification.Factory.Registration
{
    public abstract partial class SpecificationTests
    {

        [TestMethod]
        public void Factory_IsNotNull()
        {
            Container.RegisterFactory<IService>((c, t, n) => new Service());
            Assert.IsNotNull(Container.Resolve<IService>());
        }

        [TestMethod]
        public void ShortSignatureThrowsOnNull()
        {
            Func<IUnityContainer, object> factoryFunc = null;
            Assert.Throws<ArgumentNullException>(() => Container.RegisterFactory<IService>(factoryFunc));
        }

        [TestMethod]
        public void LongSignatureThrowsOnNull()
        {
            Func<IUnityContainer, Type, string, object> factoryFunc = null;
            Assert.Throws<ArgumentNullException>(() => Container.RegisterFactory<IService>(factoryFunc));
        }
    }
}
