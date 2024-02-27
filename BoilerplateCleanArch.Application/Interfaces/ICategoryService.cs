using BoilerplateCleanArch.Application.DTOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Application.Interfaces
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
