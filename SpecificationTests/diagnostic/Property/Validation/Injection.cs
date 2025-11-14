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
            // Arrange
            var property = Inject.Property(nameof(DependencyInjectedType.NormalProperty), "test");

            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<DependencyInjectedType>("1", property)
                                                                   .RegisterType<DependencyInjectedType>("2", property));
        }


        [Ignore]
        [TestMethod]
        public void InjectReadOnlyProperty()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<DependencyInjectedType>(
                Inject.Property(nameof(DependencyInjectedType.ReadonlyProperty), "test")));
        }

        [Ignore]
        [TestMethod]
        public void InjectPrivateProperty()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<DependencyInjectedType>(
                Inject.Property("PrivateProperty", "test")));
        }

        [Ignore]
        [TestMethod]
        public void InjectProtectedProperty()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<DependencyInjectedType>(
                Inject.Property("ProtectedProperty", "test")));
        }

        [Ignore]
        [TestMethod]
        public void InjectStaticProperty()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<DependencyInjectedType>(
                Inject.Property(nameof(DependencyInjectedType.StaticProperty), "test")));
        }
    }
}
