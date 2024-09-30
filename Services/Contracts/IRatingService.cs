using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IRatingService
    {
        public Task<IEnumerable<RatingDto>> GetALlRatingsAsync(bool trackChanges);
        public Task<IEnumerable<RatingDto>> GetAllRatingsByCourseAsync(int id, bool trackChanges);
        public Task<RatingDto> CreateOneRatingAsync(RatingDto rating);
    }
}
