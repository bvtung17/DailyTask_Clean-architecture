using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;

namespace DailyTask.Application.Contracts.Interfaces.IServices
{
    public interface ITaskDailyService
    {
        Task<IReadOnlyList<TaskDailyResponse>> GetAll(int take);
        Task<TaskDailyResponse> GetTaskById(int id);
        Task<TaskDailyResponse> DeleteTask(int id);
        Task<int> AddTask(CreateTaskDailyCommand request);
        Task<int> UpdateTask(UpdateTaskDailyCommand updateTaskDailyCommand);
    }
}
