using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Commands
{
    public class DeleteTaskDailyCommand : IRequest<TaskDailyResponse>
    {
        public int Id { get; set; }
        public DeleteTaskDailyCommand(int id)
        {
            Id = id;
        }
    }
}
