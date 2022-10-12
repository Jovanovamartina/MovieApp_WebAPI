
using Busines.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Dto;



namespace MoviesApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;
        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }
        [HttpGet]
        public IActionResult GetProducers()
        {
            try
            {
                var result = _producerService.GetAll().ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{producerId}")]
        public IActionResult GetProducer(int producerId)
        {
            try
            {
                var result = _producerService.GetById(producerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{producerId}/movie")]
        public IActionResult GetMovieByProducer(int producerId)
        {
            try
            {
                return Ok(_producerService.GetMoviesByProducer(producerId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateProducer([FromQuery] int countryId, [FromBody] ProducerDto producerCreate)
        {
            try
            {
                _producerService.CreateProducer(producerCreate, countryId);
                return Ok("Successfully created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{producerId}")]
        public IActionResult UpdateProducer(int producerId, [FromBody] ProducerDto updatedProducer)
        {
            if (producerId != updatedProducer.Id)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _producerService.Update(updatedProducer);
                return Ok("Succsessfully updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{producerId}")]
        public IActionResult DeleteProducer(int producerId)
        {
            try
            {
                _producerService.Delete(producerId);
                return Ok("Succsessfully deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
