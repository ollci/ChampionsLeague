using AdessoTournamentApplication.APP.Abstract;
using AdessoTournamentApplication.APP.Dtos;
using AdessoTournamentApplication.Data;
using AdessoTournamentApplication.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoTournamentApplication.APP.Concrete
{
    public class CountryService : ICountryService
    {
        private readonly AdtDbContext _context;

        public CountryService(AdtDbContext context)
        {
            _context = context;
        }

        // CREATE
        public void AddCountry(CountryDto countryDto)
        {
            var country = new Country
            {
                CountryId = countryDto.CountryId,
                Name = countryDto.CountryName,
                // Diğer özellikleri ekleyebilirsiniz
            };

            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        // READ
        public List<CountryDto> GetAllCountries()
        {
            var countries = _context.Countries.ToList();

            // Country sınıfını CountryDto'ya dönüştürme
            var countryDtos = countries.Select(country => new CountryDto
            {
                CountryId = country.CountryId,
                CountryName = country.Name,
                // Diğer özellikleri burada dönüştürebilirsiniz
            }).ToList();

            return countryDtos;
        }

        public CountryDto GetCountryById(int countryId)
        {
            var country = _context.Countries.FirstOrDefault(c => c.CountryId == countryId);

            if (country == null)
            {
                return null;
            }

            // Country sınıfını CountryDto'ya dönüştürme
            var countryDto = new CountryDto
            {
                CountryId = country.CountryId,
                CountryName = country.Name,
                // Diğer özellikleri burada dönüştürebilirsiniz
            };

            return countryDto;
        }

        // UPDATE
        public void UpdateCountry(CountryDto updatedCountryDto)
        {
            var existingCountry = _context.Countries.FirstOrDefault(c => c.CountryId == updatedCountryDto.CountryId);

            if (existingCountry != null)
            {
                existingCountry.Name = updatedCountryDto.CountryName;
                // Diğer özellikleri güncellemek
                _context.SaveChanges();
            }
        }

        // DELETE
        public void DeleteCountry(int countryId)
        {
            var countryToRemove = _context.Countries.FirstOrDefault(c => c.CountryId == countryId);

            if (countryToRemove != null)
            {
                _context.Countries.Remove(countryToRemove);
                _context.SaveChanges();
            }
        }
    }
}
