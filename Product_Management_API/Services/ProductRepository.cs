using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Product_Management_API.Data;
using Product_Management_API.DTO;
using Product_Management_API.Models;
using Product_Management_API.Repositories;

namespace Product_Management_API.Services
{
    public class ProductRepository : IProducts
    {
        private AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }


        public List<Products> GetAllProduct()
        {
            var products = _context.Product.ToList();
            return products;
        }

        public Products? GetProductsByID(int id) => _context.Product.FirstOrDefault(x => x.ProductId == id);

        public void UpdateProduct(ProductsDTO product)
        {
            var _productrepository = new Products()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            };
            _context.Product.Update(_productrepository);
            _context.SaveChanges();
        }

        public void AddProduct(ProductsDTO product)
        {
            var _productrepository = new Products()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            };
            _context.Product.Add(_productrepository);
            _context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            Products? product = _context.Product.FirstOrDefault(x => x.ProductId == id);
            if (product != null)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
            }
        }
        public bool ProductsExists(int id)
        {
            Products? products = _context.Product.FirstOrDefault(x => x.ProductId == id);
            if (products != null)
            {
                return true;
            }
            return false;
        }


    }
}
