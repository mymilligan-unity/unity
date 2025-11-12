using System;

namespace Unity.Tests.v5.ChildContainer
{
    public class TestContainer : ITestContainer, IDisposable
    {
        private bool wasDisposed = false;

        public bool WasDisposed
        {
            get => wasDisposed;
            set => wasDisposed = value;
        }

        public void Dispose()
        {
            wasDisposed = true;
        }
    }
}