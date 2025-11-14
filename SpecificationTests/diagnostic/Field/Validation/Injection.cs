using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unity.Specification.Diagnostic.Field.Validation
{
    public abstract partial class SpecificationTests
    {
        [Ignore]
        [TestMethod]
        public void NoReuse()
        {
            // Arrange
            var field = Inject.Field(nameof(DependencyInjectedType.NormalField), "test");

            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<DependencyInjectedType>("1", field)
                                                                    .RegisterType<DependencyInjectedType>("2", field));
        }

        [Ignore]
        [TestMethod]
        public void InjectReadOnlyField()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<DependencyInjectedType>(
                Inject.Field(nameof(DependencyInjectedType.ReadonlyField), "test")));
        }

        [Ignore]
        [TestMethod]
        public void InjectPrivateField()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<DependencyInjectedType>(
                Inject.Field("PrivateField", "test")));
        }

        [Ignore]
        [TestMethod]
        public void InjectProtectedField()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<DependencyInjectedType>(
                Inject.Field("ProtectedField", "test")));
        }

        [Ignore]
        [TestMethod]
        public void InjectStaticField()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<DependencyInjectedType>(
                Inject.Field(nameof(DependencyInjectedType.StaticField), "test")));
        }
    }
}
