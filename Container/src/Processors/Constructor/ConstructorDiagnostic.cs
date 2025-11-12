using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Unity.Builder;
using Unity.Lifetime;
using Unity.Exceptions;
using Unity.Policy;
using Unity.Resolution;
using Unity.Registration;
using Unity.Injection;

namespace Unity.Processors
{
    public class ConstructorDiagnostic : ConstructorProcessor
    {
        const string CannotConstructAbstractClass = "The current type, {0}, is an abstract class and cannot be constructed. Are you missing a type mapping?";
        const string CannotConstructDelegate = "The current type, {0}, is delegate and cannot be constructed. Unity only supports resolving Func&lt;T&gt; and Func&lt;IEnumerable&lt;T&gt;&gt; by default.";
        const string CannotConstructInterface = "The current type, {0}, is an interface and cannot be constructed. Are you missing a type mapping?";
        const string TypeIsNotConstructable = "The type {0} cannot be constructed. You must configure the container to supply this value.";

        private static readonly Expression[] CannotConstructInterfaceExpr =
        [
            Expression.IfThen(Expression.Equal(Expression.Constant(null), BuilderContextExpression.Existing),
                 Expression.Throw(
                    Expression.New(InvalidOperationExceptionCtor,
                        Expression.Call(
                            StringFormat,
                            Expression.Constant(CannotConstructInterface),
                            BuilderContextExpression.Type),
                        InvalidRegistrationExpression)))
        ];

        private static readonly Expression[] CannotConstructAbstractClassExpr =
        [
            Expression.IfThen(Expression.Equal(Expression.Constant(null), BuilderContextExpression.Existing),
                 Expression.Throw(
                    Expression.New(InvalidOperationExceptionCtor,
                        Expression.Call(
                            StringFormat,
                            Expression.Constant(CannotConstructAbstractClass),
                            BuilderContextExpression.Type),
                        InvalidRegistrationExpression)))
        ];

        private static readonly Expression[] CannotConstructDelegateExpr =
        [
            Expression.IfThen(Expression.Equal(Expression.Constant(null), BuilderContextExpression.Existing),
                 Expression.Throw(
                    Expression.New(InvalidOperationExceptionCtor,
                        Expression.Call(
                            StringFormat,
                            Expression.Constant(CannotConstructDelegate),
                            BuilderContextExpression.Type),
                        InvalidRegistrationExpression)))
        ];

        private static readonly Expression[] TypeIsNotConstructableExpr =
        [
            Expression.IfThen(Expression.Equal(Expression.Constant(null), BuilderContextExpression.Existing),
                 Expression.Throw(
                    Expression.New(InvalidOperationExceptionCtor,
                        Expression.Call(
                            StringFormat,
                            Expression.Constant(TypeIsNotConstructable),
                            BuilderContextExpression.Type),
                        InvalidRegistrationExpression)))
        ];


        public ConstructorDiagnostic(IPolicySet policySet, UnityContainer container) 
            : base(policySet, container)
        {
        }


        public override IEnumerable<object> Select(Type type, IPolicySet registration)
        {
            var members = new List<InjectionMember>();

            // Select Injected Members
            if (null != ((InternalRegistration)registration).InjectionMembers)
            {
                foreach (var injectionMember in ((InternalRegistration)registration).InjectionMembers)
                {
                    if (injectionMember is InjectionMember<ConstructorInfo, object[]>)
                    {
                        members.Add(injectionMember);
                    }
                }
            }

            switch (members.Count)
            {
                case 1:
                    return members.ToArray();

                case 0:
                    break;

                default:
                    return
                    [
                        new InvalidOperationException($"Multiple Injection Constructors are registered for Type {type.FullName}", 
                        new InvalidRegistrationException())
                    ];
            }

            // Enumerate to array
            var constructors = DeclaredMembers(type).ToArray();
            if (1 >= constructors.Length)
                return constructors;

            var selection = new HashSet<ConstructorInfo>();

            // Select Attributed constructors
            foreach (var constructor in constructors)
            {
                for (var i = 0; i < AttributeFactories.Length; i++)
                {
                    if (!constructor.IsDefined(AttributeFactories[i].Type))
                        continue;

                    selection.Add(constructor);
                }
            }

            switch (selection.Count)
            {
                case 1:
                    return selection.ToArray();

                case 0:
                    break;

                default:
                    return
                    [
                        new InvalidOperationException($"Multiple Constructors are annotated for injection on Type {type.FullName}", 
                        new InvalidRegistrationException())
                    ];
            }

            // Select default
            return [SelectMethod(type, constructors)];
        }

        protected override object SmartSelector(Type type, ConstructorInfo[] constructors)
        {
            Array.Sort(constructors, (a, b) =>
            {
                var qtd = b.GetParameters().Length.CompareTo(a.GetParameters().Length);

                if (qtd == 0)
                {
                    return b.GetParameters().Sum(p => p.ParameterType.IsInterface ? 1 : 0)
                        .CompareTo(
                            a.GetParameters().Sum(p => p.ParameterType.IsInterface ? 1 : 0));
                }
                return qtd;
            });

            int parametersCount = 0;
            ConstructorInfo bestCtor = null;

            foreach (var ctorInfo in constructors)
            {
                var parameters = ctorInfo.GetParameters();

                if (bestCtor != null && parametersCount > parameters.Length) return bestCtor;
                parametersCount = parameters.Length;


                if (parameters.All(p => p.HasDefaultValue || CanResolve(p)))
                {
                    if (bestCtor == null)
                    {
                        bestCtor = ctorInfo;
                    }
                    else
                    {
                        return bestCtor;
                        /*var message = $"Ambiguous constructor: Failed to choose between {type.Name}{Regex.Match(bestCtor.ToString()!, @"\((.*?)\)")} and {type.Name}{Regex.Match(ctorInfo.ToString()!, @"\((.*?)\)")}";
                        return new InvalidOperationException(message, new InvalidRegistrationException());*/
                    }
                }
            }

            if (bestCtor == null)
            {
                return new InvalidOperationException($"Failed to select a constructor for {type.FullName}", new InvalidRegistrationException());
            }

            return bestCtor;
        }


        public override IEnumerable<Expression> GetExpressions(Type type, IPolicySet registration)
        {
            var typeInfo = type;
            // Validate if Type could be created
            if (typeInfo.IsInterface) return CannotConstructInterfaceExpr;

            if (typeInfo.IsAbstract) return CannotConstructAbstractClassExpr;

            if (typeInfo.IsSubclassOf(typeof(Delegate))) return CannotConstructDelegateExpr;

            if (type == typeof(string)) return TypeIsNotConstructableExpr;

            // Build expression as usual
            return base.GetExpressions(type, registration);
        }

        protected override Expression GetResolverExpression(ConstructorInfo info, object resolvers)
        {
            var ex = Expression.Variable(typeof(Exception));
            var exData = Expression.MakeMemberAccess(ex, DataProperty);
            var variable = Expression.Variable(info.DeclaringType ?? throw new ArgumentNullException(nameof(info)));
            var parameters = info.GetParameters();

            // Check if has Out or ByRef parameters
            var tryBlock = parameters.Any(pi => pi.ParameterType.IsByRef)
                
                // Report error
                ? (Expression)Expression.Throw(Expression.New(InvalidOperationExceptionCtor,
                        Expression.Constant(CreateErrorMessage(Error.SelectedConstructorHasRefParameters, info.DeclaringType, info)),
                        InvalidRegistrationExpression))
                
                // Create new instance
                : Expression.Block(
                    [variable], 
                    Expression.Assign(variable, Expression.New(info, CreateDiagnosticParameterExpressions(info.GetParameters(), resolvers))), 
                    Expression.Assign(BuilderContextExpression.Existing, Expression.Convert(variable, typeof(object))));

            // Add location to dictionary and re-throw
            var catchBlock = Expression.Block(tryBlock.Type,
                Expression.Call(exData, AddMethod,
                        Expression.Convert(NewGuid, typeof(object)),
                        Expression.Constant(info, typeof(object))),
                Expression.Rethrow(tryBlock.Type));

            // Create 
            return Expression.IfThen(Expression.Equal(Expression.Constant(null), BuilderContextExpression.Existing),
                                     Expression.TryCatch(tryBlock, Expression.Catch(ex, catchBlock)));
            // Report error
            string CreateErrorMessage(string format, Type type, MethodBase constructor)
            {
                var parameterDescriptions =
                    constructor.GetParameters()
                        .Select(parameter => $"{parameter.ParameterType.FullName} {parameter.Name}");

                return string.Format(format, type.FullName, string.Join(", ", parameterDescriptions));
            }
        }


        public override ResolveDelegate<BuilderContext> GetResolver(Type type, IPolicySet registration, ResolveDelegate<BuilderContext> seed)
        {
            var typeInfo = type;
            // Validate if Type could be created
            if (typeInfo.IsInterface)
            {
                return (ref BuilderContext c) =>
                {
                    if (null == c.Existing)
                        throw new InvalidOperationException(string.Format(CannotConstructInterface, c.Type),
                            new InvalidRegistrationException());

                    return c.Existing;
                };
            }

            if (typeInfo.IsAbstract)
            {
                return (ref BuilderContext c) =>
                {
                    if (null == c.Existing)
                        throw new InvalidOperationException(string.Format(CannotConstructAbstractClass, c.Type),
                            new InvalidRegistrationException());

                    return c.Existing;
                };
            }

            if (typeInfo.IsSubclassOf(typeof(Delegate)))
            {
                return (ref BuilderContext c) =>
                {
                    if (null == c.Existing)
                        throw new InvalidOperationException(string.Format(CannotConstructDelegate, c.Type),
                            new InvalidRegistrationException());

                    return c.Existing;
                };
            }

            if (type == typeof(string))
            {
                return (ref BuilderContext c) =>
                {
                    if (null == c.Existing)
                        throw new InvalidOperationException(string.Format(TypeIsNotConstructable, c.Type),
                            new InvalidRegistrationException());

                    return c.Existing;
                };
            }


            return base.GetResolver(type, registration, seed);
        }

        protected override ResolveDelegate<BuilderContext> GetResolverDelegate(ConstructorInfo info, object resolvers)
        {
            var parameterResolvers = CreateDiagnosticParameterResolvers(info.GetParameters(), resolvers).ToArray();

            return (ref BuilderContext c) =>
            {
                if (null == c.Existing)
                {
                    try
                    {
                        var dependencies = new object[parameterResolvers.Length];
                        for (var i = 0; i < dependencies.Length; i++)
                            dependencies[i] = parameterResolvers[i](ref c);

                        c.Existing = info.Invoke(dependencies);
                    }
                    catch (Exception ex)
                    {
                        ex.Data.Add(Guid.NewGuid(), info);
                        throw;
                    }
                }

                return c.Existing;
            };
        }

        protected override ResolveDelegate<BuilderContext> GetPerResolveDelegate(ConstructorInfo info, object resolvers)
        {
            var parameterResolvers = CreateDiagnosticParameterResolvers(info.GetParameters(), resolvers).ToArray();
            // PerResolve lifetime
            return (ref BuilderContext c) =>
            {
                if (null == c.Existing)
                {
                    try
                    {
                        var dependencies = new object[parameterResolvers.Length];
                        for (var i = 0; i < dependencies.Length; i++)
                            dependencies[i] = parameterResolvers[i](ref c);

                        c.Existing = info.Invoke(dependencies);
                    }
                    catch (Exception ex)
                    {
                        ex.Data.Add(Guid.NewGuid(), info);
                        throw;
                    }

                    c.Set(typeof(LifetimeManager),
                          new InternalPerResolveLifetimeManager(c.Existing));
                }

                return c.Existing;
            };
        }
    }
}
