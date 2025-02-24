using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Management_API.DTO;
using Product_Management_API.Models;
using Product_Management_API.Repositories;

namespace Product_Management_API.Services
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
