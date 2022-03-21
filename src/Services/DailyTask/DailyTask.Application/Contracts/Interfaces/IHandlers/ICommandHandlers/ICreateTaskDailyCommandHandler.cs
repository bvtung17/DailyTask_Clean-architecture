using DailyTask.Application.Commands;
using DailyTask.Application.Responses;

namespace DailyTask.Application.Contracts.Interfaces.IHandlers.ICommandHandlers
{
    public interface ICreateTaskDailyCommandHandler
    {
        TaskDailyResponse GetTaskDailyById(CreateTaskDailyCommand request);
    }
}
