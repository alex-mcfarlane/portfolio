using System;
using System.Linq;

namespace Portfolio.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {/*
            using (var context = new PortfolioContext(
                serviceProvider.GetRequiredService<DbContextOptions<PortfolioContext>>()))
            {
                // Look for any movies.
                if (context.Category.Any())
                {
                    return;   // DB has been seeded
                }

                context.Category.AddRange(
                    new Category
                    {
                        Title = "C#"
                    },
                    new Category
                    {
                        Title = "ASP.NET"
                    },
                    new Category
                    {
                        Title = "PHP"
                    },
                    new Category
                    {
                        Title = "Node.js"
                    },
                    new Category
                    {
                        Title = "MEAN"
                    },
                    new Category
                    {
                        Title = "MVC"
                    },
                    new Category
                    {
                        Title = "Vue.js"
                    }
                );
                context.SaveChanges();
            }*/
        }
    }
}
