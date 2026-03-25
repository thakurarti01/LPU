using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OrderServiceAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShippingAddress)
                .WithOne(a => a.Order)
                .HasForeignKey<Address>(a => a.OrderId);
        }
    }
}
