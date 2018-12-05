using BookStoreWFClient.Model;

namespace BookStoreWFClient.Interfaces
{
    interface ICartItem
    {
        BookDTO Book { get; }

        int Quantity { get; }

        bool IsAvailable { get; }
    }
}
