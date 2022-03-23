using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Queries
{
    public class GetTaskDailyByUserIdQuery : IRequest<IReadOnlyList<TaskDailyResponse>>
    {
        public int UserId { get; set; }
        public GetTaskDailyByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
