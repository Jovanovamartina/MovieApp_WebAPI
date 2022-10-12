
using MoviesApp.Dto;


namespace Busines.Abstraction
{
    public interface ICountryService:IRepository<CountryDto>
    {
       CountryDto GetCountryByProducer(int producerId);
        bool CreateCountry(CountryDto createCountry);
   
    }
}
