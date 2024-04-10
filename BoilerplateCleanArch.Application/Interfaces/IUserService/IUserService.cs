using BoilerplateCleanArch.Application.DTOS.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Application.Interfaces.IUserService
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<UserDTO> GetById(int? Id);
        Task Add(UserDTO userDTO);
        Task Update(UserDTO userDTO);
        Task Remove(int? Id);
    }
}
