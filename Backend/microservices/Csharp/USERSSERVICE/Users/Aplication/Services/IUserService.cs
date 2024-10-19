using System.Collections.Generic;
using System.Threading.Tasks;
using UsersService.Users.Domain.Entities;

namespace UsersService.Users.Application.Services
{
    public interface IUserService
    {
        Task<User?> GetUserAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user, string plainPassword);
        Task UpdateUserAsync(User user, string? plainPassword = null);
        Task DeleteUserAsync(int id);
    }
}

