
namespace Unity.Tests.v5.ContainerRegistration
{
    internal class AnotherTypeImplementation : ITypeAnotherInterface
    {
        private readonly string name;

        public AnotherTypeImplementation()
        {
        }

        public AnotherTypeImplementation(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }
}
