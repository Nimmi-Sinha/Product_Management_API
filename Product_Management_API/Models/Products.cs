using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Product_Management_API.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        [Precision(18, 2)] 
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
