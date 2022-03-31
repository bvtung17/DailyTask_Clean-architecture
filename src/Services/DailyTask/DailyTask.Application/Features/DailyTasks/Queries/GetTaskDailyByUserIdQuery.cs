using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Queries
{
    public class GetTaskDailyByUserIdQuery : IRequest<IReadOnlyList<TaskDailyResponse>>
    {
        public Guid UserId { get; set; }
        public GetTaskDailyByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
