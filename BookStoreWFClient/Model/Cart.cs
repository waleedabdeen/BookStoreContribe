using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWFClient.Modules.ApiModule;

namespace BookStoreWFClient.Model
{
    public class Cart : ICart
    {
        public string Id { get; set; }

        public List<CartItem> CartItems { get; set; }

        public Cart()
        {
            Id = "";
            CartItems = new List<CartItem>();
        }
        public async void InitializeNewCart()
        {
            Task<string> task = new BookstoreService().GetNewId();
            task.Start();
            Id = await task;
        }
    }
}
