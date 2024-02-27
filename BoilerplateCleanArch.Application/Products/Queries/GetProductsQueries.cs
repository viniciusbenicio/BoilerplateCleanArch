using BoilerplateCleanArch.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace BoilerplateCleanArch.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
