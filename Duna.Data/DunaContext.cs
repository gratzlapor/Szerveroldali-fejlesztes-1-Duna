using Duna.Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace Duna.Data
{
    public class DunaContext : DbContext
    {
        public DbSet<DunaAdat> DunaAdatok { get; set; }

        public DunaContext(DbContextOptions<DunaContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
