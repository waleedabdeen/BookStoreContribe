using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreAPI.Interfaces;

namespace BookStoreAPI.Models
{
    public class CartItem : ICartItem
    {
        public BookDTO Book { get; set; }

        public int Quantity { get; set; }

        public bool IsAvailable { get; set; }

        public CartItem()
        {
            Book = new BookDTO();
            Quantity = 0;
        }

        public CartItem(BookDTO book, int quantity)
        {
            Book = book;
            Quantity = quantity;
        }
    }
}