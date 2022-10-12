using AutoMapper;
using Busines.Abstraction;
using Models;
using MoviesApp.Dto;
using MoviesApp.Interfaces;


namespace Busines.Implementation
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMovieRepository _movieRepository;

        public ReviewService(IReviewRepository reviewRepository,
            IMapper mapper,
            IMovieRepository movieRepository,
            IReviewerRepository reviewerRepository)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _reviewerRepository = reviewerRepository;
            _movieRepository = movieRepository;
        }

      


        public bool CreateReview(ReviewDto reviewCreate, int reviewerId, int movieId)
        {
            var reviews = _reviewRepository.GetReviews()
                 .Where(c => c.Title.Trim().ToUpper() == reviewCreate.Title.TrimEnd().ToUpper())
                 .FirstOrDefault();

         

            var reviewMap = _mapper.Map<Review>(reviewCreate);

            reviewMap.Movie = _movieRepository.GetMovie(movieId);

            reviewMap.Reviewer = _reviewerRepository.GetReviewer(reviewerId);


            var result = _reviewRepository.CreateReview(reviewMap);

            return result;
        }

        public bool Delete(int id)
        {
            var reviewToDelete = _reviewRepository.GetReview(id) ?? throw new Exception("no item with this id found");

            var result = _reviewRepository.DeleteReview(reviewToDelete);

            return result;
        }

        public ICollection<ReviewDto> GetAll()
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());
            if (reviews.Count() == 0)
            {
                throw new Exception("The list is empty");
            }
            return reviews;
        }

        public ReviewDto GetById(int id)
        {
            var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(id)) ?? throw new Exception("no movie found");
            return review;
        }

        public List<ReviewDto> GetReviewsOfaMovie(int movieId)
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewsOfAMovie((movieId)));
            if (reviews.Count() == 0)
            {
                throw new Exception("The list is empty");
            }
            return reviews;
        }

        public bool Update(ReviewDto entity)
        {
            var reviewMap = _mapper.Map<Review>(entity);

            var result = _reviewRepository.UpdateReview(reviewMap);
            if (result == null)
            {
                throw new Exception("Something went wrong please try again later");
            }
            return result;
        }
    }
}
