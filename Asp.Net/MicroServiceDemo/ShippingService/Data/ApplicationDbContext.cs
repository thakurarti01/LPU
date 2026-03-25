using Microsoft.EntityFrameworkCore;
using ShippingServiceAPI.Models;

namespace ShippingServiceAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.ShippingAddress)
                .WithOne(a => a.Shipment)
                .HasForeignKey<Address>(a => a.ShipmentId);
        }
    }
}