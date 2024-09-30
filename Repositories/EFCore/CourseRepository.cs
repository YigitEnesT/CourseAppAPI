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
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCourse(Course course) => Create(course);
        public void DeleteOneCourse(Course course) => Delete(course);
        public async Task<IEnumerable<Course>> GetAllCoursesAsync(bool trackChanges) => 
            await GetAll(trackChanges)
            .Include(c => c.Ratings)
            .Include(c => c.Category)
            .Where(c => c.Ratings.Any(r => r.CourseId.Equals(c.Id)))
            .OrderBy(c => c.Id)
            .ToListAsync();

        public async Task<Course> GetOneCourseByIdAsync (int id, bool trackChanges) => 
             await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .Include(c => c.Ratings)
            .Include(c => c.Category)
            .SingleOrDefaultAsync();
        public void UpdateOneCourse(Course course) => Update(course);
    }
}
