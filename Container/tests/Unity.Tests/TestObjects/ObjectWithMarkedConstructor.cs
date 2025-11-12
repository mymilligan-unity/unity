
namespace Unity.Tests.v5.TestObjects
{
    internal class ObjectWithMarkedConstructor
    {
        public ObjectWithMarkedConstructor(int notTheInjectionConstructor)
        {
        }

        [InjectionConstructor]
        public ObjectWithMarkedConstructor(string theInjectionConstructor)
        {
        }
    }
}
