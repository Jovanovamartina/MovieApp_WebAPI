using AutoMapper;
using Busines.Abstraction;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Dto;



namespace MoviesApp.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public IActionResult GetMovies()
        {
            try
            {
                var result = _movieService.GetAll().ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{movieId}")]
        public IActionResult GetMovie(int movieId)
        {
            try
            {
                var result = _movieService.GetById(movieId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{movieId}/rating")]
        public IActionResult GetMovieRating(int movieId)
        {
            try
            {
                var rating = _movieService.GetMovieRating(movieId);
                return Ok(rating);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateMovie([FromQuery] int producerId, [FromQuery] int categoryId, [FromBody] MovieDto movieCreate)
        { 
            try
            {
                _movieService.CreateMovie(movieCreate, producerId, categoryId);
                return Ok("Successfully created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{movieId}")]
        public IActionResult UpdateMovie(int movieId,[FromBody] MovieDto updatedMovie)
        {
            if (movieId != updatedMovie.Id)
            {
                var result = "the id is not same";
                return BadRequest(result);
            }
            try
            {
                _movieService.Update(updatedMovie);
                return Ok("Succsessfully updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{movieId}")]
        public IActionResult DeleteMovie(int movieId)
        {
            try
            {
                _movieService.Delete(movieId);
                return Ok("Succsessfully deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}



