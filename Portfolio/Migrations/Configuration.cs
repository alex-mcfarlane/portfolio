namespace Portfolio.Migrations
{
    using Portfolio.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Portfolio.Models.PortfolioContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Portfolio.Models.PortfolioContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Categories.AddOrUpdate(c => c.ID,
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
        }
    }
}
