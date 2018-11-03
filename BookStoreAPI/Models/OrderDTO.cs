using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreAPI.Enums;

namespace BookStoreAPI.Models
{
    public class OrderDTO
    {
        public string Id { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

    }
}