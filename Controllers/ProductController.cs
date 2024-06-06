using CourseWork.API.DTOs;
using CourseWork.API.Models;
using CourseWork.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace coursework.Controllers
{
    [Route("api/10547/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
            => _productRepository = productRepository;

        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productRepository.GetProducts();
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.GetProductById(id);
            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] ProductDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ProductCategory = new Category
                {
                    Name = dto.ProductCategory.Name,
                    Description = dto.ProductCategory.Description
                }
            };

            var result = _productRepository.InsertProduct(product);
            return Ok(result);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDTO dto)
        {
            if (dto != null)
            {
                var product = new Product
                {
                    Id = id,
                    Name = dto.Name,
                    Description = dto.Description,
                    Price = dto.Price,
                    ProductCategory = new Category
                    {
                        Name = dto.ProductCategory.Name,
                        Description = dto.ProductCategory.Description
                    }
                };

                var result = _productRepository.UpdateProduct(product);
                return Ok(result);
            }
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productRepository.DeleteProduct(id);
            return Ok(result);
        }
    }
}
