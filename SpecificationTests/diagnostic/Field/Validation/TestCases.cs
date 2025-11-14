using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unity.Specification.Diagnostic.Field.Validation
{
    public abstract partial class SpecificationTests
    {
        [Ignore]
        [TestMethod]
        public void InvalidValue()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<ObjectWithThreeFields>(
                Inject.Field(nameof(ObjectWithThreeFields.Container), Name)));
        }

        [Ignore]
        [TestMethod]
        public void ReadOnlyProperty()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<ObjectWithFourFields>(
                Inject.Field(nameof(ObjectWithFourFields.ReadOnlyField), "test")));
        }
    }
}
