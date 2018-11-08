using System.Collections.Generic;

namespace BookStoreWFClient.Model
{
    public interface ICart
    {
        string Id { get; }

        List<CartItem> CartItems { get; }
    }
}
