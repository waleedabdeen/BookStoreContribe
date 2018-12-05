﻿using BookStoreASPClient.Interfaces;

namespace BookStoreASPClient.Models
{
    public class OrderItemDTO : IItemDTO
    {
        public string Id { get; set; }

        public string OrderId { get; set; }

        public string BookId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int Status { get; set; }
    }
}
