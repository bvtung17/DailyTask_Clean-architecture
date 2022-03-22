using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Queries
{
    public class GetAllTaskDailyQuery : IRequest<List<TaskDailyResponse>>
    {
        public int Take { get; set; }
        public GetAllTaskDailyQuery(int take)
        {
            Take = take;
        }
    }
}
