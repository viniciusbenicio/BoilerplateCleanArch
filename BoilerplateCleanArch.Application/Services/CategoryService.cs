using AutoMapper;
using BoilerplateCleanArch.Application.DTOS;
using BoilerplateCleanArch.Application.Interfaces;
using BoilerplateCleanArch.Domain.Entities;
using BoilerplateCleanArch.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetById(int? Id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(Id);

            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.UpdateAsync(categoryEntity);
        }

        public async Task Remove(int? Id)
        {
            var categoryEntity = _categoryRepository.GetByIdAsync(Id).Result;
            await _categoryRepository.RemoveAsync(categoryEntity);
        }

    }
}
