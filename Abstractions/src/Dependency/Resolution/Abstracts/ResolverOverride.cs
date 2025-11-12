using System;

namespace Unity.Resolution
{
    /// <summary>
    /// Base class for all override objects passed in the
    /// <see cref="IUnityContainer.Resolve"/> method.
    /// </summary>
    public abstract class ResolverOverride
    {
        protected Type Target;
        protected readonly Type   Type;
        protected readonly string Name;


        protected ResolverOverride(string name)
        {
            Name = name;
        }

        protected ResolverOverride(Type target, Type type, string name)
        {
            Target = target;
            Type = type;
            Name = name;
        }


        /// <summary>
        /// Wrap this resolver in one that verifies the type of the object being built.
        /// This allows you to narrow any override down to a specific type easily.
        /// </summary>
        /// <typeparam name="T">Type to constrain the override to.</typeparam>
        /// <returns>The new override.</returns>
        public ResolverOverride OnType<T>()
        {
            Target = typeof(T);
            return this;
        }

        /// <summary>
        /// Wrap this resolver in one that verifies the type of the object being built.
        /// This allows you to narrow any override down to a specific type easily.
        /// </summary>
        /// <param name="targetType">Type to constrain the override to.</param>
        /// <returns>The new override.</returns>
        public ResolverOverride OnType(Type targetType)
        {
            Target = targetType;
            return this;
        }


        public virtual ResolveDelegate<TContext> GetResolver<TContext>(Type type)
            where TContext : IResolveContext
        {
            return this is IResolve policy
                ? (ResolveDelegate<TContext>)policy.Resolve
                : throw new InvalidCastException("Derived type does not implement IResolve policy");
        }


        public override int GetHashCode()
        {
            return ((Target?.GetHashCode() ?? 0 * 37) + (Name?.GetHashCode() ?? 0 * 17)) ^  GetType().GetHashCode();

        }

        public override bool Equals(object obj)
        {
            return this == obj as ResolverOverride;
        }

        public static bool operator ==(ResolverOverride left, ResolverOverride right)
        {
            return left?.GetHashCode() == right?.GetHashCode();
        }

        public static bool operator !=(ResolverOverride left, ResolverOverride right)
        {
            return !(left == right);
        }
    }
}
