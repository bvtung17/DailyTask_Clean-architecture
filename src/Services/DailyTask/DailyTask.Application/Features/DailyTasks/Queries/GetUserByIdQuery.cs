using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Queries
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
