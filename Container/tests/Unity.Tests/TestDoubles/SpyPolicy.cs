namespace Unity.Tests.v5.TestDoubles
{
    /// <summary>
    /// A sample policy that gets used by the SpyStrategy
    /// if present to mark execution.
    /// </summary>
    internal class SpyPolicy 
    {
        private bool wasSpiedOn;

        public bool WasSpiedOn
        {
            get => wasSpiedOn;
            set => wasSpiedOn = value;
        }
    }
}
