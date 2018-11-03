using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces
{
    public interface IBookStoreAPIContext : IDisposable
    {
        DbSet<Book> Books { get; }

        DbSet<Order> Orders { get; }

        DbSet<OrderItem> OrderItems { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        void MarkAsModified(object item);
    }
}
