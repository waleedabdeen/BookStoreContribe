using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreAPI.Interfaces;

namespace BookStoreAPI.Models
{
    public class CartItem : ICartItem
    {

        public string Id { get; set; }

        public string BookId { get; set; }

        public int Quantity { get; set; }

        public int Status { get; set; }

        public CartItem()
        {
            Id = "";
            BookId = "";
            Quantity = 0;
        }

        public CartItem(string bookId, int quantity)
        {
            Id = Util.Util.GetNewId();
            BookId = bookId;
            Quantity = quantity;
        }
    }
}