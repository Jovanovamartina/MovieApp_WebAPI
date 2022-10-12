
using Busines.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Dto;




namespace MoviesApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }


        [HttpPost]
        public IActionResult CreateCountry([FromBody] CountryDto countryCreate)
        {
            try
            {
                _countryService.CreateCountry(countryCreate);
                return Ok("Country added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{countryId}")]
        public IActionResult UpdateCountry(int countryId, [FromBody] CountryDto updatedCountry)
        {
            if (countryId != updatedCountry.Id)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _countryService.Update(updatedCountry);
                return Ok("Succsessfully updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{countryId}")]
        public IActionResult DeleteCountry(int countryId)
        {
            try
            {
                _countryService.Delete(countryId);
                return Ok("Succsessfully deleted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetCountries()
        {

            try
            {
                var result = _countryService.GetAll().ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{countryId}")]
        public IActionResult GetCountry(int countryId)
        {
            try
            {
                var result = _countryService.GetById(countryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/producers/{producerId}")]
        public IActionResult GetCountryOfAnProducer(int producerId)
        {
            try
            {
                var result = _countryService.GetCountryByProducer(producerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

