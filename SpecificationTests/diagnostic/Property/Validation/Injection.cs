using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unity.Specification.Diagnostic.Property.Validation
{
    public abstract partial class SpecificationTests
    {
        [Ignore]
        [TestMethod]
        public void NoReuse()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Arrange
                var property = Inject.Property(nameof(DependencyInjectedType.NormalProperty), "test");

                // Act
                Container.RegisterType<DependencyInjectedType>("1", property)
                         .RegisterType<DependencyInjectedType>("2", property);
            });
        }


        [Ignore]
        [TestMethod]
        public void InjectReadOnlyProperty()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<DependencyInjectedType>(
                    Inject.Property(nameof(DependencyInjectedType.ReadonlyProperty), "test"));
            });
        }

        [Ignore]
        [TestMethod]
        public void InjectPrivateProperty()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<DependencyInjectedType>(
                    Inject.Property("PrivateProperty", "test"));
            });
        }

        [Ignore]
        [TestMethod]
        public void InjectProtectedProperty()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<DependencyInjectedType>(
                    Inject.Property("ProtectedProperty", "test"));
            });
        }

        [Ignore]
        [TestMethod]
        public void InjectStaticProperty()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<DependencyInjectedType>(
                    Inject.Property(nameof(DependencyInjectedType.StaticProperty), "test"));
            });
        }
    }
}
