using DailyTask.Application.Features.DailyTasks.Handlers;
using DailyTask.Application.Responses;

namespace DailyTask.Application.Contracts.Interfaces.IHandlers.IQueryHandlers
{
    public interface IGetUserByIdQueryHandler
    {
        UserResponse GetUserById(GetUserByIdQueryHandler request);
    }
}
