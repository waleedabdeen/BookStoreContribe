using BookStoreASPClient.Models;

namespace BookStoreASPClient.Interfaces
{
    interface ICartItem
    {
        BookDTO Book { get; }

        int Quantity { get; }

        bool IsAvailable { get; }
    }
}
