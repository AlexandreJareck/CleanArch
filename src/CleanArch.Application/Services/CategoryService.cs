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

            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);

            await _categoryRepository.CreatedAsync(category);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);

            await _categoryRepository.UpdateAsync(category);
        }

        public async Task Remove(int id)
        {
            var category = _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.RemoveAsync(category);
        }
    }
}