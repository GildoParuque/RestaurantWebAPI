﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastruture.Persistence;


namespace Restaurants.Infrastruture.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void  AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("RestaurantDb");

            services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
