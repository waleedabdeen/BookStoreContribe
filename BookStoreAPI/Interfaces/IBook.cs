namespace BookStoreAPI.Interfaces
{
    public interface IBook
    {
        string Id { get; }

        string Title { get; }

        string Author { get; }

        decimal Price { get; }

        int InStock { get; }

    }
}
