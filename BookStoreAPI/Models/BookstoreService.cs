using System.Linq;
using BookStoreAPI.Interfaces;

namespace BookStoreAPI.Models
{
    public class BookstoreService
    {
        public static bool BookAvailable(string id, int quantity, IBookStoreAPIContext db)
        {
            if (db.Books.FirstOrDefault(a => a.Id == id) == null)
            {
                return false;
            }
            int stock = db.Books.FirstOrDefault(a => a.Id == id).InStock;
            int reserved = 0;
            if (db.OrderItems.Count() != 0)
            {
                reserved = db.OrderItems.Where(item => item.BookId == id &&
                item.ShippingStatus == Enums.ShippingStatus.NotShipped)
                .Sum(b => (int?)b.Quantity) ?? 0;
            }

            if (quantity > stock - reserved)
            {
                return false;
            }
            return true;
        }
    }
}