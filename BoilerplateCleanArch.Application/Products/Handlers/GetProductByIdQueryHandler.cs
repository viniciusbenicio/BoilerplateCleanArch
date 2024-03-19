using BoilerplateCleanArch.Application.Products.Queries;
using BoilerplateCleanArch.Domain.Entities;
using BoilerplateCleanArch.Domain.Interfaces.IProductRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
           return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
