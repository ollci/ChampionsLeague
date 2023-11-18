using AdessoTournamentApplication.APP.Concrete;
using AdessoTournamentApplication.APP.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdessoTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        // GET api/country
        [HttpGet]
        public ActionResult<IEnumerable<CountryDto>> GetAllCountries()
        {
            var countries = _countryService.GetAllCountries();
            return Ok(countries);
        }

        // GET api/country/5
        [HttpGet("{id}")]
        public ActionResult<CountryDto> GetCountryById(int id)
        {
            var country = _countryService.GetCountryById(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // POST api/country
        [HttpPost]
        public ActionResult<CountryDto> AddCountry([FromBody] CountryDto countryDto)
        {
            _countryService.AddCountry(countryDto);
            return CreatedAtAction(nameof(GetCountryById), new { id = countryDto.CountryId }, countryDto);
        }

        // PUT api/country/5
        [HttpPut("{id}")]
        public ActionResult<CountryDto> UpdateCountry(int id, [FromBody] CountryDto updatedCountryDto)
        {
            var existingCountry = _countryService.GetCountryById(id);

            if (existingCountry == null)
            {
                return NotFound();
            }

            updatedCountryDto.CountryId = id; // Güncellenecek ülke ID'sini ayarla
            _countryService.UpdateCountry(updatedCountryDto);

            return Ok(updatedCountryDto);
        }

        // DELETE api/country/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCountry(int id)
        {
            var existingCountry = _countryService.GetCountryById(id);

            if (existingCountry == null)
            {
                return NotFound();
            }

            _countryService.DeleteCountry(id);

            return NoContent();
        }
    }
}
