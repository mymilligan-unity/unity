using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unity.Specification.Diagnostic.Constructor.Injection
{
    public abstract partial class SpecificationTests : Specification.Constructor.Injection.SpecificationTests
    {
        [TestMethod]
        public override void NoBogusConstructor() => Assert.Throws<ResolutionFailedException>(() => base.NoBogusConstructor());

        [TestMethod]
        public override void NoBogusValuesConstructor() => Assert.Throws<ResolutionFailedException>(() => base.NoBogusValuesConstructor());

        [TestMethod]
        public override void NoDefaultConstructor() => Assert.Throws<ResolutionFailedException>(() => base.NoDefaultConstructor());

        [TestMethod]
        public override void NoConstructor() => Assert.Throws<ResolutionFailedException>(() => base.NoConstructor());

        [TestMethod]
        public override void MultipleConstructor() => Assert.Throws<ResolutionFailedException>(() => base.MultipleConstructor());

        [TestMethod]
        [DynamicData(nameof(ConstructorSelectionTestData), typeof(Specification.Constructor.Injection.SpecificationTests))]
        public override void Selection(string name, Type typeFrom, Type typeTo, Type typeToResolve, object[] parameters, Func<object, bool> validator) => 
            base.Selection(name, typeFrom, typeTo, typeToResolve, parameters, validator);

        [TestMethod]
        public override void AmbiguousCtorInGraph() => Assert.Throws<ResolutionFailedException>(() => base.AmbiguousCtorInGraph());
    }
}
