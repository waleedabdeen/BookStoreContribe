using BookStoreWFClient.Interfaces;

namespace BookStoreWFClient.Model
{
    public class CartItem : ICartItem
    {
        public BookDTO Book { get; set; }

        public int Quantity { get; set; }

        public bool IsAvailable { get; set; }

        public CartItem()
        {
            Book = new BookDTO();
            Quantity = 0;
            IsAvailable = true;
        }

        public override string ToString()
        {
            return Book.Title + " - " + Quantity + " ppcs";
        }
    }
}
