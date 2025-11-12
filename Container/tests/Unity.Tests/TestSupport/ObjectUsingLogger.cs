namespace Unity.Tests.v5.TestSupport
{
    public class ObjectUsingLogger
    {
        private ILogger logger;

        [Dependency]
        public ILogger Logger
        {
            get => logger;
            set => logger = value;
        }
    }
}
