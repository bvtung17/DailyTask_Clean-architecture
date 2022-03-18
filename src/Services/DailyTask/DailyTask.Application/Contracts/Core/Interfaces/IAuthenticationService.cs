using DailyTask.Application.Dtos;

namespace DailyTask.Application.Contracts.Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string username, string password);
        Task<int> Register(UserDto userDto);
    }
}
