using System.Linq;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;

namespace NCrafts.App.Core.Common.Infrastructure.Fx
{
    public static class UnityContainerExtensions
    {
        public static IUnityContainer RegisterClosures<T>(this IUnityContainer container)
        {
            typeof(T).GetRuntimeMethods().Where(x => x.IsStatic).ToList()
                .ForEach(closure =>
                {
                    var dependencies = closure.GetParameters().Select(x => container.Resolve(x.ParameterType)).ToArray();
                    var instance = closure.Invoke(null, dependencies);
                    container.RegisterInstance(closure.ReturnType, instance);
                });
            return container;
        }
    }
}