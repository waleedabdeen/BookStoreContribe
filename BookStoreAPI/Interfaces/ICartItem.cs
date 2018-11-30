using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces
{
    public interface ICartItem
    {
        BookDTO Book { get; }

        int Quantity { get; }

        bool IsAvailable { get; }
    }
}
