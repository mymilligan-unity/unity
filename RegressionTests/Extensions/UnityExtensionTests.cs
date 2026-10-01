using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Regression.Tests;
#if NET45
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Container.Extending
{
    [TestClass]
    public class UnityExtensionTests
    {
        UnityContainer            container;
        MockContainerExtension    mock;
        OtherContainerExtension   other;
        DerivedContainerExtension derived;

        [TestInitialize]
        public void TestInitialize()
        {
            container = new UnityContainer();
            mock      = new MockContainerExtension();
            other     = new OtherContainerExtension();
            derived   = new DerivedContainerExtension();
        }

        [TestMethod]
        public void AddExtensionTest()
        {
            // Act
            container.AddExtension(mock)
                     .AddExtension(other)
                     .AddExtension(derived);

            // Validate
            Assert.IsTrue(mock.InitializeWasCalled);
            Assert.IsTrue(other.InitializeWasCalled);
            Assert.IsTrue(derived.InitializeWasCalled);
        }

        [TestMethod]
        public void ConfigureTest()
        {
            // Act
            container.AddExtension(mock)
                     .AddExtension(other)
                     .AddExtension(derived);

            // Validate
            Assert.AreSame(derived, container.Configure(typeof(DerivedContainerExtension)));
            Assert.AreSame(other, container.Configure(typeof(OtherContainerExtension)));
            Assert.AreSame(mock, container.Configure(typeof(MockContainerExtension)));
        }

        [TestMethod]
        public void ConfigureGenericTest()
        {
            // Act
            container.AddExtension(mock)
                     .AddExtension(other)
                     .AddExtension(derived);

            // Validate
            Assert.AreSame(derived, container.Configure<DerivedContainerExtension>());
            Assert.AreSame(other,   container.Configure<OtherContainerExtension>());
            Assert.AreSame(mock,    container.Configure<MockContainerExtension>());
        }

        [TestMethod]
        public void AddExtensionGenericTest()
        {
            // Act
            container.AddNewExtension<MockContainerExtension>()
                     .AddNewExtension<OtherContainerExtension>()
                     .AddNewExtension<DerivedContainerExtension>();

            // Validate
            Assert.IsTrue(container.Configure<MockContainerExtension>().InitializeWasCalled);
            Assert.IsTrue(container.Configure<OtherContainerExtension>().InitializeWasCalled);
            Assert.IsTrue(container.Configure<DerivedContainerExtension>().InitializeWasCalled);
        }
    }
}
