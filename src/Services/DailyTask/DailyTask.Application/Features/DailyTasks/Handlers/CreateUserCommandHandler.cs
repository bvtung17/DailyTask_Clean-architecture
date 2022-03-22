﻿using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IUserService _userServices;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserService userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }
        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            int result = await _userServices.AddUser(request);
            if (result <= 0)
            {
                return null;
            }
            return _mapper.Map<UserResponse>(request);
        }
    }
}