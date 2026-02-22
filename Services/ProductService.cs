using AutoMapper;
using DTOs;
using Entities;
using Repositories;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetProducts(int[]? categoryId, int? minPrice, int? maxPrice, int? limit, int? page)
        {
            List<Product> product = await _repository.GetProducts(categoryId, minPrice, maxPrice, limit, page);
            List<ProductDTO> productDTO = _mapper.Map<List<Product>, List<ProductDTO>>(product);
            return productDTO;
        }
    }
}
