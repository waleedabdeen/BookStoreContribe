using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreAPI.Models;


namespace BookStoreAPI.Tests
{
    public class DemoData
    {
        public static Book GetDemoBook()
        {
            return new Book { Id = "id1", Title = "Generic Title", Author = "Cunning Basterd", Price = 499M, InStock = 1 , CreatedAt = new DateTime(2018-01-01)};
        }

        public static BookDTO GetDTOfromBook(Book book)
        {
            return new BookDTO { Id = book.Id, Author = book.Author, Price = book.Price, Title = book.Title };
        }

        public static BookDTO GetDemoBookDTO()
        {
            return new BookDTO { Id = "id1", Title = "Generic Title", Author = "Cunning Basterd", Price = 499M};
        }

        public static CartItem GetDemoCartItem()
        {
            return new CartItem { Book = GetDemoBookDTO(), Quantity = 1, IsAvailable = false };
        }

        public static Order GetDemoOrder()
        {
            return new Order { Id = "XyZ", Status = 0, CustomerId = "user200", OrderDate = new DateTime(2018 - 01 - 01), TotalAmount = 499 };
        }

        public static Cart GetAvailableDemoCart()
        {
            return new Cart { Id = "TheCartId", CartItems = new List<CartItem> { new CartItem(GetDemoBookDTO(), 1) } };
        }

        public static Cart GetOutOfStockDemoCart()
        {
            return new Cart { Id = "TheCartId", CartItems = new List<CartItem> { new CartItem(GetDemoBookDTO(), 4) } };
        }
    }
}
