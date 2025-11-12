using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Constructor.Overrides
{
    public abstract partial class SpecificationTests : TestFixtureBase
    {
        private string _data = "data";
        private string _override = "override";

        [TestInitialize]
        public override void Setup() => base.Setup();
    }

    public class Service
    {
        public Service(string data)
        {
            Data = data;
        }

        public string Data { get; }
    }

    public class CtorWithDependency
    {
        public CtorWithDependency([Dependency]string data)
        {
            Data = data;
        }

        public string Data { get; }
    }

    public class CtorWithNamedDependency
    {
        public CtorWithNamedDependency([Dependency("name")]string data)
        {
            Data = data;
        }

        public string Data { get; }
    }

    public class CtorWithOptionalDependency
    {
        public CtorWithOptionalDependency([OptionalDependency]string data = null)
        {
            Data = data;
        }

        public string Data { get; }
    }

    public class CtorWithOptionalNamedDependency
    {
        public CtorWithOptionalNamedDependency([OptionalDependency("name")]string data = null)
        {
            Data = data;
        }

        public string Data { get; }
    }
}
