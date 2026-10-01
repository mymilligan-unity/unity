using Microsoft.VisualStudio.TestTools.UnitTesting;
#if NET45
using  Microsoft.Practices.Unity;
#else
#endif


namespace Unity.Regression.Tests
{
    [TestClass]
    public class BaselineFixture
    {
        [TestMethod]
        public void BaselineTest()
        {
            var container = new UnityContainer();
        
        }
    }
}
