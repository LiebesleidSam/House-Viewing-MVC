using Microsoft.EntityFrameworkCore;

namespace HouseViewingMVC.Data
{
    public class HouseViewingDbContext : DbContext
    {
        public HouseViewingDbContext(DbContextOptions<HouseViewingDbContext> options) : base(options) { }
        public DbSet<House> Houses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<UserStarred> UserStarreds { get; set; }
    }
}