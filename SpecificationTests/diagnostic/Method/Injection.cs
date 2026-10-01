using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.Method.Injection
{
    public abstract partial class SpecificationTests : Specification.Method.Injection.SpecificationTests
    {
        public override void InjectingStaticMethod() => base.InjectingStaticMethod();

        public override void MethodPassingVoid() => Assert.ThrowsExactly<ResolutionFailedException>(() => base.MethodPassingVoid());

        public override void ReturningInt() => Assert.ThrowsExactly<ResolutionFailedException>(() => base.ReturningInt());

        public override void ReturningVoid() => Assert.ThrowsExactly<ResolutionFailedException>(() => base.ReturningVoid());

        [TestMethod]
        public override void StaticIsIgnoredInOptimized() => Assert.ThrowsExactly<ResolutionFailedException>(() => base.StaticIsIgnoredInOptimized());

        [TestMethod]
        public override void InjectTypeWithAnnotatdStatic() => Assert.ThrowsExactly<ResolutionFailedException>(() => base.InjectTypeWithAnnotatdStatic());
    }
}
