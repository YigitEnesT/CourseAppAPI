using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICourseRepository Course{ get; }
        ICategoryRepository Category{ get; }
        IRatingRepository Rating{ get; }

        Task SaveAsync();
    }
}
