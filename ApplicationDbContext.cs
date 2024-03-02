using Microsoft.EntityFrameworkCore;

namespace EventTicketAPI.Core
{
    public class ApplicationDbContext: DbContext
    {
        public object Ticket;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Tickets> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, constraints, etc.
        }
    }
}
