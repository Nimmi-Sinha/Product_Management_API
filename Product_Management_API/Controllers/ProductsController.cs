using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Management_API.Data;
using Product_Management_API.Models;
using Product_Management_API.Services;
using Product_Management_API.DTO;

namespace Product_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //   private readonly ApplicationDbContext _context;
        private readonly IProducts _IProduct;

        public ProductsController(IProducts IProduct)
        {
            _IProduct = IProduct;
        }

        // GET: api/Products1
        [HttpGet]
        public List<Products> GetProduct()
        {
           return _IProduct.GetAllProduct();
        }

        // GET: api/Products1/5
        [HttpGet("{id}")]
        public ActionResult<Products> GetProducts(int id)
        {
            var product = _IProduct.GetProductsByID(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPut("{id}")]
        public ActionResult PutProducts(int id, ProductsDTO productdto)
        {
            if (id != productdto.ProductId)
            {
                return BadRequest();
            }

            _IProduct.UpdateProduct(productdto);

            return NoContent();
        }

        // POST: api/Products1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
       
        public ActionResult PostProducts(ProductsDTO products)
        {
            _IProduct.AddProduct(products);
            return CreatedAtAction(nameof(GetProduct), new { id = products.ProductId }, products);
        }
        // DELETE: api/Products1/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProducts(int id)
        {
            _IProduct.DeleteProduct(id);
            return NoContent();
        }

        private bool ProductsExists(int id)
        {
           return _IProduct.ProductsExists(id);
        }
    }
}
