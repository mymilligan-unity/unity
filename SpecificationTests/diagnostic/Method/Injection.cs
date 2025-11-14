using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Method.Injection
{
    public abstract partial class SpecificationTests : Specification.Method.Injection.SpecificationTests
    {
        public override void InjectingStaticMethod() => Assert.Throws<ResolutionFailedException>(() => base.InjectingStaticMethod());

        public override void MethodPassingVoid() => Assert.Throws<ResolutionFailedException>(() => base.MethodPassingVoid());

        public override void ReturningInt() => Assert.Throws<ResolutionFailedException>(() => base.ReturningInt());

        public override void ReturningVoid() => Assert.Throws<ResolutionFailedException>(() => base.ReturningVoid());

        [TestMethod]
        public override void StaticIsIgnoredInOptimized() => Assert.Throws<ResolutionFailedException>(() => base.StaticIsIgnoredInOptimized());

        [TestMethod]
        public override void InjectTypeWithAnnotatdStatic() => Assert.Throws<ResolutionFailedException>(() => base.InjectTypeWithAnnotatdStatic());
    }
}
