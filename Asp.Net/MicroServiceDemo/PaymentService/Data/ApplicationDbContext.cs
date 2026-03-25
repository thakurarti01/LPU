using Microsoft.EntityFrameworkCore;
using PaymentServiceAPI.Models;
using System.Collections.Generic;

namespace PaymentServiceAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
    }
}