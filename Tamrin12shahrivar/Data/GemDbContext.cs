using Microsoft.EntityFrameworkCore;
using Tamrin12shahrivar.Model;

namespace Tamrin12shahrivar.Data
{
    public class GemDbContext : DbContext
    {
        public GemDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Gem> Gems { get; set; }
    }
}
