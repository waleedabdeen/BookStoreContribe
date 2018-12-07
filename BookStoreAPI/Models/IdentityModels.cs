
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStoreAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, Interfaces.IBookStoreAPIContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MyDBInitializer<ApplicationDbContext>());
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BookStoreAPI.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<BookStoreAPI.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<BookStoreAPI.Models.OrderItem> OrderItems { get; set; }

        public void MarkAsModified(object item)
        {
            Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        private class MyDBInitializer<T> : System.Data.Entity.DropCreateDatabaseAlways<ApplicationDbContext>
        {
            protected override void Seed(ApplicationDbContext context)
            {
                // empty databse
                context.Database.ExecuteSqlCommand("sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");
                context.Database.ExecuteSqlCommand("sp_MSForEachTable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0)) DELETE FROM ?'");
                context.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'");

                // adding roles
                context.Roles.Add(new IdentityRole("Administrator"));
                context.Roles.Add(new IdentityRole("User"));

                // adding books
                IList<BookStoreAPI.Models.Book> booksList = new List<BookStoreAPI.Models.Book>();
                booksList.Add(new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "Mastering åäö",
                    Author = "Average Swede",
                    Price = 762M,
                    InStock = 15,
                    CreatedAt = DateTime.Now
                });
                booksList.Add(new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "How To Spend Money",
                    Author = "Rich Block",
                    Price = 1000000M,
                    InStock = 1,
                    CreatedAt = DateTime.Now
                });
                booksList.Add(new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "Generic Title",
                    Author = "First Author",
                    Price = 185.5M,
                    InStock = 5,
                    CreatedAt = DateTime.Now
                });
                booksList.Add(new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "Generic Title",
                    Author = "Second Author",
                    Price = 1748M,
                    InStock = 3,
                    CreatedAt = DateTime.Now
                });
                booksList.Add(new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "Random Sales",
                    Author = "Cunning Bastard",
                    Price = 999M,
                    InStock = 20,
                    CreatedAt = DateTime.Now
                });
                booksList.Add(new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "Random Sales",
                    Author = "Cunning Bastard",
                    Price = 499.5M,
                    InStock = 3,
                    CreatedAt = DateTime.Now
                });
                booksList.Add(new Models.Book()
                {
                    Id = Util.Util.GetNewId(),
                    Title = "Desired",
                    Author = "Rich Bloke",
                    Price = 564.5M,
                    InStock = 0,
                    CreatedAt = DateTime.Now
                });
                context.Books.AddRange(booksList);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var sampleUser = new ApplicationUser { UserName = "user@1.com", Email = "user@1.com" };
                userManager.Create(sampleUser, "P@ssw0rd");
                userManager.AddToRole(sampleUser.Id, "User");

                base.Seed(context);
            }
        }
    }
}