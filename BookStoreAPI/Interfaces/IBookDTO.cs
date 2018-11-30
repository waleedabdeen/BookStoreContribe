namespace BookStoreAPI.Interfaces
{
    public interface IBookDTO
    {
        string Id { get; }

        string Title { get; }

        string Author { get; }

        decimal Price { get; }
    }
}
