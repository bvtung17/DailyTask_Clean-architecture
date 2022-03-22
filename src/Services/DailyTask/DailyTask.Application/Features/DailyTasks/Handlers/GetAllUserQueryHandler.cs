using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Features.DailyTasks.Queries;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Handlers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserResponse>>
    {
        private readonly IUserService _userServices;
        private readonly IMapper _mapper;
        public GetAllUserQueryHandler(IUserService userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }
        public async Task<List<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userServices.GetAll(request.Take);
            return _mapper.Map<List<UserResponse>>(users);
        }
    }
}
