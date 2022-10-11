using MoviesApp.Dto;


namespace Busines.Abstraction
{
    public interface IReviewService:IRepository<ReviewDto>
    {
        List<ReviewDto> GetReviewsOfaMovie(int movieId);
        bool CreateReview( ReviewDto reviewCreate, int reviewerId,int movieId);
    }
}
