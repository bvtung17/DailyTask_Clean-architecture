using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserResponse>
    {
        private readonly IUserService _userServices;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IUserService userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }
        public async Task<UserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            int result = await _userServices.UpdateUser(request, cancellationToken);
            if (result <= 0)
            {
                return null;
            }
            return _mapper.Map<UserResponse>(request);
        }
    }
}
