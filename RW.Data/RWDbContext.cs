using RW.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace RW.Data
{
    public class RWDbContext : DbContext {
        public virtual DbSet<rssfeed> feedurls { get; set; }
        public virtual DbSet<article> articles { get; set; }

        public RWDbContext(DbContextOptions options) : base(options) { }
    }
}
