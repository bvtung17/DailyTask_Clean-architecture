using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Commands
{
    public class DeleteUserCommand : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
