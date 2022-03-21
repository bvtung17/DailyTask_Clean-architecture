using AutoMapper;
using DailyTask.Application.Commands;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Application.Dtos;
using DailyTask.Application.Responses;
using DailyTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyTask.Application.Contracts.Services
{
    public class TaskDailyService : ITaskDailyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public TaskDailyService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<int> AddTask(CreateTaskDailyCommand request)
        {
            var taskDaily = _mapper.Map<TaskDaily>(request);
            var user = await _userService.GetUserById(request.UserId);
            if (user == null)
            {
                return 0;
            }
            taskDaily.User = user;
            await _unitOfWork.GetRepository<TaskDaily>().AddAsync(taskDaily);
            var rs = await _unitOfWork.SaveChangesAsync();
            return rs;
        }

        public async Task<int> DeleteTask(int id)
        {
            var taskDaily = await _unitOfWork.GetRepository<TaskDaily>().GetByIdAsync(id);
            _unitOfWork.GetRepository<TaskDaily>().Delete(taskDaily);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TaskDaily>> GetAll()
        {
            return await _unitOfWork.GetRepository<TaskDaily>().AsQueryable().ToListAsync();
        }

        public async Task<TaskDailyResponse> GetTaskById(int id)
        {
            var taskDaily = await _unitOfWork.GetRepository<TaskDaily>().GetByIdAsync(id);
            if (taskDaily == null)
            {
                return null;
            }
            return _mapper.Map<TaskDailyResponse>(taskDaily);
        }

        public async Task<int> UpdateTask(TaskDailyDto taskDailyDto)
        {
            var taskDaily = _mapper.Map<TaskDaily>(taskDailyDto);
            _unitOfWork.GetRepository<TaskDaily>().Update(taskDaily);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
