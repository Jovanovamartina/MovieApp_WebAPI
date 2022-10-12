using AutoMapper;
using Busines.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Dto;
using MoviesApp.Interfaces;


namespace MoviesApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewRepository reviewRepository,
            IMapper mapper,
            IMovieRepository movieRepository,
            IReviewerRepository reviewerRepository,
            IReviewService reviewService)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _reviewerRepository = reviewerRepository;
            _movieRepository = movieRepository;
            _reviewService = reviewService;
        }
        [HttpGet]
        public IActionResult GetReviews()
        {

            try
            {
                var result = _reviewService.GetAll().ToList();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpGet("{reviewId}")]
        public IActionResult GetReview(int reviewId)
        {
            try
            {
                var result = _reviewService.GetById(reviewId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }
        [HttpGet("movie/{movieId}")]
        public IActionResult GetReviewsForaMovie(int movieId)
        {
            try
            {
                return Ok(_reviewService.GetReviewsOfaMovie(movieId).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]

        public IActionResult CreateReview([FromQuery] int reviewerId, [FromQuery] int movieId, [FromBody] ReviewDto reviewCreate)
        {
            try
            {
                _reviewService.CreateReview(reviewCreate, reviewerId, movieId);
                return Ok("Succsessfully created");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
           
        }
        [HttpPut("{reviewId}")]
        public IActionResult UpdateReview(int reviewId, [FromBody] ReviewDto updatedReview)
        {
            if (reviewId != updatedReview.Id)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _reviewService.Update(updatedReview);
                return Ok("Succsessfully updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{reviewId}")]
     
        public IActionResult DeleteReview(int reviewId)
        {
            try
            {
                _reviewService.Delete(reviewId);
                return Ok("Succsessfully deleted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

