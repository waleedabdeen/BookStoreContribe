using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Book : Interfaces.IBook , Interfaces.IBookDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public System.DateTime CreatedAt { get; set; }
    }
}