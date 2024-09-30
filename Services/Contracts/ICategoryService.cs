using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);
    }
}
