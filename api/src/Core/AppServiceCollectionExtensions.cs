using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class AppServiceCollectionExtensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        Assembly assembly = typeof(AppServiceCollectionExtensions).Assembly;

        assembly.GetTypes()
            .Where(type => type.Name.EndsWith("Service") && !type.IsAbstract && !type.IsInterface)
            .ToList()
            .ForEach(type =>
            {
                Type[] interfaces = type.GetInterfaces();
                if (interfaces.Length > 0)
                {
                    Type serviceInterface = interfaces.First(i => i.Name.EndsWith(type.Name));
                    services.AddScoped(serviceInterface, type);
                }
            });
    }
}
