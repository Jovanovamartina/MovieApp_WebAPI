
using MoviesApp.Dto;


namespace Busines.Abstraction
{
    public interface IReviewerService : IRepository<ReviewerDto>
    {
       List< ReviewDto> GetReviewsByReviewer(int reviewerId);
        bool CreateReviewer(ReviewerDto createReviewer);
    }
}
