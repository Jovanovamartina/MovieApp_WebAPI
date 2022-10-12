using AutoMapper;
using Busines.Abstraction;
using Models;
using MoviesApp.Dto;
using MoviesApp.Interfaces;

namespace Busines.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public bool CreateCountry(CountryDto createCountry)
        {
            var country = _countryRepository.GetCountries()
   .Where(c => c.Name.Trim().ToUpper() == createCountry.Name.TrimEnd().ToUpper())
   .FirstOrDefault();

            var countryMap = _mapper.Map<Country>(createCountry);
            var result = _countryRepository.CreateCountry(countryMap);
            return result;
        }

        public bool Delete(int id)
        {
            var countryToDelete = _countryRepository.GetCountry(id) ?? throw new Exception("no item with this id found");
            var result = _countryRepository.DeleteCountry(countryToDelete);
            return result;
        }

        public ICollection<CountryDto> GetAll()
        {
            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
            if (countries.Count() == 0)
            {
                throw new Exception("The list is empty");
            }
            return countries;
        }

        public CountryDto GetById(int id)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(id)) ?? throw new Exception("no category found");
            return country;
        }

        public CountryDto GetCountryByProducer(int producerId)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByProducer(producerId));

            return country;
        }

        //public ProducerDto GetCountryByProducer(int producerId)
        //{
        //    var country = _mapper.Map<ProducerDto>(_countryRepository.GetCountryByProducer(producerId));

        //    return country;
        //}

        public bool Update(CountryDto entity)
        {

            var countryMap = _mapper.Map<Country>(entity);

            var result = _countryRepository.UpdateCountry(countryMap);
            if (result == null)
            {
                throw new Exception("Something went wrong please try again later");
            }
            return result;
        }
    }
}
