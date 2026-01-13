using Coink.Dtos;
using Coink.Interfaces;

namespace Coink.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(UserDto user)
        {
            await _userRepository.CreateUserAsync(user);
        }

        public async Task<IEnumerable<UserResponseDto>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
