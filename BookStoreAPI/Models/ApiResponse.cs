namespace BookStoreAPI.Models
{
    public class ApiResponse : Interfaces.IApiResponse
    {
        public bool Error { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public ApiResponse(object data)
        {
            Error = false;
            Message = "Ok";
            Data = data;
        }
        public ApiResponse(object data, string message, bool error)
        {
            Error = error;
            Message = message;
            Data = data;
        }
    }
}