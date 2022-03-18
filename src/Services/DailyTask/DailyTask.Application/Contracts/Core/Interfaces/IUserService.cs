using DailyTask.Application.Dtos;
using DailyTask.Domain.Entities;

namespace DailyTask.Application.Contracts.Core.Interfaces
{
    public interface IUserService
    {
        Task<IReadOnlyList<User>> GetAll();
        Task<User> GetUserById(int id);
        Task<int> DeleteUser(int id);
        Task<int> AddUser(UserDto userDto);
        Task<int> UpdateUser(UserDto userDto);

    }
}
