using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Unity.Injection;

namespace Injection.Members
{
    [TestClass]
    public class ConstructorTests : InjectionBaseTests<ConstructorInfo, object[]>
    {
        protected override InjectionMember<ConstructorInfo, object[]> GetDefaultMember() => 
            new InjectionConstructor();
    }
}
