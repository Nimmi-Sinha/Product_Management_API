using System.ComponentModel.DataAnnotations;

namespace Product_Management_API.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Categories? Category { get; set; }
    }
}
