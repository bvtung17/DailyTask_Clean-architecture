using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Queries
{
    public class GetTaskDailyByIdQuery : IRequest<TaskDailyResponse>
    {
        public int Id { get; set; }
        public GetTaskDailyByIdQuery(int id)
        {
            Id = id;
        }
    }
}
