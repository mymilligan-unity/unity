
using Unity.Extension;

namespace Unity.Tests.v5.TestSupport
{
    public class MockContainerExtension : UnityContainerExtension, IMockConfiguration
    {
        private bool initializeWasCalled = false;

        public bool InitializeWasCalled => initializeWasCalled;

        public new ExtensionContext Context => base.Context;

        protected override void Initialize()
        {
            initializeWasCalled = true;
        }
    }

    public interface IMockConfiguration : IUnityContainerExtensionConfigurator
    {
    }
}
