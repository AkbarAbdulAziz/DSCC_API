using CourseWork.API.DTOs;
using CourseWork.API.Models;
using CourseWork.API.Repository;

using Microsoft.AspNetCore.Mvc;

using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseWork.API.Controllers
{
    [Route("api/10547/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/Category
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryRepository.GetCategories();
            return Ok(categories);
        }

        // GET api/Category/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            return Ok(category);
        }

        // POST api/Category
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDTO dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };

            var result = _categoryRepository.InsertCategory(category);
            return Ok(result);
        }

        // PUT api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDTO dto)
        {
            var category = new Category
            {
                Id = id,
                Name = dto.Name,
                Description = dto.Description
            };
            var result = _categoryRepository.UpdateCategory(category);
            return Ok(result);
        }

        // DELETE api/Category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryRepository.DeleteCategory(id);
            return Ok(result);
        }
    }
}
