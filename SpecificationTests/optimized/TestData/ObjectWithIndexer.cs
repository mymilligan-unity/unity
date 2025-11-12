
namespace Unity.Specification.TestData
{
    public class ObjectWithIndexer
    {
        [Dependency]
        public object this[int index]
        {
            get => null;
            set { }
        }

        public bool Validate()
        {
            return true;
        }
    }
}
