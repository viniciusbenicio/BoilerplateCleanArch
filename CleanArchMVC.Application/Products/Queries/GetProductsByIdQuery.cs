using CleanArchMVC.Domain.Entities;
using MediatR;

namespace CleanArchMVC.Application.Products.Queries
{
    public class GetProductsByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public GetProductsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
