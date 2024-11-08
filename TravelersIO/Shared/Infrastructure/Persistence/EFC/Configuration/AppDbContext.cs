using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using TravelersIO.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using TravelersIO.Subscriptions.Domain.Model.Aggregates;

namespace TravelersIO.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Plan>().HasKey(p => p.Id);
        builder.Entity<Plan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Plan>().Property(p => p.Name).IsRequired();
        builder.Entity<Plan>().Property(p => p.MaxUsers).IsRequired();
        builder.Entity<Plan>().Property(p => p.Default).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }
}
