namespace BookStoreAPI.Interfaces
{
    public interface IItemDTO
    {
        string Id { get; set; }

        string BookId { get; set; }

        int Quantity { get; set; }

        int Status { get; set; }
    }
}
