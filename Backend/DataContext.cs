using Backend.Configurations;
using Backend.Entities;
using Backend.Seed;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> UserEntries { get; set; }
        public DbSet<Chat> ChatEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ChatConfig());
            modelBuilder.Entity<Chat>().HasData(new ChatSeed().ChatEntries);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.Entity<User>().HasData(new UserSeed().UserEntries);

            base.OnModelCreating(modelBuilder);
        }
    }
}