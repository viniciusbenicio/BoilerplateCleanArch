using AutoMapper;
using CleanArchMVC.Application.DTOS;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productEntity = await _productRepository.GetProductAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        }
        public async Task<ProductDTO> GetById(int? Id)
        {
            var productEntity = await _productRepository.GetByIdAsync(Id);
            return _mapper.Map<ProductDTO>(productEntity);
        }
        public async Task<ProductDTO> GetProductCategory(int? Id)
        {
            var productCategoryEntity = await _productRepository.GetProductCategoryAsync(Id);
            return _mapper.Map<ProductDTO>(productCategoryEntity);
        }
        public async Task Add(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(productEntity);
        }
        public async Task Update(ProductDTO productDTO)
        {

            var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateAsync(productEntity);
        }
        public async Task Remove(int? Id)
        {
            var productEntity = _productRepository.GetByIdAsync(Id).Result
            await _productRepository.RemoveAsync(productEntity);
        }

    }
}
