using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreASPClient.Models
{
    interface ICartItem
    {
        BookDTO Book { get; }

        int Quantity { get; }

        bool IsAvailable { get; }
    }
}
