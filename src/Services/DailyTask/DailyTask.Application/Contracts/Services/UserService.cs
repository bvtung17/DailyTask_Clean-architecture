using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;
using DailyTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyTask.Application.Contracts.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> AddUser(CreateUserCommand createUserCommand)
        {
            var user = _mapper.Map<User>(createUserCommand);
            var result = await _unitOfWork.GetRepository<User>()
                .AddAsync(user);
            if (result == null)
            {
                return 0;
            }
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserResponse> DeleteUser(int id)
        {
            var user = await _unitOfWork.GetRepository<User>()
                .GetByIdAsync(id);
            var result = _unitOfWork.GetRepository<User>()
                .DeleteAsync(user);
            if (result == null)
            {
                return null;
            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<IReadOnlyList<UserResponse>> GetAll(int take)
        {
            List<User> users = new List<User>();
            if (take <= 0)
            {
                users = await _unitOfWork.GetRepository<User>()
                    .AsQueryable()
                    .ToListAsync();
                return _mapper.Map<List<UserResponse>>(users);
            }
            users = await _unitOfWork.GetRepository<User>()
                .AsQueryable()
                .Take(take)
                .ToListAsync();
            return _mapper.Map<List<UserResponse>>(users);
        }

        public async Task<UserResponse> GetUserById(int id)
        {
            var user = await _unitOfWork.GetRepository<User>().GetByIdAsync(id);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<int> UpdateUser(UpdateUserCommand updateUserCommand)
        {
            var user = await _unitOfWork.GetRepository<User>()
                .GetByIdAsync(updateUserCommand.Id);
            if (user == null)
            {
                return 0;
            }
            user = _mapper.Map(updateUserCommand, user);
            var result = _unitOfWork.GetRepository<User>()
                .Update(user);
            if (result == null)
            {
                return 0;
            }
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
