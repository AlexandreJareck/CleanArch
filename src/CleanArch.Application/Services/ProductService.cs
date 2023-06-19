using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ??
                throw new ArgumentException(nameof(productRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();

            return MapperProducsDTOByEntities(products);
        }

        public async Task<ProductDTO> GetProduct(int? id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            return MapperProductDTOByEntity(product);
        }

        public async Task<ProductDTO> GetProductCategories(int? id)
        {
            var product = await _productRepository.GetProductCategoryAsync(id);

            return MapperProductDTOByEntity(product);
        }

        public async Task Add(ProductDTO productDTO)
        {
            var product = MapperProductByDTO(productDTO);

            if (product != null)
                await _productRepository.CreatedAsync(product);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var product = MapperProductByDTO(productDTO);

            if (product != null)
                await _productRepository.UpdateAsync(product);
        }

        public async Task Remove(int? id)
        {
            var product = _productRepository.GetByIdAsync(id).Result;
            await _productRepository.RemoveAsync(product);
        }

        private Product? MapperProductByDTO(ProductDTO productDTO)
        {
            return _mapper.Map<Product>(productDTO);
        }

        private ProductDTO MapperProductDTOByEntity(Product? product)
        {
            return _mapper.Map<ProductDTO>(product);
        }

        private IEnumerable<ProductDTO> MapperProducsDTOByEntities(IEnumerable<Product?> products)
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}