using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;

namespace DailyTask.Application.Contracts.Interfaces.IServices
{
    public interface ITaskDailyService
    {
        Task<IReadOnlyList<TaskDailyResponse>> GetAll(int take);
        Task<TaskDailyResponse> GetTaskById(Guid id);
        Task<IReadOnlyList<TaskDailyResponse>> GetTaskByUserId(Guid userId);
        Task<TaskDailyResponse> DeleteTask(Guid id, CancellationToken cancellationToken);
        Task<int> AddTask(CreateTaskDailyCommand request, CancellationToken cancellationToken);
        Task<int> UpdateTask(UpdateTaskDailyCommand updateTaskDailyCommand, CancellationToken cancellationToken);
    }
}
