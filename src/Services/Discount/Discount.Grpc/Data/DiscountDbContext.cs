using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountDbContext(DbContextOptions<DiscountDbContext> options) 
    : DbContext(options)
{
    public DbSet<Coupon> Coupons { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasKey(x => x.Id);
        modelBuilder.Entity<Coupon>()
            .HasData(
                new Coupon{ Id = 1, ProductName = "Macbook 14 Pro", Description =  "Apple products discount", Amount = 5 },
                new Coupon{ Id = 2, ProductName = "Lenovo IdeaPad 3", Description = "PC discount", Amount = 15 });
            
        base.OnModelCreating(modelBuilder);
    }
}