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
            return new Book { Id = "id1", Title = "Generic Title", Author = "Cunning Basterd", Price = 499M, InStock = 1 };
        }

        public static CartItem GetDemoCartItem()
        {
            return new CartItem { Id = "id1", BookId = "ab12", Quantity = 1, Status = 0 };
        }

        public static Order GetDemoOrder()
        {
            return new Order { Id = "XyZ", Status = 0, CustomerId = "user200", OrderDate = new DateTime(2018 - 01 - 01) };
        }

        public static Cart GetAvailableDemoCart()
        {

            return new Cart { Id = "TheCartId", CartItems = new List<CartItem> { new CartItem(GetDemoBook().Id, 1) } };
        }
        public static Cart GetOutOfStockDemoCart()
        {
            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem(GetDemoBook().Id, 4));
            return new Cart { Id = "TheCartId", CartItems = cartItems };
        }
    }
}
