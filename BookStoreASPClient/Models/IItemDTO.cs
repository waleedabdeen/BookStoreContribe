﻿namespace BookStoreASPClient.Models
{
    public interface IItemDTO
    {
        string Id { get; set; }

        string BookId { get; set; }

        int Quantity { get; set; }

    }
}
