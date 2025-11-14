using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unity.Specification.Diagnostic.BuildUp
{
    public abstract partial class SpecificationTests
    {

        [TestMethod]
        public void BuildBaseAndChildObject3()
        {
            BaseStub1 objBase = new BaseStub1();

            Assert.IsNotNull(objBase);
            Assert.IsNull(objBase.BaseProp);

            Container.BuildUp(typeof(BaseStub1), objBase);
            Assert.IsNotNull(objBase.BaseProp);

            // "type of the object should match"
            Assert.Throws<ArgumentException>(() => Container.BuildUp(typeof(ChildStub1), objBase));
        }

        [TestMethod]
        public void BuildUnmatchedObject2()
        {
            BuildUnmatchedObject2__PropertyDependencyClassStub2 obj2 = new BuildUnmatchedObject2__PropertyDependencyClassStub2();

            Assert.IsNotNull(obj2);
            Assert.IsNull(obj2.MyFirstObj);
            Assert.IsNull(obj2.MySecondObj);

            // "type of the object should match"
            Assert.Throws<ArgumentException>(() => Container.BuildUp(typeof(BuildUnmatchedObject2_PropertyDependencyClassStub1), obj2));
        }
    }
}
