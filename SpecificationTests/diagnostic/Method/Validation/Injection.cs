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
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<InjectedType>(
                    Invoke.Method("PrivateMethod"));
            });
        }

        [Ignore]
        [TestMethod]
        public void InjectProtectedMethod()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<InjectedType>(
                    Invoke.Method("ProtectedMethod"));
            });
        }

        [Ignore]
        [TestMethod]
        public void InjectStaticMethod()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<InjectedType>(
                    Invoke.Method(nameof(InjectedType.StaticMethod)));
            });
        }

        [Ignore]
        [TestMethod]
        public void InjectOpenGenericMethod()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<InjectedType>(
                    Invoke.Method(nameof(InjectedType.OpenGenericMethod)));
            });
        }

        [Ignore]
        [TestMethod]
        public void InjectOutParamMethod()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<InjectedType>(
                    Invoke.Method(nameof(InjectedType.OutParamMethod)));
            });
        }

        [Ignore]
        [TestMethod]
        public void InjectRefParamMethod()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<InjectedType>(
                    Invoke.Method(nameof(InjectedType.RefParamMethod)));
            });
        }
    }
}
