using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unity.Specification.Diagnostic.Constructor.Injection
{
    public abstract partial class SpecificationTests : Specification.Constructor.Injection.SpecificationTests
    {
        [TestMethod]
        public override void NoBogusConstructor() => base.NoBogusConstructor();

        [TestMethod]
        public override void NoBogusValuesConstructor() => base.NoBogusValuesConstructor();

        [TestMethod]
        public override void NoDefaultConstructor() => base.NoDefaultConstructor();

        [TestMethod]
        public override void NoConstructor() => base.NoConstructor();

        [TestMethod]
        public override void MultipleConstructor() => Assert.ThrowsExactly<ResolutionFailedException>(() => base.MultipleConstructor());

        [DataTestMethod]
        [DynamicData(nameof(ConstructorSelectionTestData), typeof(Specification.Constructor.Injection.SpecificationTests))]
        public override void Selection(string name, Type typeFrom, Type typeTo, Type typeToResolve, object[] parameters, Func<object, bool> validator) => 
            base.Selection(name, typeFrom, typeTo, typeToResolve, parameters, validator);

        [TestMethod]
        public override void AmbiguousCtorInGraph() => Assert.ThrowsExactly<ResolutionFailedException>(() => base.AmbiguousCtorInGraph());
    }
}
