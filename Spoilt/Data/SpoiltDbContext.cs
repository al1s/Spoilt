using Microsoft.EntityFrameworkCore;
using Spoilt.Models;

namespace Spoilt.Data
{
    public class SpoiltDbContext : DbContext
    {
        public SpoiltDbContext(DbContextOptions<SpoiltDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Spoiler> Spoilers { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<UserSession> Sessions { get; set; }
    }
}
