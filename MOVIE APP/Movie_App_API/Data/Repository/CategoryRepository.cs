
using Data;
using Models;
using MoviesApp.Interfaces;

namespace MoviesApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories
                      .Where(e => e.Id == id)
                      .FirstOrDefault();
        }

        public ICollection<Movie> GetMovieByCategory(int categoryId)
        {
            return _context.MovieCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Movie).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }

    }
}
