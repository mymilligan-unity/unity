namespace Unity.Tests.v5.TestSupport
{
    public class ObjectWithTwoConstructorParameters
    {
        private string connectionString;
        private ILogger logger;

        public ObjectWithTwoConstructorParameters(string connectionString, ILogger logger)
        {
            this.connectionString = connectionString;
            this.logger = logger;
        }

        public string ConnectionString => connectionString;

        public ILogger Logger => logger;
    }
}
