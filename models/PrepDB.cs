using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace ICE_API.models
{
    public static class PrepDB
    {
        public static void PrepareDB(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DataContext>());
            }
        }

        public static void SeedData(DataContext context)
        {
            System.Console.WriteLine("Aplying Migrations...");

            context.Database.Migrate();

            if (!context.People.Any())
            {
                System.Console.WriteLine("No People found - seeding Peoples in DB ...");
                context.People.AddRange(
                new Person { PersonID = 1, FirstName = "Maarten", LastName = "Michiels", Email = "m@m.be" },
                new Person { PersonID = 2, FirstName = "Benji", LastName = "Virus", Email = "m@m.be" }
                );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("People already seeded ...");
            }

            if (!context.Projects.Any())
            {
                System.Console.WriteLine("No Projects found - seeding Projects in DB ...");
                context.Projects.AddRange(
                new Project { ProjectID = 1, PersonID = 1, Title = "First project", Description = "First project to help people with corona at home", EmbeddedURL = "https://www.youtube.com/embed/mNpQ3u56C3M" }
                );
                context.SaveChanges();

            }
            else
            {
                System.Console.WriteLine("Project already seeded ...");
            }

            System.Console.WriteLine("Checking completed...");

        }


    }
}
