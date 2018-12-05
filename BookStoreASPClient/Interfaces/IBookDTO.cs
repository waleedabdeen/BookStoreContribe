namespace BookStoreASPClient.Interfaces
{
    public interface IBookDTO
    {
        string Id { get; set; }

        string Title { get; set; }

        string Author { get; set; }

        decimal Price { get; set; }
    }
}
