using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Specification.Method.Parameters;

namespace Unity.Specification.Diagnostic.Method.Parameters
{
    public abstract partial class SpecificationTests : Unity.Specification.Method.Parameters.SpecificationTests
    {
        [TestInitialize]
        public override void Setup() => base.Setup();

        [TestMethod]
        public void ChainedExecuteMethodBaseline()
        {
            // Setup
            Container
                .RegisterType(typeof(ICommand<>), typeof(ConcreteCommand<>),
                    Invoke.Method("ChainedExecute"));

            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<ICommand<Account>>());
        }
    }
}
