using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly ICourseRepository _courseRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRatingRepository _ratingRepository;
        public RepositoryManager(RepositoryContext context, ICourseRepository courseRepositoy, ICategoryRepository categoryRepository, IRatingRepository ratingRepository)
        {
            _context = context;
            _courseRepository = courseRepositoy;
            _categoryRepository = categoryRepository;
            _ratingRepository = ratingRepository;
        }

        public ICourseRepository Course => _courseRepository;

        public ICategoryRepository Category => _categoryRepository;

        public IRatingRepository Rating => _ratingRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
