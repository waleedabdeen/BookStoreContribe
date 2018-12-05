using System.Collections.Generic;
using BookStoreWFClient.Model;

namespace BookStoreWFClient.Interfaces
{
    public interface ICart
    {
        List<CartItem> CartItems { get; }
    }
}
