using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RegisterToDoctor.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Infrastructure.Data.Extensions
{
    public static class AppDbContextExtensions
    {
        public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(connectionString));
        }
    }
}
