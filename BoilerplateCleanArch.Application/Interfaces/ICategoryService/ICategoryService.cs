using BoilerplateCleanArch.Application.DTOS.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Application.Interfaces.ICategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(int? Id);
        Task Add(CategoryDTO categoryDTO);
        Task Update(CategoryDTO categoryDTO);
        Task Remove(int? Id);
    }
}
