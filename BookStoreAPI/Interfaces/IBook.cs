using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
