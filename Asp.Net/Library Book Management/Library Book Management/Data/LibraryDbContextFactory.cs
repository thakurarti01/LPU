using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Library_Book_Management.Data
{
	public class LibraryDbContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
	{
		public LibraryDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
			optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;");

			return new LibraryDbContext(optionsBuilder.Options);
		}
	}
}