using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreAPI.Enums;

namespace BookStoreAPI.Interfaces
{
    public interface IOrder
    {
        string Id { get; set; }

        string CustomerId { get; set; }

        DateTime OrderDate { get; set; }

        OrderStatus Status { get; set; }

        DateTime CreatedAt { get; set; }
    }
}
