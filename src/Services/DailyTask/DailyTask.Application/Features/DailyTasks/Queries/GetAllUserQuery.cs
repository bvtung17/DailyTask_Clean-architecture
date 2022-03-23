using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Queries
{
    public class GetAllUserQuery : IRequest<IReadOnlyList<UserResponse>>
    {
        public int Take { get; set; }
        public GetAllUserQuery(int take)
        {
            Take = take;
        }
    }
}
