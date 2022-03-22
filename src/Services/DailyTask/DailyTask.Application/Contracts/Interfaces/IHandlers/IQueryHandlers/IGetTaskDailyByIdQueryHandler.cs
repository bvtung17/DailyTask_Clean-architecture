using DailyTask.Application.Features.DailyTasks.Queries;
using DailyTask.Application.Responses;

namespace DailyTask.Application.Interfaces.IQueryHandlers
{
    public interface IGetTaskDailyByIdQueryHandler
    {
        TaskDailyResponse GetTaskDailyById(GetTaskDailyByIdQuery request);
    }
}
