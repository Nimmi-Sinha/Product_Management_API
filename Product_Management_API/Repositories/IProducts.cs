using Product_Management_API.DTO;
using Product_Management_API.Models;

namespace Product_Management_API.Repositories
{
    public interface IProducts
    {
        List<Products> GetAllProduct();
        Products? GetProductsByID(int id);
        void UpdateProduct(ProductsDTO products);
        void AddProduct(ProductsDTO product);
        void DeleteProduct(int id);
        bool ProductsExists(int id);


    }
}
