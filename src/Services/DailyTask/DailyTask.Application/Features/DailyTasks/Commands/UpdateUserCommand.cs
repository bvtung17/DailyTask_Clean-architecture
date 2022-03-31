using DailyTask.Application.Requests;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Commands
{
    public class UpdateUserCommand : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
