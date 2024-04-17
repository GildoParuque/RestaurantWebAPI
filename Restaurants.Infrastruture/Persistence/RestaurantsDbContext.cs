using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastruture.Persistence;

internal class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options)
{
    internal DbSet<Restaurant> Restaurants { get; set;}
    internal DbSet<Dish> Dishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
           .OwnsOne(c => c.Address);

        modelBuilder.Entity<Restaurant>()
            .HasMany(c => c.Dishes)
            .WithOne()
            .HasForeignKey(c => c.RestaurantId);
    }
}

