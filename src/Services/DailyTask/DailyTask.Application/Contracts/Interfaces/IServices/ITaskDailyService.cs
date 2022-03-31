using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;

namespace DailyTask.Application.Contracts.Interfaces.IServices
{
    public interface ITaskDailyService
    {
        Task<IReadOnlyList<TaskDailyResponse>> GetAll(int take);
        Task<TaskDailyResponse> GetTaskById(Guid id);
        Task<IReadOnlyList<TaskDailyResponse>> GetTaskByUserId(Guid userId);
        Task<TaskDailyResponse> DeleteTask(Guid id);
        Task<int> AddTask(CreateTaskDailyCommand request);
        Task<int> UpdateTask(UpdateTaskDailyCommand updateTaskDailyCommand);
    }
}
