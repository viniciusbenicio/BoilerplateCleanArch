using BoilerplateCleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.Domain.Interfaces.IUserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetByIdAsync(int? id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> RemoveAsync(User user);
        void SaveToken(User user, string accessToken, DateTime? expiration);
        //void DeleteToken();
        Task<User> GetUserByAccessToken(string accessToken);
    }
}
