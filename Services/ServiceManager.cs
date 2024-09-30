using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICourseService _courseService;
        private readonly IRatingService _ratingService;
        private readonly ICategoryService _categoryService;

        public ServiceManager(ICourseService coursesService, ICategoryService categoryService, IRatingService ratingService)
        {
            _courseService = coursesService;
            _categoryService = categoryService;
            _ratingService = ratingService;
        }

        public ICourseService CourseService => _courseService;

        public ICategoryService CategoryService => _categoryService;

        public IRatingService RatingService => _ratingService;
    }
}
