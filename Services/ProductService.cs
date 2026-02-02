using AutoMapper;
using DTOs;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository repository;
        IMapper mapper;
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;  
        }

        public async Task<List<ProductDTO>> GetProducts(int[]? categoryId, int? minPrice, int? maxPrice, int? limit, int? page)
        {
            List<Product> product = await repository.GetProducts(categoryId, minPrice, maxPrice, limit, page);
            List<ProductDTO> ProductDTO = mapper.Map<List<Product>, List<ProductDTO> >(product);
            return ProductDTO;
        }
    }
}
