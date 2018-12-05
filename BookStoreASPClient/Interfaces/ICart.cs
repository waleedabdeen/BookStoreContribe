using System.Collections.Generic;
using BookStoreASPClient.Models;

namespace BookStoreASPClient.Interfaces
{
    public interface ICart
    {
        List<CartItem> CartItems { get; }
    }
}
