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
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<ObjectWithThreeProperties>(
                Inject.Property(nameof(ObjectWithThreeProperties.Container), Name)));
        }

        [Ignore]
        [TestMethod]
        public void ReadOnlyProperty()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<ObjectWithFourProperties>(
                Inject.Property(nameof(ObjectWithFourProperties.ReadOnlyProperty), "test")));
        }
    }
}
