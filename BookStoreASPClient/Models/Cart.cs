using System.Collections.Generic;
using BookStoreASPClient.Interfaces;

namespace BookStoreASPClient.Models
{
    public class Cart : ICart
    {
        public List<CartItem> CartItems { get; set; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }
    }
}
