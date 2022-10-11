using Data;
using Models;
using MoviesApp.Dto;
using MoviesApp.Interfaces;

namespace MoviesApp.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateMovie(int producerId, int categoryId, Movie movie)
        {
            var movieProducerEntity = _context.Producers.Where(a => a.Id == producerId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var movieProducer = new MovieProducer()
            {
                Producer = movieProducerEntity,
                Movie = movie,
            };

            _context.Add(movieProducer);

            var movieCategory = new MovieCategory()
            {
                Category = category,
                Movie = movie,
            };

            _context.Add(movieCategory);

            _context.Add(movie);

            return Save();
        }



        public bool DeleteMovie(Movie movie)
        {
            _context.Remove(movie);
            return Save();
        }

      

        public Movie GetMovie(int id)
        {
            return _context.Movies.Where(p => p.Id == id).FirstOrDefault();
        }

        public Movie GetMovie(string name)
        {
            return _context.Movies.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetMovieRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.Movie.Id == pokeId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public IQueryable<Movie> GetMovies()
        {
           return _context.Set<Movie>();
        }

        public Movie GetMovieTrimToUpper(MovieDto movieCreate)
        {
            return GetMovies().Where(c => c.Name.Trim().ToUpper() == movieCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateMovie(Movie movie)
        {
            _context.Update(movie);
            return Save();
        }

       
    }
}