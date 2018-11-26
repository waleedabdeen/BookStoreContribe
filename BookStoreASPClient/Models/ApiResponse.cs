using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreASPClient.Models
{
    public class ApiResponse : IApiResponse
    {
        public bool Error { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public ApiResponse()
        {
            Error = false;
            Message = "Ok";
            Data = null;
        }
    }
}
