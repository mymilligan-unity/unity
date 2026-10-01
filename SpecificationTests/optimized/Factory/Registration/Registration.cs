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
            Assert.ThrowsExactly<ArgumentNullException>(() =>
            {
                Func<IUnityContainer, object> factoryFunc = null;
                Container.RegisterFactory<IService>(factoryFunc);
            });
        }

        [TestMethod]
        public void LongSignatureThrowsOnNull()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
            {
                Func<IUnityContainer, Type, string, object> factoryFunc = null;
                Container.RegisterFactory<IService>(factoryFunc);
            });
        }
    }
}
