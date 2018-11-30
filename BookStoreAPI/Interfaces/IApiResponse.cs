namespace BookStoreAPI.Interfaces
{
    public interface IApiResponse
    {
        bool Error { get; }
        string Message { get; }
        object Data { get; }
    }
}
