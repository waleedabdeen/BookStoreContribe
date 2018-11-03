namespace BookStoreAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStoreAPI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookStoreAPI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0)) DELETE FROM ?'");
            context.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'");

            context.Roles.AddOrUpdate(x=> x.Id, new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("Administrator"));
            context.Roles.AddOrUpdate(x => x.Id, new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("User"));

            context.Books.AddOrUpdate(
                x => x.Id,
                new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "Mastering åäö",
                    Author = "Average Swede",
                    Price = 762M,
                    InStock = 15,
                    CreatedAt = DateTime.Now
                }, new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "How To Spend Money",
                    Author = "Rich Block",
                    Price = 1000000M,
                    InStock = 1,
                    CreatedAt = DateTime.Now
                }, new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "Generic Title",
                    Author = "First Author",
                    Price = 185.5M,
                    InStock = 5,
                    CreatedAt = DateTime.Now
                }, new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "Generic Title",
                    Author = "Second Author",
                    Price = 1748M,
                    InStock = 3,
                    CreatedAt = DateTime.Now

                }, new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "Random Sales",
                    Author = "Cunning Bastard",
                    Price = 999M,
                    InStock = 20,
                    CreatedAt = DateTime.Now

                }, new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "Random Sales",
                    Author = "Cunning Bastard",
                    Price = 499.5M,
                    InStock = 3,
                    CreatedAt = DateTime.Now

                }, new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "Desired",
                    Author = "Rich Bloke",
                    Price = 564.5M,
                    InStock = 0,
                    CreatedAt = DateTime.Now
                });

        }
    }
}
