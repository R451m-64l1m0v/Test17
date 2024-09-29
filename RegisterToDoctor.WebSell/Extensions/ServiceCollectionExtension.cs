using System.ComponentModel;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using RegisterToDoctor.WebSell.Attributes;
using RegisterToDoctor.WebSell.Interfaces.Markers;
using RegisterToDoctor.WebSell.Validators;
using RegisterToDoctor.WebSell.Validators.DoctorValidators;

namespace RegisterToDoctor.WebSell.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAttributedServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var serviceTypes = assembly.GetTypes()
                .Where(t => typeof(IServiceMarker).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
            
            foreach (var type in serviceTypes)
            {
                var interfaces = type.GetInterfaces()
                    .Where(i => i != typeof(IServiceMarker));

                var interfaceType = type.GetInterfaces().FirstOrDefault();

                if (interfaces.Contains(typeof(ISingletonServiceMarker)))
                {
                    if (interfaceType != null)
                    {
                        services.AddSingleton(interfaceType, type);
                    }
                }

                if (interfaces.Contains(typeof(ITransientServiceMarker)))
                {
                    if (interfaceType != null)
                    {
                        services.AddTransient(interfaceType, type);
                    }
                }

                if (interfaces.Contains(typeof(IScopedServiceMarker)))
                {
                    if (interfaceType != null)
                    {
                        services.AddScoped(interfaceType, type);
                    }
                }
            }

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.DisableDataAnnotationsValidation = true;
                });

            return services;
        }
    }
}
