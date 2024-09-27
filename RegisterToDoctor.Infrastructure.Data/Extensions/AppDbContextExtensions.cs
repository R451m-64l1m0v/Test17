﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RegisterToDoctor.Infrastructure.DataAccessLayer.Context;

namespace RegisterToDoctor.Infrastructure.DataAccessLayer.Extensions
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