using CleanArchMVC.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArchMVC.Application.Products.Queries
{
    public class GetProductsQueries : IRequest<IEnumerable<Product>>
    {
    }
}
