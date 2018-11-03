using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
