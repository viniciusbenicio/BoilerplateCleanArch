using AutoMapper;
using CleanArchMVC.Application.DTOS;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Services
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
                throw new ArgumentNullException($"Entity could not be loaded.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);

        }
        public async Task<ProductDTO> GetById(int? Id)
        {
            var productsByIdQuery = new GetProductByIdQuery(Id.Value);

            if (productsByIdQuery == null)
                throw new ArgumentNullException($"Entity could not be loaded.");

            var result = await _mediator.Send(productsByIdQuery);

            return _mapper.Map<ProductDTO>(result);

        }
        //public async Task<ProductDTO> GetProductCategory(int? Id)
        //{
        //    var productsByIdQuery = new GetProductByIdQuery(Id.Value);

        //    if (productsByIdQuery == null)
        //        throw new ArgumentNullException($"Entity could not be loaded.");

        //    var result = await _mediator.Send(productsByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}
        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }
        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }
        public async Task Remove(int? Id)
        {
            var productRemoveCommand = new ProductRemoveCommand(Id.Value);
            if (productRemoveCommand == null)
                throw new ArgumentNullException("Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);

        }

    }
}
