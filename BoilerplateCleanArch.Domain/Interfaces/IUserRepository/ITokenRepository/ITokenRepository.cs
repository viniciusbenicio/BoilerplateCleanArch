using BoilerplateCleanArch.Domain.Entities;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Domain.Interfaces.IUserRepository.ITokenRepository
{
    public interface ITokenRepository
    {
        User GenerateJWT(User user);
    }
}
