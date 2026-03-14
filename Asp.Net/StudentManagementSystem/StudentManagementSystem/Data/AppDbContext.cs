using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Student> Students { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>()
				.HasOne(s => s.Department)
				.WithMany()
				.HasForeignKey(s => s.DepartmentId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}