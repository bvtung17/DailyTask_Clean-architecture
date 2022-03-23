using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserResponse>
    {
        private readonly IUserService _userServices;
        public DeleteUserCommandHandler(IUserService userServices)
        {
            _userServices = userServices;
        }
        public async Task<UserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            UserResponse user = await _userServices.DeleteUser(request.Id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}