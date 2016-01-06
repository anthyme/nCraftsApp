using System;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;

namespace NCrafts.App.Business.Common.Infrastructure.Fx
{
    public static class UnityContainerExtensions
    {
        public static IUnityContainer RegisterClosures<T>(this IUnityContainer container, LifetimeManager lifetimeManager = null)
        {
            typeof(T).GetRuntimeMethods().Where(x => x.IsStatic).ToList()
                .ForEach(closure =>
                {
                    RegisterClosure(container, closure,
                        lifetimeManager == null
                            ? new TransientLifetimeManager()
                            : (LifetimeManager)Activator.CreateInstance(lifetimeManager.GetType()));
                });
            return container;
        }

        public static IUnityContainer RegisterClosure(this IUnityContainer container,
            MethodInfo closure, LifetimeManager lifetimeManager = null)
        {
            lifetimeManager = lifetimeManager ?? new TransientLifetimeManager();
            container.RegisterType(closure.ReturnType, lifetimeManager,
                new InjectionFactory(c => closure.Invoke(null,
                    closure.GetParameters().Select(x => container.Resolve(x.ParameterType)).ToArray())));
            return container;
        }
    }
}