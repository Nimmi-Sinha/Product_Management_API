using System.ComponentModel.DataAnnotations;

namespace Product_Management_API.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public ICollection<Products>? Product { get; set; }
    }
}
