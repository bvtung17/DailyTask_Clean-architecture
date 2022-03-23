using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Features.DailyTasks.Queries;
using DailyTask.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTask.Application.Features.DailyTasks.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IUserService _userServices;
        public GetUserByIdQueryHandler(IUserService userServices)
        {
            _userServices = userServices;
        }
        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userServices.GetUserById(request.Id);
        }
    }
}
