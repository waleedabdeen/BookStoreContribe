using BookStoreWFClient.Interfaces;

namespace BookStoreWFClient.Model
{
    public class BookDTO : IBookDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public BookDTO()
        {
            Id = "";
            Title = "";
            Author = "";
            Price = 0;
        }

        public BookDTO(string id, string title, string author, decimal price)
        {
            Id = id;
            Title = title;
            Author = author;
            Price = price;
        }

    }
}
