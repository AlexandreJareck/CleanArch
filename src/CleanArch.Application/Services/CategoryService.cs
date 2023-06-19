using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();

            return MapperCategoriesDTOByEntity(categories);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            return MapperCategoryDTOByEntity(category);
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var category = MapperCategoryByDTO(categoryDTO);

            if (category != null)
                await _categoryRepository.CreatedAsync(category);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var category = MapperCategoryByDTO(categoryDTO);

            if (category != null)
                await _categoryRepository.UpdateAsync(category);
        }

        public async Task Remove(int id)
        {
            var category = _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.RemoveAsync(category);
        }

        private Category? MapperCategoryByDTO(CategoryDTO categoryDTO)
        {
            return _mapper.Map<Category>(categoryDTO);
        }

        private CategoryDTO MapperCategoryDTOByEntity(Category? category)
        {
            return _mapper.Map<CategoryDTO>(category);
        }

        private IEnumerable<CategoryDTO> MapperCategoriesDTOByEntity(IEnumerable<Category?> categories)
        {
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }
    }
}