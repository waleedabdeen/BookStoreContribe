using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookStoreAPI.Interfaces;

namespace BookStoreAPI.Models
{
    public class Cart : ICart
    {
        [Required]
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}