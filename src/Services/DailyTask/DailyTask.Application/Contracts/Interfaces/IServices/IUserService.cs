using DailyTask.Application.Dtos;
using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;
using DailyTask.Domain.Entities;

namespace DailyTask.Application.Contracts.Interfaces.IServices
{
    public interface IUserService
    {
        Task<IReadOnlyList<UserResponse>> GetAll(int take);
        Task<UserResponse> GetUserById(Guid id);
        Task<UserResponse> DeleteUser(Guid id, CancellationToken cancellationToken);
        Task<int> AddUser(CreateUserCommand createUserCommand, CancellationToken cancellationToken);
        Task<int> UpdateUser(UpdateUserCommand updateUserCommand, CancellationToken cancellationToken);

    }
}
