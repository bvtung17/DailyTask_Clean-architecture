using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Commands
{
    public class DeleteTaskDailyCommand : IRequest<TaskDailyResponse>
    {
        public Guid Id { get; set; }
        public DeleteTaskDailyCommand(Guid id)
        {
            Id = id;
        }
    }
}
