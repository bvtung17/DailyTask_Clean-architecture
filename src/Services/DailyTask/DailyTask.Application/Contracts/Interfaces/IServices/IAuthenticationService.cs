using DailyTask.Application.Dtos;
using DailyTask.Application.Requests;

namespace DailyTask.Application.Contracts.Interfaces.IServices
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginUserRequest request);
        Task<int> Register(UserDto userDto);
    }
}
