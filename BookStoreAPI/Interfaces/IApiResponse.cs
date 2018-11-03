using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Interfaces
{
    public interface IApiResponse
    {
        bool Error { get; }
        string Message { get; }
        object Data { get; }
    }
}
