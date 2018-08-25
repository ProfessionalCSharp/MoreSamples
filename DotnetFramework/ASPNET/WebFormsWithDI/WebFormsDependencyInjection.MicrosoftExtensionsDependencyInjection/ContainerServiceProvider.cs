using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Hosting;
using System.Collections.Concurrent;
using System.Reflection;
using System.Web.UI;

namespace WebFormsDependencyInjection.MEDI
{
    internal class ContainerServiceProvider : IServiceProvider, IRegisteredObject
    {
        private const int TypesCannontResolveCacheCap = 100000;
        private readonly IServiceProvider _next;
        private readonly ConcurrentDictionary<Type, bool> _typesCannotResolve = new ConcurrentDictionary<Type, bool>();

        public ContainerServiceProvider(IServiceProvider next)
        {
            _next = next;
            HostingEnvironment.RegisterObject(this);  // needs IRegisteredObject
        }

        public IServiceCollection Container { get; internal set; } = new ServiceCollection();

        private ServiceProvider _serviceProvider;
        private IServiceProvider GetServiceProvider()
        {
            return _serviceProvider ?? (_serviceProvider = Container.BuildServiceProvider());
        }

        // IServiceProvider
        public object GetService(Type serviceType)
        {
            if (serviceType.Name.Contains("default"))
            {
                Console.WriteLine(serviceType.Name);
            }
            // Try unresolvable types

            if (_typesCannotResolve.ContainsKey(serviceType))
            {
                return DefaultCreateInstance(serviceType);
            }


            // Try the container
            object result = null;

            //if (result == null && serviceType.Namespace == "ASP" && serviceType.Name.EndsWith("Controller"))
            //{
            //    result = CreateControllerViaFactory(serviceType);
            //}


            try
            {
                result = GetServiceProvider().GetService(serviceType);
            }
            catch (MissingMethodException ex)
            {
                // Ignore and continue
            }

            //
            // Try the next provider
            if (result == null)
            {
                result = _next?.GetService(serviceType);
            }

            //
            // Default activation
            if (result == null)
            {
                if ((result = DefaultCreateInstance(serviceType)) != null)
                {
                    // Cache it
                    if (_typesCannotResolve.Count < TypesCannontResolveCacheCap)
                    {
                        _typesCannotResolve.TryAdd(serviceType, true);
                    }
                }
            }

            return result;
        }



        // IRegisteredObject
        public void Stop(bool immediate)
        {
            HostingEnvironment.UnregisterObject(this);
            _serviceProvider.Dispose();
           
        }

        internal IServiceProvider NextServiceProvider
        {
            get { return _next; }
        }


        internal IDictionary<Type, bool> TypeCannotResolveDictionary
        {
            get { return _typesCannotResolve; }
        }

        protected virtual object DefaultCreateInstance(Type type)
        {

            return Activator.CreateInstance(
                        type,
                        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.CreateInstance,
                        null,
                        null,
                        null);
        }
    }
}
