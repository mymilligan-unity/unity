using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unity.Specification.Diagnostic.Method.Validation
{
    public abstract partial class SpecificationTests
    {
        [Ignore]
        [TestMethod]
        public void NoReuse()
        {
            // Arrange
            var method = Invoke.Method(nameof(InjectedType.NormalMethod));

            // Act
            Container.RegisterType<InjectedType>("1", method)
                     .RegisterType<InjectedType>("2", method);
        }

        [Ignore]
        [TestMethod]
        public void InjectPrivateMethod()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<InjectedType>(
                Invoke.Method("PrivateMethod")));
        }

        [Ignore]
        [TestMethod]
        public void InjectProtectedMethod()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<InjectedType>(
                Invoke.Method("ProtectedMethod")));
        }

        [Ignore]
        [TestMethod]
        public void InjectStaticMethod()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<InjectedType>(
                Invoke.Method(nameof(InjectedType.StaticMethod))));
        }

        [Ignore]
        [TestMethod]
        public void InjectOpenGenericMethod()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<InjectedType>(
                Invoke.Method(nameof(InjectedType.OpenGenericMethod))));
        }

        [Ignore]
        [TestMethod]
        public void InjectOutParamMethod()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<InjectedType>(
                Invoke.Method(nameof(InjectedType.OutParamMethod))));
        }

        [Ignore]
        [TestMethod]
        public void InjectRefParamMethod()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<InjectedType>(
                Invoke.Method(nameof(InjectedType.RefParamMethod))));
        }
    }
}
