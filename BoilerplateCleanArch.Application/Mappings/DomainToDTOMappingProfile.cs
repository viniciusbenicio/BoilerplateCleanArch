using AutoMapper;
using BoilerplateCleanArch.Application.DTOS.Category;
using BoilerplateCleanArch.Application.DTOS.Product;
using BoilerplateCleanArch.Domain.Entities;

namespace BoilerplateCleanArch.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
