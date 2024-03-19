using AutoMapper;
using BoilerplateCleanArch.Application.DTOS.Product;
using BoilerplateCleanArch.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Application.Mappings
{
    public class DTOtoCommandMappingProfile : Profile
    {
        public DTOtoCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
