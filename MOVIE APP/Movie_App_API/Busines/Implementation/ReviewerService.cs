using AutoMapper;
using Busines.Abstraction;
using Models;
using MoviesApp.Dto;
using MoviesApp.Interfaces;


namespace Busines.Implementation
{
    public class ReviewerService : IReviewerService
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewerService(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }

    

        public bool CreateReviewer(ReviewerDto createReviewer)
        {
            var country = _reviewerRepository.GetReviewers()
                .Where(c => c.LastName.Trim().ToUpper() == createReviewer.LastName.TrimEnd().ToUpper())
                .FirstOrDefault();
            var reviewerMap = _mapper.Map<Reviewer>(createReviewer);

            var result = _reviewerRepository.CreateReviewer(reviewerMap);
            return result;
        }

        public bool Delete(int id)
        {
            var reviewerToDelete = _reviewerRepository.GetReviewer(id) ?? throw new Exception("no item with this id found");
            var result = _reviewerRepository.DeleteReviewer(reviewerToDelete);

            return result;
        }

        public ICollection<ReviewerDto> GetAll()
        {
            var reviewers = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetReviewers());
            if (reviewers.Count() == 0)
            {
                throw new Exception("The list is empty");
            }
            return reviewers;
        }

        public ReviewerDto GetById(int id)
        {
            var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(id)) ?? throw new Exception("no movie found");
            return reviewer;
        }

        public List<ReviewDto> GetReviewsByReviewer(int reviewerId)
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewerRepository.GetReviewsByReviewer(reviewerId));
            if (reviews.Count() == 0)
            {
                throw new Exception("The list is empty");
            }
            return reviews;
        }

        public bool Update(ReviewerDto entity)
        {
            var reviewerMap = _mapper.Map<Reviewer>(entity);

            var result = _reviewerRepository.UpdateReviewer(reviewerMap);
            if (result == null)
            {
                throw new Exception("Something went wrong please try again later");
            }
            return result;
        }
    }
}
