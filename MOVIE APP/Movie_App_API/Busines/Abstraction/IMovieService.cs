using MoviesApp.Dto;


namespace Busines.Abstraction
{
    public interface IMovieService:IRepository<MovieDto>
    {
      decimal  GetMovieRating(int movieId);
      bool CreateMovie(MovieDto movieCreate, int producerId,int categoryId);
    }
}
