using System.Collections.Generic;
using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces
{
    public interface ICart
    {
        IEnumerable<CartItem> CartItems { get; }
    }
}
