using DailyTask.Application.Responses;
using DailyTask.Domain.Common;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Commands
{
    public class CreateUserCommand : EntityBase, IRequest<UserResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
