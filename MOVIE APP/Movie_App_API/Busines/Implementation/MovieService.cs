using AutoMapper;
using Busines.Abstraction;
using Models;
using MoviesApp.Dto;
using MoviesApp.Interfaces;


namespace Busines.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository,IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

       

        public bool CreateMovie(MovieDto movieCreate, int producerId, int categoryId)
        {
            var movieMap = _mapper.Map<Movie>(movieCreate);
            var result=_movieRepository.CreateMovie(producerId, categoryId, movieMap);
            return result;
        }

        public bool Delete(int id)
        {
            var movieToDelete = _movieRepository.GetMovie(id) ?? throw new Exception("no item with this id found");
            var result = _movieRepository.DeleteMovie(movieToDelete);
            return result;
        }

        public ICollection<MovieDto> GetAll()
        {
            var movies = _mapper.Map<List<MovieDto>>(_movieRepository.GetMovies());
            if (movies.Count() == 0)
            {
                throw new Exception("The list is empty");
            }
            return movies;
        }

        public MovieDto GetById(int id)
        {
            var movie = _mapper.Map<MovieDto>(_movieRepository.GetMovie(id)) ?? throw new Exception("no movie found");
            return movie;
        }

        public decimal GetMovieRating(int movieId)
        {
            var rating = _movieRepository.GetMovieRating(movieId);
            return rating;
        }

        public bool Update(MovieDto entity)
        {
            var movieMap = _mapper.Map<Movie>(entity);

            var result = _movieRepository.UpdateMovie(movieMap);
            if (result == null)
            {
                throw new Exception("Something went wrong please try again later");
            }
            return result;
        }
    }
}
