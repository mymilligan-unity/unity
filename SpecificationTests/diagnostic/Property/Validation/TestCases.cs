using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unity.Specification.Diagnostic.Property.Validation
{
    public abstract partial class SpecificationTests
    {
        [Ignore]
        [TestMethod]
        public void InvalidValue()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<ObjectWithThreeProperties>(
                    Inject.Property(nameof(ObjectWithThreeProperties.Container), Name));
            });
        }

        [Ignore]
        [TestMethod]
        public void ReadOnlyProperty()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<ObjectWithFourProperties>(
                    Inject.Property(nameof(ObjectWithFourProperties.ReadOnlyProperty), "test"));
            });
        }
    }
}
