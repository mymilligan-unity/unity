namespace Unity.Tests.v5.CollectionSupport
{
    public class ConfigurationTestClassGeneric<T>
    {
        private T[] arrayProperty;
        public T[] ArrayProperty
        {
            get => arrayProperty;
            set => arrayProperty = value;
        }

        private T[] arrayMethod;
        public T[] ArrayMethod
        {
            get => arrayMethod;
            set => arrayMethod = value;
        }

        private T[] arrayCtor;
        public T[] ArrayCtor
        {
            get => arrayCtor;
            set => arrayCtor = value;
        }

        public void InjectionMethod(T[] arrayMethod)
        {
            ArrayMethod = arrayMethod;
        }

        [InjectionConstructor]
        public ConfigurationTestClassGeneric()
        { }

        public ConfigurationTestClassGeneric(T[] arrayCtor)
        {
            ArrayCtor = arrayCtor;
        }
    }
}