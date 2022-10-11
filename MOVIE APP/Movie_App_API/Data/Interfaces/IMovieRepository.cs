using Models;
using MoviesApp.Dto;


namespace MoviesApp.Interfaces
{
    public interface IMovieRepository
    {
        IQueryable<Movie> GetMovies();

        Movie GetMovie(int id);
        Movie GetMovie(string name);
        Movie GetMovieTrimToUpper(MovieDto movieCreate);
        decimal GetMovieRating(int movieId);
        bool CreateMovie(int producerId, int categoryId,Movie movie);
        bool UpdateMovie( Movie movie);
        bool DeleteMovie(Movie movie);
        bool Save();
    }
}
