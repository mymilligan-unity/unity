using Unity.Extension;

namespace Unity.Tests.v5.TestDoubles
{
    internal class MockContainerExtension : UnityContainerExtension, IMockConfiguration
    {
        private bool _initializeWasCalled;

        public bool InitializeWasCalled => _initializeWasCalled;

        public new ExtensionContext Context => base.Context;

        protected override void Initialize()
        {
            _initializeWasCalled = true;
        }
    }

    internal interface IMockConfiguration : IUnityContainerExtensionConfigurator
    {   
    }
}
