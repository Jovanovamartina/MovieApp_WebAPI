using MoviesApp.Dto;

namespace Busines.Abstraction
{
    public interface IProducerService:IRepository<ProducerDto>
    {
       List<MovieDto> GetMoviesByProducer(int producerId);
        bool CreateProducer(ProducerDto producerCreate, int countryId);
    }
}
