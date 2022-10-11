

namespace Models
{
    public class MovieCategory//Join table
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
