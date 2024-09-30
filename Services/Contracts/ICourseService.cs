using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync(bool trackChanges);
        Task<CourseDto> GetOneCourseByIdAsync(int id, bool trackChanges);
        Task<CourseDto> CreateOneCourseAsync(CourseDtoForInsertion courseDto);
        Task UpdateOneCourseAsync(int id, CourseDtoForUpdate course, bool trackChanges);
        Task DeleteOneCourseAsync(int id, bool trackChanges);
    }
}
