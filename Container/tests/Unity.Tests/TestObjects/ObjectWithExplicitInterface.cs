using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Tests.v5.TestSupport;

namespace Unity.Tests.v5.TestObjects
{
    public interface ISomeCommonProperties
    {
        [Dependency]
        ILogger Logger { get; set; }

        [Dependency]
        object SyncObject { get; set; }
    }

    public class ObjectWithExplicitInterface : ISomeCommonProperties
    {
        private ILogger logger;
        private object syncObject;

        private object somethingElse;

        [Dependency]
        public object SomethingElse
        {
            get => somethingElse;
            set => somethingElse = value;
        }

        [Dependency]
        ILogger ISomeCommonProperties.Logger
        {
            get => logger;
            set => logger = value;
        }

        [Dependency]
        object ISomeCommonProperties.SyncObject
        {
            get => syncObject;
            set => syncObject = value;
        }

        public void ValidateInterface()
        {
            Assert.IsNotNull(logger);
            Assert.IsNotNull(syncObject);
        }
    }
}
