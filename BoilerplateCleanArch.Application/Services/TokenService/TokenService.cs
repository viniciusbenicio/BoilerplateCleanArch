using AutoMapper;
using BoilerplateCleanArch.Application.DTOS.User;
using BoilerplateCleanArch.Application.Interfaces.ITokenService;
using BoilerplateCleanArch.Domain.Entities;
using BoilerplateCleanArch.Domain.Interfaces.IUserRepository;
using BoilerplateCleanArch.Domain.Interfaces.IUserRepository.ITokenRepository;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Application.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IMapper _mapper;
        public TokenService(ITokenRepository tokenRepository, IMapper mapper)
        {
            _tokenRepository = tokenRepository;
            _mapper = mapper;
        }
        public User GenerateJWT(UserDTO userDTO)
        {
            var tokenEntity = _mapper.Map<User>(userDTO);
            return  _tokenRepository.GenerateJWT(tokenEntity);
        }
    }
}
