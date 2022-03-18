using AutoMapper;
using DailyTask.Application.Contracts.Core.Interfaces;
using DailyTask.Application.Contracts.Persistence;
using DailyTask.Application.Dtos;
using DailyTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTask.Application.Contracts.Core.Services
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
        public async Task<int> AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _unitOfWork.GetRepository<User>().AddAsync(user);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> DeleteUser(int id)
        {
            var user = await _unitOfWork.GetRepository<User>().GetByIdAsync(id);
            _unitOfWork.GetRepository<User>().Delete(user);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<User>> GetAll()
        {
            return await _unitOfWork.GetRepository<User>().AsQueryable().ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.GetRepository<User>().GetByIdAsync(id);
        }

        public async Task<int> UpdateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _unitOfWork.GetRepository<User>().Update(user);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
