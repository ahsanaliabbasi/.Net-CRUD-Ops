using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDBContext:DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> dbContextOptions):base(dbContextOptions) { 
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Regions> Region { get; set; }

        public DbSet<Walks> Walk { get; set; }

        public DbSet<User> Users { get; set; }



    }
}
