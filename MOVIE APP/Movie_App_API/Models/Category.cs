
namespace Models
{
   public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }//many to many relationship
    }
}
