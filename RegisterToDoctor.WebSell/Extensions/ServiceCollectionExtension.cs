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
            
            foreach (var serviceType in serviceTypes)
            {
                var interfaces = serviceType.GetInterfaces()
                    .Where(i => i != typeof(IServiceMarker));

                if (interfaces.Contains(typeof(ISingletonServiceMarker)))
                {
                    services.AddScoped(serviceType);
                }
                else if(interfaces.Contains(typeof(IScopedServiceMarker)))
                {
                    services.AddScoped(serviceType);
                }
                else if(interfaces.Contains(typeof(ITransientServiceMarker)))
                {
                    services.AddScoped(serviceType);
                }
            }          
            
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateDoctorValidator>();
            services.AddValidatorsFromAssemblyContaining<UserEntityValidator>();
            services.AddValidatorsFromAssemblyContaining<GuidValidator>();
            services.AddValidatorsFromAssemblyContaining<DoctorByFilterValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateDoctorValidator>();
            services.AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.DisableDataAnnotationsValidation = true;
                });

            return services;
        }
    }
}
