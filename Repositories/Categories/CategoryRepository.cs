using CourseWork.API.DbContexts;
using CourseWork.API.Models;

namespace CourseWork.API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _dbContext;
        public CategoryRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Category DeleteCategory(int categoryId)
        {
            var category = _dbContext.Categories.Find(categoryId);
            var entry = _dbContext.Categories.Remove(category);
            Save();
            return entry.Entity;
        }
        public Category GetCategoryById(int categoryId)
        {
            var category = _dbContext.Categories.Find(categoryId);
            return category;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }
        public Category InsertCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return category;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public Category UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            Save();
            return category;
        }
    }
}
