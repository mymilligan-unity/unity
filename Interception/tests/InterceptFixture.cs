

using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Interception;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.Interceptors;
using Unity.Interception.Interceptors.InstanceInterceptors;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.Interceptors.TypeInterceptors;
using Unity.Interception.Interceptors.TypeInterceptors.VirtualMethodInterception;

namespace Microsoft.Practices.Unity.InterceptionExtension.Tests
{
    [TestClass]
    public class InterceptFixture
    {
        [TestMethod]
        public void CanInterceptTargetWithInstanceInterceptor()
        {
            bool invoked = false;
            IInterceptionBehavior interceptionBehavior =
                new DelegateInterceptionBehavior((mi, next) => { invoked = true; return mi.CreateMethodReturn(100); });

            IInterface proxy = (IInterface)
                Intercept.ThroughProxyWithAdditionalInterfaces(
                    typeof(IInterface),
                    new BaseClass(10),
                    new InterfaceInterceptor(),
                    new[] { interceptionBehavior },
                    Type.EmptyTypes);

            int value = proxy.DoSomething();

            Assert.AreEqual(100, value);
            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void GeneratedProxyImplementsUserProvidedAdditionalInterfaces()
        {
            bool invoked = false;
            IInterceptionBehavior interceptionBehavior =
                new DelegateInterceptionBehavior((mi, next) => { invoked = true; return mi.CreateMethodReturn(100); });

            IInterface proxy = (IInterface)
                Intercept.ThroughProxyWithAdditionalInterfaces(
                    typeof(IInterface),
                    new BaseClass(10),
                    new InterfaceInterceptor(),
                    new[] { interceptionBehavior },
                    new[] { typeof(ISomeInterface) });

            int value = ((ISomeInterface)proxy).DoSomethingElse();

            Assert.AreEqual(100, value);
            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void GeneratedProxyImplementsInterceptionBehaviorProvidedAdditionalInterfaces()
        {
            bool invoked = false;
            IInterceptionBehavior interceptionBehavior =
                new DelegateInterceptionBehavior(
                    (mi, next) => { invoked = true; return mi.CreateMethodReturn(100); },
                    () => new[] { typeof(ISomeInterface) });

            IInterface proxy = (IInterface)
                Intercept.ThroughProxyWithAdditionalInterfaces(
                    typeof(IInterface),
                    new BaseClass(10),
                    new InterfaceInterceptor(),
                    new[] { interceptionBehavior },
                    Type.EmptyTypes);

            int value = ((ISomeInterface)proxy).DoSomethingElse();

            Assert.AreEqual(100, value);
            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void CanInterceptTargetWithInstanceInterceptorUsingGenericVersion()
        {
            bool invoked = false;
            IInterceptionBehavior interceptionBehavior =
                new DelegateInterceptionBehavior((mi, next) => { invoked = true; return mi.CreateMethodReturn(100); });

            IInterface proxy =
                Intercept.ThroughProxyWithAdditionalInterfaces<IInterface>(
                    new BaseClass(10),
                    new InterfaceInterceptor(),
                    new[] { interceptionBehavior },
                    Type.EmptyTypes);

            int value = proxy.DoSomething();

            Assert.AreEqual(100, value);
            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void InterceptingANullTypeThrows()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
            {
                Intercept.ThroughProxyWithAdditionalInterfaces(
                    null,
                    new BaseClass(),
                    new InterfaceInterceptor(),
                    new IInterceptionBehavior[0],
                    Type.EmptyTypes);
            });
        }

        [TestMethod]
        public void InterceptingANullTargetThrows()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
            {
                Intercept.ThroughProxyWithAdditionalInterfaces(
                    typeof(IInterface),
                    null,
                    new InterfaceInterceptor(),
                    new IInterceptionBehavior[0],
                    Type.EmptyTypes);
            });
        }

        [TestMethod]
        public void InterceptingWithANullInterceptorThrows()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
            {
                Intercept.ThroughProxyWithAdditionalInterfaces(
                    typeof(IInterface),
                    new BaseClass(),
                    null,
                    new IInterceptionBehavior[0],
                    Type.EmptyTypes);
            });
        }

        [TestMethod]
        public void InterceptingTypesNotCompatibleWithTheInterceptorThrows()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
            {
                Intercept.ThroughProxyWithAdditionalInterfaces(
                    typeof(IInterface),
                    new BaseClass(),
                    new RejectingInterceptor(),
                    new IInterceptionBehavior[0],
                    Type.EmptyTypes);
            });
        }

        [TestMethod]
        public void InterceptingWithANullSetOfInterceptionBehaviorsThrows()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
            {
                Intercept.ThroughProxyWithAdditionalInterfaces(
                    typeof(IInterface),
                    new BaseClass(),
                    new InterfaceInterceptor(),
                    null,
                    Type.EmptyTypes);
            });
        }

        [TestMethod]
        public void InterceptingWithANullSetOfAdditionalInterfacesThrows()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
            {
                Intercept.ThroughProxyWithAdditionalInterfaces(
                    typeof(IInterface),
                    new BaseClass(),
                    new InterfaceInterceptor(),
                    new IInterceptionBehavior[0],
                    null);
            });
        }

        [TestMethod]
        public void InterceptingWithASetOfAdditionalInterfacesIncludingNonInterfaceTypeThrows()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
            {
                Intercept.ThroughProxyWithAdditionalInterfaces(
                    typeof(IInterface),
                    new BaseClass(),
                    new InterfaceInterceptor(),
                    new IInterceptionBehavior[0],
                    new[] { typeof(object) });
            });
        }

        [TestMethod]
        public void CanInterceptNewInstanceWithTypeInterceptor()
        {
            bool invoked = false;
            IInterceptionBehavior interceptionBehavior =
                new DelegateInterceptionBehavior((mi, next) => { invoked = true; return mi.CreateMethodReturn(100); });

            BaseClass instance = (BaseClass)
                Intercept.NewInstanceWithAdditionalInterfaces(
                    typeof(BaseClass),
                    new VirtualMethodInterceptor(),
                    new[] { interceptionBehavior },
                    Type.EmptyTypes,
                    10);

            int value = instance.DoSomething();

            Assert.AreEqual(100, value);
            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void CanInterceptNewInstanceWithTypeInterceptorUsingGenericVersion()
        {
            bool invoked = false;
            IInterceptionBehavior interceptionBehavior =
                new DelegateInterceptionBehavior((mi, next) => { invoked = true; return mi.CreateMethodReturn(100); });

            BaseClass instance =
                Intercept.NewInstanceWithAdditionalInterfaces<BaseClass>(
                    new VirtualMethodInterceptor(),
                    new[] { interceptionBehavior },
                    Type.EmptyTypes,
                    10);

            int value = instance.DoSomething();

            Assert.AreEqual(100, value);
            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void InterceptingNewInstanceOfANullTypeThrows()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
            {
                Intercept.NewInstance(
                    null,
                    new VirtualMethodInterceptor(),
                    new IInterceptionBehavior[0]);
            });
        }

        [TestMethod]
        public void InterceptingNewInstanceWithANullInterceptorThrows()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
            {
                Intercept.NewInstance(
                    typeof(BaseClass),
                    null,
                    new IInterceptionBehavior[0]);
            });
        }

        [TestMethod]
        public void InterceptingNewInstanceOfTypeNotCompatibleWithTheInterceptorThrows()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
            {
                Intercept.NewInstance(
                    typeof(BaseClass),
                    new RejectingInterceptor(),
                    new IInterceptionBehavior[0]);
            });
        }

        [TestMethod]
        public void InterceptingNewInstanceWithANullSetOfInterceptionBehaviorsThrows()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
            {
                Intercept.NewInstance(
                    typeof(BaseClass),
                    new VirtualMethodInterceptor(),
                    null);
            });
        }

        [TestMethod]
        public void InterceptingNewInstanceWithANullSetOfAdditionalInterfacesThrows()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
            {
                Intercept.NewInstanceWithAdditionalInterfaces(
                    typeof(BaseClass),
                    new VirtualMethodInterceptor(),
                    new IInterceptionBehavior[0],
                    null);
            });
        }

        [TestMethod]
        public void InterceptingNewInstanceWithASetOfAdditionalInterfacesWithNullElementsThrows()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
            {
                Intercept.NewInstanceWithAdditionalInterfaces(
                    typeof(BaseClass),
                    new VirtualMethodInterceptor(),
                    new IInterceptionBehavior[0],
                    new Type[] { null });
            });
        }

        [TestMethod]
        public void InterceptingNewInstanceWithASetOfAdditionalInterfacesWithNonInterfaceElementsThrows()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
            {
                Intercept.NewInstanceWithAdditionalInterfaces(
                    typeof(BaseClass),
                    new VirtualMethodInterceptor(),
                    new IInterceptionBehavior[0],
                    new Type[] { typeof(object) });
            });
        }

        [TestMethod]
        public void InterceptingNewInstanceWithASetOfAdditionalInterfacesWithGenericInterfaceElementsThrows()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
            {
                Intercept.NewInstanceWithAdditionalInterfaces(
                    typeof(BaseClass),
                    new VirtualMethodInterceptor(),
                    new IInterceptionBehavior[0],
                    new Type[] { typeof(IComparable<>) });
            });
        }

        [TestMethod]
        public void InterceptingNewInstanceWithASetOfBehaviorsWithNullElementsThrows()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
            {
                Intercept.NewInstance(
                    typeof(BaseClass),
                    new VirtualMethodInterceptor(),
                    new IInterceptionBehavior[] { null });
            });
        }

        [TestMethod]
        public void InterceptingNewInstanceWithASetOfBehaviorsWithElementReturningNullRequiredInterfacesThrows()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
            {
                Intercept.NewInstance(
                    typeof(BaseClass),
                    new VirtualMethodInterceptor(),
                    new IInterceptionBehavior[] 
                    {
                        new DelegateInterceptionBehavior(null, () => null)
                    });
            });
        }

        [TestMethod]
        public void InterceptingNewInstanceWithASetOfBehaviorsWithElementReturningRequiredInterfacesWithNullElementThrows()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
            {
                Intercept.NewInstance(
                    typeof(BaseClass),
                    new VirtualMethodInterceptor(),
                    new IInterceptionBehavior[] 
                    {
                        new DelegateInterceptionBehavior(null, () => new Type[] { null })
                    });
            });
        }

        [TestMethod]
        public void InterceptingNewInstanceWithASetOfBehaviorsWithElementReturningRequiredInterfacesWithNonInterfaceElementThrows()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
            {
                Intercept.NewInstance(
                    typeof(BaseClass),
                    new VirtualMethodInterceptor(),
                    new IInterceptionBehavior[] 
                    {
                        new DelegateInterceptionBehavior(null, () => new Type[] { typeof(object) })
                    });
            });
        }

        [TestMethod]
        public void InterceptingNewInstanceWithASetOfBehaviorsWithElementReturningRequiredInterfacesWithGenericInterfaceElementThrows()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
            {
                Intercept.NewInstance(
                    typeof(BaseClass),
                    new VirtualMethodInterceptor(),
                    new IInterceptionBehavior[] 
                    {
                        new DelegateInterceptionBehavior(null, () => new Type[] { typeof(IEnumerable<>) })
                    });
            });
        }

        [TestMethod]
        public void CanInterceptAbstractClassWithVirtualMethodInterceptor()
        {
            bool invoked = false;
            IInterceptionBehavior interceptionBehavior =
                new DelegateInterceptionBehavior((mi, next) => { invoked = true; return mi.CreateMethodReturn(100); });

            AbstractClass instance =
                Intercept.NewInstance<AbstractClass>(
                    new VirtualMethodInterceptor(),
                    new[] { interceptionBehavior });

            int value = instance.DoSomething();

            Assert.AreEqual(100, value);
            Assert.IsTrue(invoked);
        }

        public class BaseClass : IInterface
        {
            private readonly int value;

            public BaseClass()
                : this(0)
            { }

            public BaseClass(int value)
            {
                this.value = value;
            }

            public virtual int DoSomething()
            {
                return value;
            }
        }

        public interface IInterface
        {
            int DoSomething();
        }

        public interface ISomeInterface
        {
            int DoSomethingElse();
        }

        public class RejectingInterceptor : IInstanceInterceptor, ITypeInterceptor
        {
            public bool CanIntercept(Type t)
            {
                return false;
            }

            public IEnumerable<MethodImplementationInfo> GetInterceptableMethods(Type interceptedType, Type implementationType)
            {
                throw new NotImplementedException();
            }

            public IInterceptingProxy CreateProxy(Type t, object target, params Type[] additionalInterfaces)
            {
                throw new NotImplementedException();
            }

            public Type CreateProxyType(Type t, params Type[] additionalInterfaces)
            {
                throw new NotImplementedException();
            }
        }

        public abstract class AbstractClass
        {
            public abstract int DoSomething();
        }
    }
}
