using System.Collections.Generic;

namespace BookStoreASPClient.Models
{
    public class OrderCreatedViewModel
    {
        public OrderDetailsDTO OrderDetailsDTO { get; set; }

        public IEnumerable<CartItem> CartItems { get; set; }
    }
}