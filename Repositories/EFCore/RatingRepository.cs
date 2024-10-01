using Entities.Models;
using Entities.RequestFeatures;
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

        public async Task<PagedList<Rating>> GetAllRatingsAsync(RatingParameters ratingParameters ,bool trackChanges)
        {
            var ratings = await GetAll(trackChanges)
                .ToListAsync();

            return PagedList<Rating>
                .ToPagedList(ratings, ratingParameters.pageNumber, ratingParameters.PageSize);
        }

        public async Task<PagedList<Rating>> GetRatingByCourseAsync(RatingParameters ratingParameters ,int courseId, bool trackChanges)
        {
            var ratings = await FindByCondition(c => c.CourseId == courseId, trackChanges)
                .ToListAsync();

            return PagedList<Rating>
                .ToPagedList(ratings, ratingParameters.pageNumber, ratingParameters.PageSize);
        }
    }
}
