using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Entities;

namespace ProjectManagementSystem.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		public DbSet<Product> Products { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Supplier> Suppliers { get; set; }

		public DbSet<Inventory> Inventories { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderItem> OrderItems { get; set; }

		public DbSet<ProductReview> ProductReviews { get; set; }

		public DbSet<ProductAttribute> ProductAttributes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Product>()
				.HasOne(p => p.Category)
				.WithMany(c => c.Products)
				.HasForeignKey(p => p.CategoryId);

			modelBuilder.Entity<Product>()
				.HasOne(p => p.Supplier)
				.WithMany(s => s.Products)
				.HasForeignKey(p => p.SupplierId);

			modelBuilder.Entity<Inventory>()
				.HasOne(i => i.Product)
				.WithOne(p => p.Inventory)
				.HasForeignKey<Inventory>(i => i.ProductId);

			modelBuilder.Entity<OrderItem>()
				.HasOne(o => o.Product)
				.WithMany()
				.HasForeignKey(o => o.ProductId);

			modelBuilder.Entity<OrderItem>()
				.HasOne(o => o.Order)
				.WithMany(o => o.Items)
				.HasForeignKey(o => o.OrderId);
		}
	}
}