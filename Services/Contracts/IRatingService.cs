using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IRatingService
    {
        public Task<(IEnumerable<RatingDto> ratings, MetaData metaData)> GetALlRatingsAsync(RatingParameters ratingParameters,bool trackChanges);
        public Task<(IEnumerable<RatingDto> ratings, MetaData metaData)> GetAllRatingsByCourseAsync(RatingParameters ratingParameters ,int id, bool trackChanges);
        public Task<RatingDto> CreateOneRatingAsync(RatingDto rating);
    }
}
