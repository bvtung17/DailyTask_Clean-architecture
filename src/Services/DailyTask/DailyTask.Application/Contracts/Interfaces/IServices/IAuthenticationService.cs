using DailyTask.Application.Dtos;

namespace DailyTask.Application.Contracts.Interfaces.IServices
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string username, string password);
        Task<int> Register(UserDto userDto);
    }
}
