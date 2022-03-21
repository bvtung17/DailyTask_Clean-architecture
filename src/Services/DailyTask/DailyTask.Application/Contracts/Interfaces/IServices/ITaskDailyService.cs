using DailyTask.Application.Commands;
using DailyTask.Application.Dtos;
using DailyTask.Application.Responses;
using DailyTask.Domain.Entities;

namespace DailyTask.Application.Contracts.Interfaces.IServices
{
    public interface ITaskDailyService
    {
        Task<IReadOnlyList<TaskDaily>> GetAll();
        Task<TaskDailyResponse> GetTaskById(int id);
        Task<int> DeleteTask(int id);
        Task<int> AddTask(CreateTaskDailyCommand request);
        Task<int> UpdateTask(TaskDailyDto taskDailyDto);
    }
}
