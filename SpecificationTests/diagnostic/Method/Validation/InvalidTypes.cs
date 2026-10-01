using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unity.Specification.Diagnostic.Method.Validation
{
    public abstract partial class SpecificationTests
    {
        [Ignore]
        [TestMethod]
        public void GenericInjectionMethod()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<OpenGenericInjectionMethod>(
                    Invoke.Method(nameof(OpenGenericInjectionMethod.InjectMe)));
            });
        }

        [Ignore]
        [TestMethod]
        public void MethodWithRefParameter()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<TypeWithMethodWithInvalidParameter>(
                    Invoke.Method(nameof(TypeWithMethodWithInvalidParameter.MethodWithRefParameter)));
            });
        }

        [Ignore]
        [TestMethod]
        public void MethodWithOutParameter()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType<TypeWithMethodWithInvalidParameter>(
                    Invoke.Method(nameof(TypeWithMethodWithInvalidParameter.MethodWithOutParameter)));
            });
        }

    }
}
