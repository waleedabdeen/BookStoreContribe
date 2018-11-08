using System;
using System.Collections.Generic;

namespace BookStoreWFClient.Model
{
    public class OrderDetailsDTO
    {
        public string Id { get; set; }

        public string CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public decimal TotalAmount { get; set; }

        public IEnumerable<OrderItemDTO> OrderItemsDTO { get; set; }
    }
}
