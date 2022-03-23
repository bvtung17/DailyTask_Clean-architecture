using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Features.DailyTasks.Queries;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Handlers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IReadOnlyList<UserResponse>>
    {
        private readonly IUserService _userServices;
        public GetAllUserQueryHandler(IUserService userServices)
        {
            _userServices = userServices;
        }
        public async Task<IReadOnlyList<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _userServices.GetAll(request.Take);
        }
    }
}
