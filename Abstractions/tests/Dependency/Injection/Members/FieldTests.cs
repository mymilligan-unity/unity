using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Unity.Injection;

namespace Injection.Members
{
    [TestClass]
    public class FieldTests : InjectionInfoBaseTests<FieldInfo>
    {
        protected override InjectionMember<FieldInfo, object> GetDefaultMember() => 
            new InjectionField("TestField");
    }
}
