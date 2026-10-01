using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Unity.Injection;

namespace Injection.Members
{
    [TestClass]
    public class PropertyTests : InjectionInfoBaseTests<PropertyInfo>
    {
        protected override InjectionMember<PropertyInfo, object> GetDefaultMember() => 
            new InjectionProperty("TestProperty");
    }
}
