using BoilerplateCleanArch.Application.Products.Commands;
using BoilerplateCleanArch.Domain.Entities;
using BoilerplateCleanArch.Domain.Interfaces.IProductRepository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

            if (product == null)
                throw new ApplicationException($"Erro creating entity");
            else
            {
                product.CategoryId = request.CategoryId;
                return await _productRepository.CreateAsync(product);
            }
        }
    }
}
