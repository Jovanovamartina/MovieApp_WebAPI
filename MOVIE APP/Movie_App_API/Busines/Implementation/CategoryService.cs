using AutoMapper;
using Busines.Abstraction;
using Microsoft.EntityFrameworkCore;
using Models;
using MoviesApp.Dto;
using MoviesApp.Interfaces;



namespace Busines.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper,IMovieRepository movieRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public bool CreateCategory(CategoryDto createCategory)
        {
            var category = _categoryRepository.GetCategories()
               .Where(c => c.Name.Trim().ToUpper() == createCategory.Name.TrimEnd().ToUpper())
               .FirstOrDefault() ?? throw new Exception("you did not create any category");

            var categoryMap = _mapper.Map<Category>(createCategory);
            
            var result = _categoryRepository.CreateCategory(categoryMap);
           
            return result;
        }

        public bool Delete(int id)
        {
            var categoryToDelete = _categoryRepository.GetCategory(id) ?? throw new Exception("no item with this id found");
            var result = _categoryRepository.DeleteCategory(categoryToDelete);
            return result;
        }

        public ICollection<CategoryDto> GetAll()
        {
            var categories = _categoryRepository.GetCategories(); 
            if (categories.Count() == 0)
            {
                throw new Exception("The list is empty");
            }
            var result = _mapper.Map<List<CategoryDto>>(categories);
            return result;
        }

        public CategoryDto GetById(int id)
        {
           
            var category = _categoryRepository.GetCategory(id) ?? throw new Exception("no category found");
          
            return _mapper.Map<CategoryDto>(category);
        }
        public List<CategoryDto> GetMoviesByCategory(int categoryId)
        {
            var movies = _movieRepository.GetMovies().Include(x => x.MovieCategories);
           
            var moviesByCategory = movies.Where(x => x.MovieCategories.Where(y => y.CategoryId == categoryId).Any()).ToList();
            if (moviesByCategory.Count() == 0)
            {
                throw new Exception("The list is empty");
            }
            return moviesByCategory.Select(x => _mapper.Map<CategoryDto>(x)).ToList();
        }
      

        public bool Update(CategoryDto entity)
        {
            var categoryMap = _mapper.Map<Category>(entity);
            var result = _categoryRepository.UpdateCategory(categoryMap);
            if (result == null)
            {
                throw new Exception("Something went wrong please try again later");
            }
            return result;
        }

      
    }
}
