using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
        public RatingRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneRating(Rating rating)
        {
            Create(rating);
        }

        public async Task<IEnumerable<Rating>> GetAllRatingsAsync(bool trackChanges)
        {
            return await GetAll(trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<Rating>> GetRatingByCourseAsync(int courseId, bool trackChanges)
        {
            return await FindByCondition(c => c.CourseId == courseId, trackChanges)
                .ToListAsync();
        }
    }
}
