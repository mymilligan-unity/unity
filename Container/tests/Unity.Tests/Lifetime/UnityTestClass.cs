namespace Unity.Tests.v5.Lifetime
{
    public class UnityTestClass
    {
        private string name = "Hello";

        public string Name
        {
            get => name;
            set => name = value;
        }
    }
}