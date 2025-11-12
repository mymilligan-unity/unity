namespace Unity.Tests.v5.ContainerRegistration
{
    internal class TypeImplementation : ITypeInterface
    {
        private string name;

        public TypeImplementation()
        {
        }

        public TypeImplementation(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }
}
