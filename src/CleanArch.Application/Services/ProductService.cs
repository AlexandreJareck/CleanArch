using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new ApplicationException($"Entity could not be loaded.");

            var result = await _mediator.Send(productsQuery);

            return MapperProducsDTOByEntities(result);
        }

        public async Task<ProductDTO> GetProduct(int? id)
        {
            return await GetById(id);
        }

        public async Task<ProductDTO> GetProductCategories(int? id)
        {
            return await GetById(id);
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null)
                throw new ApplicationException($"Enitty could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }

        private ProductDTO MapperProductDTOByEntity(Product? product)
        {
            return _mapper.Map<ProductDTO>(product);
        }

        private IEnumerable<ProductDTO> MapperProducsDTOByEntities(IEnumerable<Product?> products)
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        private async Task<ProductDTO> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new ApplicationException($"Entity could not be loaded.");

            var result = await _mediator.Send(productByIdQuery);

            return MapperProductDTOByEntity(result);
        }
    }
}