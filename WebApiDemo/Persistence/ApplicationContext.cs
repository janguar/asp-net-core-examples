
using Microsoft.EntityFrameworkCore;
using WebApiDemo.Contracts;
using WebAPiDemo.Entities;

namespace WebApiDemo.Persistence
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<ItemEntity> Items { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
           
        } 

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // https://www.connectionstrings.com/sqlite/
            var con = "Data Source=./database.db";

            optionsBuilder.UseSqlite(con);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
