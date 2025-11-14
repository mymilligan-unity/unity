using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Unity.Lifetime;

namespace Lifetime.Managers
{
    [TestClass]
    public class GlobalSingleton : Synchronized
    {
        protected override LifetimeManager GetManager() => new SingletonLifetimeManager();

        [TestMethod]
        public override void TryGetSetOtherContainerTest()
        {
            base.TryGetSetOtherContainerTest();

            // Validate
            Assert.AreSame(TestObject, TestManager.TryGetValue(OtherContainer));
            Assert.AreSame(TestObject, TestManager.GetValue(OtherContainer));
        }

        [TestMethod]
        public override void SetValueTwiceTest()
        {
            Assert.Throws<InvalidOperationException>(() => base.SetValueTwiceTest());
        }

        [TestMethod]
        public override void SetDifferentValuesTwiceTest()
        {
            Assert.Throws<InvalidOperationException>(() => base.SetDifferentValuesTwiceTest());
        }
    }
}
