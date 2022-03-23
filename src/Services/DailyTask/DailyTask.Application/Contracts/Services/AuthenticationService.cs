using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Application.Dtos;
using DailyTask.Application.Requests;
using DailyTask.Domain.Common;
using DailyTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyTask.Application.Contracts.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AuthenticateAsync(LoginUserRequest request)
        {
            string passwordHash = CreatePasswordMD5.GenerateHash(request.Password);
            User user = await _unitOfWork.GetRepository<User>()
                .AsQueryable()
                .Where(_ => _.UserName == request.UserName)
                .SingleOrDefaultAsync();
            if (user is null)
            {
                return false;
            }
            bool resulf = user.Password == passwordHash ? true : false;
            return resulf;
        }

        public async Task<int> Register(UserDto userDto)
        {
            userDto.Password = CreatePasswordMD5.GenerateHash(userDto.Password);
            User user = _mapper.Map<User>(userDto);
            await _unitOfWork.GetRepository<User>().AddAsync(user);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
