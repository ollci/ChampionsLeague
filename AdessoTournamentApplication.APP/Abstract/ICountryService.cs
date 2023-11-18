using AdessoTournamentApplication.APP.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoTournamentApplication.APP.Abstract
{
    public interface ICountryService
    {
        void AddCountry(CountryDto countryDto);
        List<CountryDto> GetAllCountries();
        CountryDto GetCountryById(int countryId);
        void UpdateCountry(CountryDto updatedCountryDto);
        void DeleteCountry(int countryId);
    }
}
