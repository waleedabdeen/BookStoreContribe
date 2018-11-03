using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Interfaces
{
    public interface ICart
    {
        string Id { get; }

        IEnumerable<ICartItem> CartItems { get; }
    }
}
