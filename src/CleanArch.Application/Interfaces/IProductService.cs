using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();

        Task<ProductDTO> GetProduct(int? id);

        Task<ProductDTO> GetProductCategories(int? id);

        Task Add(ProductDTO productDTO);

        Task Update(ProductDTO productDTO);

        Task Remove(int? id);
    }
}