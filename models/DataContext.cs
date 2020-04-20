using Microsoft.EntityFrameworkCore;

namespace ICE_API.models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Initiatif> Initiatifs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Initiatif>().ToTable("Initiatif");
        }

    }
}
