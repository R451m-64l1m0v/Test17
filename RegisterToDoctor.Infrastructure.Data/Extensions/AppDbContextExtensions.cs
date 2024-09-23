using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RegisterToDoctor.Infrastructure.Data.Context;

namespace RegisterToDoctor.Infrastructure.Data.Extensions
{
    public static class AppDbContextExtensions
    {
        public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(connectionString), ServiceLifetime.Transient);
        }
    }
}
