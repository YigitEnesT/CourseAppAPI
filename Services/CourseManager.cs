using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CourseManager : ICourseService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CourseManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<CourseDto> CreateOneCourseAsync(CourseDtoForInsertion courseDto)
        {
            var entity = _mapper.Map<Course>(courseDto);
            _manager.Course.CreateOneCourse(entity);
            await _manager.SaveAsync();
            return _mapper.Map<CourseDto>(entity);
        }

        public async Task DeleteOneCourseAsync(int id, bool trackChanges)
        {
            var course = await _manager.Course.GetOneCourseByIdAsync(id,trackChanges);
            if(course is null)
                throw new CourseNotFoundException(id);

            _manager.Course.DeleteOneCourse(course);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync(bool trackChanges)
        {
            var courses = await _manager.Course.GetAllCoursesAsync(trackChanges);
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<CourseDto> GetOneCourseByIdAsync(int id, bool trackChanges)
        {
            var course = await _manager.Course.GetOneCourseByIdAsync(id, trackChanges);
            if(course is null)
                throw new CourseNotFoundException(id);
            return _mapper.Map<CourseDto>(course);
        }

        public async Task UpdateOneCourseAsync(int id, CourseDtoForUpdate courseDto, bool trackChanges)
        {
            var entity = await _manager.Course.GetOneCourseByIdAsync(id, trackChanges);
            if (entity is null)
                throw new CourseNotFoundException(id);

            _mapper.Map(courseDto, entity);
            _manager.Course.UpdateOneCourse(entity);
            await _manager.SaveAsync();
        }
    }
}
