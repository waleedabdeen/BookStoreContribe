using System.Collections.Generic;
using BookStoreWFClient.Interfaces;

namespace BookStoreWFClient.Model
{
    public class Cart : ICart
    {
        public List<CartItem> CartItems { get; set; }

        public Cart()
        {
            InitializeNewCart();
        }
        public void InitializeNewCart()
        {
            CartItems = new List<CartItem>();
        }
    }
}
