using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using RegisterToDoctor.WebSell.Attributes;
using RegisterToDoctor.WebSell.Validators;
using RegisterToDoctor.WebSell.Validators.DoctorValidators;

namespace RegisterToDoctor.WebSell.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAttributedServices(this IServiceCollection services)
        {
            var asmbly = Assembly.GetExecutingAssembly();
            var typeList = asmbly.GetTypes().Where(
                    t => t.GetCustomAttributes(typeof(RegisrationMarkerAttribute), true).Length > 0
            );

            foreach (var item in typeList)
            {
                var attribute = item.GetCustomAttribute<RegisrationMarkerAttribute>();
                var interfaces = item.GetInterfaces();
                var serviceType = interfaces.FirstOrDefault() ?? item;

                switch (attribute.Lifetime)
                {
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(serviceType, item);
                        break;
                    case ServiceLifetime.Scoped:
                        services.AddScoped(serviceType, item);
                        break;
                    case ServiceLifetime.Transient:
                        services.AddTransient(serviceType, item);
                        break;
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
