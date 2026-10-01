using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unity.Specification.Diagnostic.Method.Validation
{
    public abstract partial class SpecificationTests
    {
        [Ignore]
        [TestMethod]
        public void AnonymousTypeForGenericFails()
        {
            Assert.ThrowsExactly<InvalidOperationException>(() =>
            {
                // Act
                Container.RegisterType(typeof(GenericService<,,>),
                    Invoke.Method("Method", Resolve.Parameter()));
            });
        }
    }
}
