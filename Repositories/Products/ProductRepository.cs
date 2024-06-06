using CourseWork.API.DbContexts;
using CourseWork.API.Models;
using CourseWork.API.Repository;

using Microsoft.EntityFrameworkCore;

namespace coursework.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;
        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            var entry = _dbContext.Products.Remove(product);
            Save();
            return entry.Entity;
        }
        public Product GetProductById(int productId)
        {
            var prod = _dbContext.Products.Find(productId);
            _dbContext.Entry(prod).Reference(s => s.ProductCategory).Load();
            return prod;
        }
        public IEnumerable<Product> GetProducts()
        {
            var products = _dbContext.Products.Include(s => s.ProductCategory).ToList();
            return products;

        }
        public Product InsertProduct(Product product)
        {
            var p = new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ProductCategory = product.ProductCategory
            };

            var entry = _dbContext.Products.Add(p);
            Save();

            return entry.Entity;

        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public Product UpdateProduct(Product product)
        {
            var c = _dbContext.Categories.Find(product.Id);
            if (c == null)
            {
                throw new System.Exception("Category not found");
            }
            var p = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ProductCategory = product.ProductCategory
            };

            var entry = _dbContext.Products.Update(p);
            Save();

            return entry.Entity;
        }
    }
}
