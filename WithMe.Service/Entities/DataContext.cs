using System.Data.Entity;
using WithMe.Service.Entities.Configurations;
using WithMe.Service.Entities.Tables;

namespace WithMe.Service.Entities
{

    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Logging> Loggings { get; set; }


        public DataContext()
            : base("name=DataContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ActivityConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new LoggingConfiguration());
        }
    }
}