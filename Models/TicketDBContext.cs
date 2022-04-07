using Microsoft.EntityFrameworkCore;

namespace Ticket_System.Models
{
    public class TicketDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> Types { get; set; }


        public TicketDBContext(DbContextOptions<TicketDBContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
