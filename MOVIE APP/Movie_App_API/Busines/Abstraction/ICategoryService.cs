
using MoviesApp.Dto;


namespace Busines.Abstraction
{
    public interface ICategoryService:IRepository<CategoryDto>
    {
        List<CategoryDto> GetMoviesByCategory(int categoryId);
        bool CreateCategory(CategoryDto createCategory);
    }
}
