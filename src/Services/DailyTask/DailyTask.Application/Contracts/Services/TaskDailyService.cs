using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Application.Features.DailyTasks.Commands;
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
            var userResponse = await _userService.GetUserById(request.UserId);
            if (userResponse == null)
            {
                return 0;
            }
            var result = await _unitOfWork.GetRepository<TaskDaily>()
                .AddAsync(taskDaily);
            if (result == null)
            {
                return 0;
            }
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<TaskDailyResponse> DeleteTask(Guid id)
        {
            var taskDaily = await _unitOfWork.GetRepository<TaskDaily>()
                .GetByIdAsync(id);
            var result = _unitOfWork.GetRepository<TaskDaily>()
                .DeleteAsync(taskDaily);
            if (result == null)
            {
                return null;
            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TaskDailyResponse>(taskDaily);
        }

        public async Task<IReadOnlyList<TaskDailyResponse>> GetAll(int take)
        {
            if (take <= 0)
            {
                var taskDailies = await _unitOfWork.GetRepository<TaskDaily>()
                .GetAll();
                return _mapper.Map<List<TaskDailyResponse>>(taskDailies);
            }
            List<TaskDaily> listTaskDailies = await _unitOfWork.GetRepository<TaskDaily>()
                .AsQueryable()
                .Take(take)
                .ToListAsync();
            return _mapper.Map<List<TaskDailyResponse>>(listTaskDailies);
        }

        public async Task<TaskDailyResponse> GetTaskById(Guid id)
        {
            var taskDaily = await _unitOfWork.GetRepository<TaskDaily>()
                .GetByIdAsync(id);
            if (taskDaily == null)
            {
                return null;
            }
            return _mapper.Map<TaskDailyResponse>(taskDaily);
        }

        public async Task<IReadOnlyList<TaskDailyResponse>> GetTaskByUserId(Guid userId)
        {
            ///c1 Include
            var tasks = await _unitOfWork.GetRepository<TaskDaily>().AsQueryable()
                .Include(_ => _.User)
                .Where(_ => _.UserId == userId).ToListAsync();

            ///c2 Join
            var entity1 = _unitOfWork.GetRepository<TaskDaily>().AsQueryable();
            var entity2 = _unitOfWork.GetRepository<User>().AsQueryable();
            var res = await (from x in entity1
                             join y in entity2
                  on x.UserId equals y.Id
                             select x
                       ).Where(_ => _.UserId == userId).ToListAsync();

            ////c3
            var userResponse = await _userService.GetUserById(userId);
            if (userResponse == null)
            {
                return null;
            }
            var taskDailies = await _unitOfWork.GetRepository<TaskDaily>()
                .AsQueryable()
                .Where(_ => _.UserId == userId)
                .ToListAsync();
            return _mapper.Map<List<TaskDailyResponse>>(res);
        }

        public async Task<int> UpdateTask(UpdateTaskDailyCommand updateTaskDailyCommand)
        {
            var taskDaily = await _unitOfWork.GetRepository<TaskDaily>()
                .GetByIdAsync(updateTaskDailyCommand.Id);
            if (taskDaily == null)
            {
                return 0;
            }
            taskDaily = _mapper.Map(updateTaskDailyCommand, taskDaily);
            var result = _unitOfWork.GetRepository<TaskDaily>()
                .Update(taskDaily);
            if (result == null)
            {
                return 0;
            }
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
