using Microsoft.EntityFrameworkCore;
using Library_Book_Management.Models;

namespace Library_Book_Management.Data
{
	public class LibraryDbContext : DbContext
	{
		public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
		{

		}

		public DbSet<Book> Books { get; set; }
	}
}
