using System.Data.Entity;
using BookStoreAPI.Models;
using BookStoreAPI.Interfaces;
using System.Threading.Tasks;


namespace BookStoreAPI.Tests.TestDbSets
{
    public class TestBookStoreAPIContext : IBookStoreAPIContext
    {
        public TestBookStoreAPIContext()
        {
            this.Books = new TestBookDbSet();
            this.Orders = new TestOrderDbSet();
            this.OrderItems = new TestOrderItemsDbSet();
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Task.Run(() => 0);
        }
        public void MarkAsModified(object item) { }

        public void Dispose() { }
    }
}
