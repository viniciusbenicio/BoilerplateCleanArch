using BoilerplateCleanArch.Application.DTOS.User;
using BoilerplateCleanArch.Domain.Entities;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Application.Interfaces.ITokenService
{
    public interface ITokenService
    {
        User GenerateJWT(UserDTO userDTO);
    }
}
