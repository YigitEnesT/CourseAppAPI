using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync(bool trackChanges);
        Task<Course> GetOneCourseByIdAsync(int id, bool trackChanges);
        void CreateOneCourse(Course course);
        void UpdateOneCourse(Course course);
        void DeleteOneCourse(Course course);
    }
}
