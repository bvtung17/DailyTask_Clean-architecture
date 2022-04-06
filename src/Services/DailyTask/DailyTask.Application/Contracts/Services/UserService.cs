using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;
using DailyTask.Domain.Entities;

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
        public async Task<int> AddUser(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(createUserCommand);
            var result = await _unitOfWork.GetRepository<User>()
                .AddAsync(user);
            if (result == null)
            {
                return 0;
            }
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<UserResponse> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.GetRepository<User>()
                .GetByIdAsync(id);
            var result = _unitOfWork.GetRepository<User>()
                .DeleteAsync(user);
            if (result == null)
            {
                return null;
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<IReadOnlyList<UserResponse>> GetAll(int take)
        {
            if (take <= 0)
            {
                var users = await _unitOfWork.GetRepository<User>()
                    .GetAll();
                return _mapper.Map<List<UserResponse>>(users);
            }
            var userTakes = await _unitOfWork.GetRepository<User>()
                .GetAll();
            userTakes = userTakes.Take(take).ToList();
            return _mapper.Map<List<UserResponse>>(userTakes);
        }

        public async Task<UserResponse> GetUserById(Guid id)
        {
            var user = await _unitOfWork.GetRepository<User>().GetByIdAsync(id);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<int> UpdateUser(UpdateUserCommand updateUserCommand, CancellationToken cancellationToken)
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
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
