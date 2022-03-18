namespace DailyTask.Application.Contracts.Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync();
        Task<bool> AuthenticateAsync(string username, string password);
        Task<bool> Register();
    }
}
