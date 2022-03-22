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
        private readonly IMapper _mapper;
        public DeleteUserCommandHandler(IUserService userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }
        public async Task<UserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            UserResponse user = await _userServices.DeleteUser(request.Id);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserResponse>(user);
        }
    }
}