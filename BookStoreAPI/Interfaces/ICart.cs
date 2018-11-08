using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces
{
    public interface ICart
    {
        string Id { get; }

        IEnumerable<CartItem> CartItems { get; }
    }
}
