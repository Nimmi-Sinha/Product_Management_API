

namespace Product_Management_API.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public ICollection<Products>? Products { get; set; }
    }
}
