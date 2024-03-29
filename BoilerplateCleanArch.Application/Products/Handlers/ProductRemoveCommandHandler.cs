﻿using BoilerplateCleanArch.Application.Products.Commands;
using BoilerplateCleanArch.Domain.Entities;
using BoilerplateCleanArch.Domain.Interfaces.IProductRepository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);


            if (product == null)
                throw new ApplicationException($"Entity could not be found");
            else
            {
                var result = await _productRepository.RemoveAsync(product);
                return result;
            }
        }
    }
}
