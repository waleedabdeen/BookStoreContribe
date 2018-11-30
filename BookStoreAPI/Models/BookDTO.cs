namespace BookStoreAPI.Models
{
    public class BookDTO : Interfaces.IBookDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }
    }
}