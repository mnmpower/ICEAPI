using Microsoft.EntityFrameworkCore;

namespace ICE_API.models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Project>().ToTable("Project");

            modelBuilder.Entity<Person>().HasData(new Person { PersonID=1, FirstName="Maarten", LastName="Michiels", Email="m@m.be" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID=2, FirstName="Benji", LastName="Virus", Email="m@m.be" });

            modelBuilder.Entity<Project>().HasData(new Project { ProjectID=1, PersonID=1, Title= "First project", Description="First project to help people with corona at home", EmbeddedURL= "https://www.youtube.com/embed/mNpQ3u56C3M" });

        }
    }
}
