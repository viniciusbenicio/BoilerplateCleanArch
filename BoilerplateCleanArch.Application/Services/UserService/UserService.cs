using AutoMapper;
using BoilerplateCleanArch.Application.DTOS.User;
using BoilerplateCleanArch.Application.Interfaces.IUserService;
using BoilerplateCleanArch.Domain.Entities;
using BoilerplateCleanArch.Domain.Interfaces.IUserRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDTO> GetById(int? Id)
        {
            var userEntity = await _userRepository.GetByIdAsync(Id);
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var usersEntity = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(usersEntity);
        }
        public async Task Add(UserDTO userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            await _userRepository.CreateAsync(userEntity);
        }
        public async Task Update(UserDTO userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            await _userRepository.UpdateAsync(userEntity);
        }
        public async Task Remove(int? Id)
        {
            var userEntity = _userRepository.GetByIdAsync(Id).Result;
            await _userRepository.RemoveAsync(userEntity);
        }
    }
}
