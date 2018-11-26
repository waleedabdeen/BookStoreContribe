using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreASPClient.Models
{
    public class OrderCreatedViewModel
    {
        public OrderDetailsDTO OrderDetailsDTO { get; set; }

        public IEnumerable<CartItem> CartItems { get; set; }
    }
}