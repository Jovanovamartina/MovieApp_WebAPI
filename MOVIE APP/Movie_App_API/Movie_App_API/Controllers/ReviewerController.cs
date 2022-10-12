
using Busines.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Dto;



namespace MoviesApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : Controller
    {
        private readonly IReviewerService _reviewerService;

        public ReviewerController(IReviewerService reviewerService)
        {
            _reviewerService = reviewerService;
        }

        [HttpGet]

        public IActionResult GetReviewers()
        {
            try
            {
                var result = _reviewerService.GetAll().ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{reviewerId}")]

        public IActionResult GetReviewer(int reviewerId)
        {
            try
            {
                var result = _reviewerService.GetById(reviewerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{reviewerId}/reviews")]
        public IActionResult GetReviewsByAReviewer(int reviewerId)
        {
            try
            {
                return Ok(_reviewerService.GetReviewsByReviewer(reviewerId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public IActionResult CreateReviewer([FromBody] ReviewerDto reviewerCreate)
        {
            try
            {
                _reviewerService.CreateReviewer(reviewerCreate);
                return Ok("Successfully created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{reviewerId}")]

        public IActionResult UpdateReviewer(int reviewerId, [FromBody] ReviewerDto updatedReviewer)
        {
          
              
            if (reviewerId != updatedReviewer.Id)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _reviewerService.Update(updatedReviewer);
                return Ok("Updated sucsessfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }


        [HttpDelete("{reviewerId}")]

        public IActionResult DeleteReviewer(int reviewerId)
        {
            try
            {
                _reviewerService.Delete(reviewerId);
                return Ok("Succsessfully deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
