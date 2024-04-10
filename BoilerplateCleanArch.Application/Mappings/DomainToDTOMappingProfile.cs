using AutoMapper;
using BoilerplateCleanArch.Application.DTOS.User;
using BoilerplateCleanArch.Domain.Entities;

namespace BoilerplateCleanArch.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
