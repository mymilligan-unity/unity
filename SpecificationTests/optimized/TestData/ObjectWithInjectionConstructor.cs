
namespace Unity.Specification.TestData
{
    public class ObjectWithInjectionConstructor
    {
        public ObjectWithInjectionConstructor(object constructorDependency)
        {
            ConstructorDependency = constructorDependency;
        }

        [InjectionConstructor]
        public ObjectWithInjectionConstructor(string s)
        {
            ConstructorDependency = s;
        }

        public object ConstructorDependency { get; }
    }
}
