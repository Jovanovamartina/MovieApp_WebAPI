
using Busines.Abstraction;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Dto;


namespace MoviesApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            try
            {
                return Ok(_categoryService.GetAll().ToList());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetCategory(int categoryId)
        {
            try
            {
                return Ok(_categoryService.GetById(categoryId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("movie/{categoryId}")]
        public IActionResult GetMovieByCategoryId(int categoryId)
        {
            try
            {
                return Ok(_categoryService.GetMoviesByCategory(categoryId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
       
        }
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryCreate)
        {
            try
            {
                _categoryService.CreateCategory(categoryCreate);
                return Ok("Succsessfully created");
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
           

        }
        [HttpPut("{categoryId}")]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryDto updatedCategory)
        {
           
            if (categoryId != updatedCategory.Id)
            {
                var message = "Please enter same Id";
                return BadRequest(message);
            }

            try
            {
                _categoryService.Update(updatedCategory);
                return Ok("Succsessfully updated");
            }
            catch (Exception ex)
            {
              
                return BadRequest(ex.Message);
            }
           
         
        }
        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            try
            {
                _categoryService.Delete(categoryId);
                return Ok("Succsessfully deleted");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
