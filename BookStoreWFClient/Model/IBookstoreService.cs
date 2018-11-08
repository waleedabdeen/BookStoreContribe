using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWFClient.Model
{
    public interface IBookstoreService
    {
        Task<IEnumerable<IBookDTO>> GetBooksAsync(string searchString);

    }
}
