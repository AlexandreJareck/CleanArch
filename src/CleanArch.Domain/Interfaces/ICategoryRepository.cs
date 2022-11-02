using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync();

    Task<Category> GetByIdAsync(int? id);

    Task<Category> CreatedAsync(Category category);

    Task<Category> UpdateAsync(Category category);

    Task<Category> RemoveAsync(Category category);
}