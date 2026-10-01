using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Diagnostic.BuildUp
{
    public abstract partial class SpecificationTests : TestFixtureBase
    {
        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }
    }

    public interface Interface1
    {
        [Dependency]
        object InterfaceProp
        {
            get;
            set;
        }
    }

    public class BaseStub1 : Interface1
    {
        private object baseProp;
        private object interfaceProp;

        [Dependency]
        public object BaseProp
        {
            get => baseProp;
            set => baseProp = value;
        }

        public object InterfaceProp
        {
            get => interfaceProp;
            set => interfaceProp = value;
        }
    }

    public class ChildStub1 : BaseStub1
    {
        private object childProp;

        [Dependency]
        public object ChildProp
        {
            get => childProp;
            set => childProp = value;
        }
    }

    public class BuildUnmatchedObject2_PropertyDependencyClassStub1
    {
        private object myFirstObj;

        [Dependency]
        public object MyFirstObj
        {
            get => myFirstObj;
            set => myFirstObj = value;
        }
    }

    public class BuildUnmatchedObject2__PropertyDependencyClassStub2
    {
        private object myFirstObj;
        private object mySecondObj;

        [Dependency]
        public object MyFirstObj
        {
            get => myFirstObj;
            set => myFirstObj = value;
        }

        [Dependency]
        public object MySecondObj
        {
            get => mySecondObj;
            set => mySecondObj = value;
        }
    }
}
