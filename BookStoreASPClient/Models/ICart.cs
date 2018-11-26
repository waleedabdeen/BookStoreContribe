using System.Collections.Generic;

namespace BookStoreASPClient.Models
{
    public interface ICart
    {
        List<CartItem> CartItems { get; }
    }
}
