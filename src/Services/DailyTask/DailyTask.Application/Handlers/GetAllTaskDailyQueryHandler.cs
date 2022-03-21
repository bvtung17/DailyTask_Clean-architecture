using DailyTask.Application.Queries;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Handlers
{
    public class GetAllTaskDailyQueryHandler : IRequestHandler<GetAllTaskDailyQuery, List<TaskDailyResponse>>
    {
        public Task<List<TaskDailyResponse>> Handle(GetAllTaskDailyQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
