using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreAPI.Interfaces;

namespace BookStoreAPI.Models
{
    public class Cart : ICart
    {
        public string Id { get; set; }

        //public IEnumerable<CartItem> CartItems { get; set; }

        public IEnumerable<CartItem> CartItems { get; set; }
    }
}