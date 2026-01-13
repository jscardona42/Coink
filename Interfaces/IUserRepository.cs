using Coink.Dtos;
using System.Threading.Tasks;

namespace Coink.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(UserDto user);
        Task<IEnumerable<UserResponseDto>> GetUsersAsync();
    }

}
