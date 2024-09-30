using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRatingRepository : IRepositoryBase<Rating>
    {
        Task<IEnumerable<Rating>> GetAllRatingsAsync(bool trackChanges);
        Task<IEnumerable<Rating>> GetRatingByCourseAsync(int courseId, bool trackChanges);
        void CreateOneRating(Rating rating);
    }
}
