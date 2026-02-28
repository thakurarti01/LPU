using FlightSearchEngine.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightSearchEngine.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
		public DbSet<FlightResult> FlightResults { get; set; }
		public DbSet<FlightHotelResult> FlightHotelResults { get; set; }
	}
}
