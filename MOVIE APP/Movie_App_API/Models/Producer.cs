

namespace Models
{
  public class Producer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Country Country { get; set; }
        public ICollection<MovieProducer> MovieProducers { get; set; }//many to many relationship

    }
}
