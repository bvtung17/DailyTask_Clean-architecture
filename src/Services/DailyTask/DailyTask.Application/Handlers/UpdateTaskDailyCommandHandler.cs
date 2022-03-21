using AutoMapper;
using DailyTask.Application.Commands;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Dtos;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Handlers
{
    public class UpdateTaskDailyCommandHandler : IRequestHandler<UpdateTaskDailyCommand, TaskDailyResponse>
    {
        private readonly ITaskDailyService _taskDailyService;
        private readonly IMapper _mapper;
        public UpdateTaskDailyCommandHandler(ITaskDailyService taskDailyService, IMapper mapper)
        {
            _taskDailyService = taskDailyService;
            _mapper = mapper;
        }
        public async Task<TaskDailyResponse> Handle(UpdateTaskDailyCommand request, CancellationToken cancellationToken)
        {
            var taskDto = _mapper.Map<TaskDailyDto>(request);
            var result = await _taskDailyService.UpdateTask(taskDto);
            if (result <= 0)
            {
                return null;
            }
            return _mapper.Map<TaskDailyResponse>(request);
        }
    }
}
