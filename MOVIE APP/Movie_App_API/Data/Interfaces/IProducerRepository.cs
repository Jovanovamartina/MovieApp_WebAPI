using Models;


namespace MoviesApp.Interfaces
{
    public interface IProducerRepository
    {
        ICollection<Producer> GetProducers();
        Producer GetProducer(int producerId);
        ICollection<Movie> GetMovieByProducer(int producerId);
        bool ProducerExis(int producerId);
        bool CreateProducer(Producer producer);
        bool UpdateProducer(Producer producer);
        bool DeleteProducer(Producer producer);
        bool Save();

    }
}
