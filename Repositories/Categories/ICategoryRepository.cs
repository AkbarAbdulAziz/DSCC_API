using CourseWork.API.Models;

namespace CourseWork.API.Repository
{
    public interface ICategoryRepository
    {

        Category InsertCategory(Category category);
        Category UpdateCategory(Category category);
        Category DeleteCategory(int categoryId);
        Category GetCategoryById(int Id);
        IEnumerable<Category> GetCategories();
    }
}
