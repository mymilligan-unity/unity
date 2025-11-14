using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Specification.Constructor.Injection
{
    public abstract partial class SpecificationTests
    {
        [TestMethod]
        public virtual void NoDefaultConstructor()
        {
            // Arrange
            Container.RegisterType<ClassWithTreeConstructors>(Invoke.Constructor());

            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<ClassWithTreeConstructors>());
        }

        [TestMethod]
        public virtual void NoBogusConstructor()
        {
            // Arrange
            Container.RegisterType<ClassWithTreeConstructors>(
                Invoke.Constructor(typeof(int), typeof(string)));

            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<ClassWithTreeConstructors>());
        }

        [TestMethod]
        public virtual void NoBogusValuesConstructor()
        {
            // Arrange
            Container.RegisterType<ClassWithTreeConstructors>(
                Invoke.Constructor( 1, "test"));

            // Act
            Assert.Throws<ResolutionFailedException>(() => Container.Resolve<ClassWithTreeConstructors>());
        }

        [TestMethod]
        public void SelectByValueTypes()
        {
            Container.RegisterType<TypeWithMultipleCtors>(Invoke.Constructor(Inject.Parameter(typeof(string)),
                Inject.Parameter(typeof(string)),
                Inject.Parameter(typeof(int))));
            Assert.AreEqual(TypeWithMultipleCtors.Three, Container.Resolve<TypeWithMultipleCtors>().Signature);
        }

        public class ClassWithTreeConstructors
        {
            protected ClassWithTreeConstructors()
            {
                
            }

            public ClassWithTreeConstructors(IUnityContainer container)
            {
                Value = container;
            }

            public ClassWithTreeConstructors(string name)
            {
                Value = name;
            }

            public ClassWithTreeConstructors(object value)
            {
                Value = value;
            }

            public object Value { get; }
        }
    }
}
