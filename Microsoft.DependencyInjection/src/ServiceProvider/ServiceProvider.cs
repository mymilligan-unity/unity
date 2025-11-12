using Microsoft.Extensions.DependencyInjection;
using System;
using Unity.Exceptions;
using Unity.Lifetime;
using Unity.Microsoft.DependencyInjection.Lifetime;

namespace Unity.Microsoft.DependencyInjection
{
    public class ServiceProvider : IServiceProvider, 
                                   ISupportRequiredService,
                                   IServiceScopeFactory, 
                                   IServiceScope,
                                   IServiceProviderIsService,
                                   IKeyedServiceProvider,
                                   IServiceProviderIsKeyedService,
                                   IDisposable
    {
        private IUnityContainer _container;

#if DEBUG
        private string id = Guid.NewGuid().ToString();
#endif


        internal ServiceProvider(IUnityContainer container)
        {
            _container = container;
            _container.RegisterInstance<IServiceScope>(this, new ExternallyControlledLifetimeManager());
            _container.RegisterInstance<IServiceProvider>(this, new ServiceProviderLifetimeManager(this));
            _container.RegisterInstance<IServiceScopeFactory>(this, new ExternallyControlledLifetimeManager());
            _container.RegisterInstance<IServiceProviderIsService>(this, new ServiceProviderLifetimeManager(this));
            _container.RegisterInstance<IKeyedServiceProvider>(this, new ServiceProviderLifetimeManager(this));
        }

        public object GetService(Type serviceType)
        {
            if (null == _container) 
                throw new ObjectDisposedException(nameof(IServiceProvider));

            try
            {
                return _container.Resolve(serviceType, null);
            }
            catch  { /* Ignore */}

            return null;
        }

        public object GetRequiredService(Type serviceType)
        {
            if (null == _container) 
                throw new ObjectDisposedException(nameof(IServiceProvider));

            return _container.Resolve(serviceType, null);
        }


        public IServiceScope CreateScope()
        {
            return new ServiceProvider(_container.CreateChildContainer());
        }


        IServiceProvider IServiceScope.ServiceProvider => this;


        public static IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return new ServiceProvider(new UnityContainer()
                .AddExtension(new MdiExtension())
                .AddServices(services));
        }

        public static explicit operator UnityContainer(ServiceProvider c)
        {
            return (UnityContainer)c._container;
        }


        protected virtual void Dispose(bool disposing)
        {
            IDisposable disposable = _container;
            _container = null;
            disposable?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool IsService(Type serviceType)
        {
            return _container.IsRegistered(serviceType);
        }

        public bool IsKeyedService(Type serviceType, object serviceKey)
        {
            return _container.IsRegistered(serviceType, serviceKey?.ToString() ?? string.Empty);
        }

        public object GetKeyedService(Type serviceType, object serviceKey)
        {
            return _container.Resolve(serviceType, serviceKey?.ToString() ?? string.Empty);
        }

        public object GetRequiredKeyedService(Type serviceType, object serviceKey)
        {
            return _container.Resolve(serviceType, serviceKey?.ToString() ?? string.Empty) ?? throw new InvalidRegistrationException();
        }
    }
}
