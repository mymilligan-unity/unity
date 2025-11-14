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
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<OpenGenericInjectionMethod>(
                Invoke.Method(nameof(OpenGenericInjectionMethod.InjectMe))));
        }

        [Ignore]
        [TestMethod]
        public void MethodWithRefParameter()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<TypeWithMethodWithInvalidParameter>(
                Invoke.Method(nameof(TypeWithMethodWithInvalidParameter.MethodWithRefParameter))));
        }

        [Ignore]
        [TestMethod]
        public void MethodWithOutParameter()
        {
            // Act
            Assert.Throws<InvalidOperationException>(() => Container.RegisterType<TypeWithMethodWithInvalidParameter>(
                Invoke.Method(nameof(TypeWithMethodWithInvalidParameter.MethodWithOutParameter))));
        }
    }
}
