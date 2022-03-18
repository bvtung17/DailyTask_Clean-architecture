using DailyTask.Application.Dtos;
using DailyTask.Domain.Entities;

namespace DailyTask.Application.Contracts.Core.Interfaces
{
    public interface ITaskDailyService
    {
        Task<IReadOnlyList<TaskDaily>> GetAll();
        Task<TaskDaily> GetTaskById(int id);
        Task<int> DeleteTask(int id);
        Task<int> AddTask(TaskDailyDto taskDailyDto);
        Task<int> UpdateTask(TaskDailyDto taskDailyDto);
    }
}
