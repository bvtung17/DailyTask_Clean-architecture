using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Handlers
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
            int result = await _taskDailyService.UpdateTask(request);
            if (result <= 0)
            {
                return null;
            }
            return _mapper.Map<TaskDailyResponse>(request);
        }
    }
}
