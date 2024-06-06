using CourseWork.API.Models;

namespace CourseWork.API.Repository
{
    public interface IProductRepository
    {
        Product InsertProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(int productId);
        Product GetProductById(int Id);
        IEnumerable<Product> GetProducts();
    }
}
