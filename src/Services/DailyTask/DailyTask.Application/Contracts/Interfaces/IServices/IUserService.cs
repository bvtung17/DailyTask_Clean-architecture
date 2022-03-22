﻿using DailyTask.Application.Dtos;
using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;
using DailyTask.Domain.Entities;

namespace DailyTask.Application.Contracts.Interfaces.IServices
{
    public interface IUserService
    {
        Task<IReadOnlyList<UserResponse>> GetAll(int take);
        Task<UserResponse> GetUserById(int id);
        Task<UserResponse> DeleteUser(int id);
        Task<int> AddUser(CreateUserCommand createUserCommand);
        Task<int> UpdateUser(UpdateUserCommand updateUserCommand);

    }
}
