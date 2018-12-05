using BookStoreASPClient.Interfaces;

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
