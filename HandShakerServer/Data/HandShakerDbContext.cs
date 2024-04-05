using Microsoft.EntityFrameworkCore;

namespace HandShakerServer.Data
{
    public class HandShakerDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public HandShakerDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=root;password=marinaanna;database=handshakerdb;";

            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
