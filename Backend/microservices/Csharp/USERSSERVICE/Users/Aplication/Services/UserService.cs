using Microsoft.AspNetCore.Identity;
using UsersService.Users.Domain.Entities;
using UsersService.Users.Domain.Repositories;

namespace UsersService.Users.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _passwordHasher = new PasswordHasher<User>(); // Usado para hashear contraseñas
        }

        public async Task<User?> GetUserAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task AddUserAsync(User user, string plainPassword)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, plainPassword);
            await _userRepository.AddUserAsync(user);
        }


        public async Task UpdateUserAsync(User user, string? plainPassword = null)
        {
            if (!string.IsNullOrEmpty(plainPassword))
            {
                user.PasswordHash = _passwordHasher.HashPassword(user, plainPassword);
            }
            await _userRepository.UpdateUserAsync(user);
            
            // No es necesario retornar nada, ya que tu método devuelve Task
        }


        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteUserAsync(user);
            }
        }
    }
}

