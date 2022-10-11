

namespace Models
{
   public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Review> Reviews { get; set; }//one to many relationshop
        public ICollection<MovieProducer> MovieProducers { get; set; }//many to many relationship
        public ICollection<MovieCategory> MovieCategories { get; set; }//many to many relationship
    }
}
