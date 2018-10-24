using Microsoft.EntityFrameworkCore;

namespace My.API_Event.Models
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        { }

        public DbSet<EventConfirmation> EventConfirmations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Event> Events  { get; set; }
    }
}
