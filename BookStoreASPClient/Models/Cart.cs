using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreASPClient.Modules.ApiModule;

namespace BookStoreASPClient.Models
{
    public class Cart : ICart
    {
        public List<CartItem> CartItems { get; set; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public async void InitializeNewCart()
        {
            Task<string> task = new BookstoreService().GetNewId();
            task.Start();
        }
    }
}
