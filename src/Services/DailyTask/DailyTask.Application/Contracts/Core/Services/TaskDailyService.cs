using AutoMapper;
using DailyTask.Application.Contracts.Core.Interfaces;
using DailyTask.Application.Contracts.Persistence;
using DailyTask.Application.Dtos;
using DailyTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTask.Application.Contracts.Core.Services
{
    public class TaskDailyService : ITaskDailyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TaskDailyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> AddTask(TaskDailyDto taskDailyDto)
        {
            var taskDaily = _mapper.Map<TaskDaily>(taskDailyDto);
            await _unitOfWork.GetRepository<TaskDaily>().AddAsync(taskDaily);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> DeleteTask(int id)
        {
            var taskDaily = await _unitOfWork.GetRepository<TaskDaily>().GetByIdAsync(id);
            _unitOfWork.GetRepository<TaskDaily>().Delete(taskDaily);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TaskDaily>> GetAll()
        {
            return await _unitOfWork.GetRepository<TaskDaily>().GetAllAsync();
        }

        public async Task<TaskDaily> GetTaskById(int id)
        {
            return await _unitOfWork.GetRepository<TaskDaily>().GetByIdAsync(id);
        }

        public async Task<int> UpdateTask(TaskDailyDto taskDailyDto)
        {
            var taskDaily = _mapper.Map<TaskDaily>(taskDailyDto);
            _unitOfWork.GetRepository<TaskDaily>().Update(taskDaily);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
