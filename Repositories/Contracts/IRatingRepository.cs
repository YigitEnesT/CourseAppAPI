using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRatingRepository : IRepositoryBase<Rating>
    {
        Task<PagedList<Rating>> GetAllRatingsAsync(RatingParameters ratingParameters,bool trackChanges);
        Task<PagedList<Rating>> GetRatingByCourseAsync(RatingParameters ratingParameters ,int courseId, bool trackChanges);
        void CreateOneRating(Rating rating);
    }
}
