using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Queries
{
    public class GetTaskDailyByIdQuery : IRequest<TaskDailyResponse>
    {
        public Guid Id { get; set; }
        public GetTaskDailyByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
