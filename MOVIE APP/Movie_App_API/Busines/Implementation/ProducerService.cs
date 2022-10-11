using AutoMapper;
using Busines.Abstraction;
using Microsoft.EntityFrameworkCore;
using Models;
using MoviesApp.Dto;
using MoviesApp.Interfaces;



namespace Busines.Implementation
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        public ProducerService(IProducerRepository producerRepository, ICountryRepository countryRepository,
            IMapper mapper,IMovieRepository movieRepository)
        {
            _producerRepository = producerRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

      

        public bool CreateProducer(ProducerDto producerCreate, int countryId)
        {
            var producers = _producerRepository.GetProducers()
               .Where(c => c.LastName.Trim().ToUpper() == producerCreate.LastName.TrimEnd().ToUpper())
               .FirstOrDefault();

            var producerMap = _mapper.Map<Producer>(producerCreate);
            producerMap.Country = _countryRepository.GetCountry(countryId);


           var result= _producerRepository.CreateProducer(producerMap);
            return result;
        }

        public bool Delete(int id)
        {
            var producerToDelete = _producerRepository.GetProducer(id) ?? throw new Exception("no item with this id found");
            var result = _producerRepository.DeleteProducer(producerToDelete);
            return result;
        }

        public ICollection<ProducerDto> GetAll()
        {
            var producers = _mapper.Map<List<ProducerDto>>(_producerRepository.GetProducers());
            if (producers.Count() == 0)
            {
                throw new Exception("The list is empty");
            }
            return producers;
        }

        public ProducerDto GetById(int id)
        {
            var producer = _mapper.Map<ProducerDto>(_producerRepository.GetProducer(id)) ?? throw new Exception("no movie found");
            return producer;
        }

        public List<MovieDto> GetMoviesByProducer(int producerId)
        {
            var movies = _movieRepository.GetMovies().Include(x => x.MovieProducers);
            var moviesByProducer = movies.Where(x => x.MovieProducers.Where(y => y.ProducerId == producerId).Any()).ToList();
            if (moviesByProducer.Count() == 0)
            {
                throw new Exception("The list is empty");
            }
            return moviesByProducer.Select(x => _mapper.Map<MovieDto>(x)).ToList();
        }

        public bool Update(ProducerDto entity)
        {
            var producerMap = _mapper.Map<Producer>(entity);
            var result = _producerRepository.UpdateProducer(producerMap);
            if (result == null)
            {
                throw new Exception("Something went wrong please try again later");
            }
            return result;
        }

       
    }
}
