﻿
namespace BookStoreWFClient.Model
{
    public interface IApiResponse
    {
        bool Error { get; set; }

        string Message { get; set; }

        object Data { get; set; }
    }
}
