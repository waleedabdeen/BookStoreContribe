using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreAPI.Enums;

namespace BookStoreAPI.Models
{
    public class OrderItem
    {
        public string Id { get; set; }

        public string OrderId { get; set; }

        public string BookId { get; set; }

        public decimal SellingPrice { get; set; }

        public int Quantity { get; set; }

        public ShippingStatus ShippingStatus { get; set; }

        public DateTime CreatedAt { get; set; }

        public OrderItemDTO ToDTO()
        {
            OrderItemDTO orderItemDTO = new OrderItemDTO
            {
                Id = this.Id,
                OrderId = this.OrderId,
                BookId = this.BookId,
                Price = this.SellingPrice,
                Quantity = this.Quantity,
                Status = (int)this.ShippingStatus
            };
            return orderItemDTO;
        }
    }
}