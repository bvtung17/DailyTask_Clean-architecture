using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;

namespace DailyTask.Application.Contracts.Interfaces.IHandlers.ICommandHandlers
{
    public interface ICreateTaskDailyCommandHandler
    {
        TaskDailyResponse CreateTaskDaily(CreateTaskDailyCommand request);
    }
}
