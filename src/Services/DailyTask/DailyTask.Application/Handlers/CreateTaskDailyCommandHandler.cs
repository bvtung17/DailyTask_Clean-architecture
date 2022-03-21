using AutoMapper;
using DailyTask.Application.Commands;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Handlers
{
    public class CreateTaskDailyCommandHandler : IRequestHandler<CreateTaskDailyCommand, TaskDailyResponse>
    {
        private readonly ITaskDailyService _taskDailyService;
        private readonly IMapper _mapper;
        public CreateTaskDailyCommandHandler(ITaskDailyService taskDailyService, IMapper mapper)
        {
            _taskDailyService = taskDailyService;
            _mapper = mapper;
        }
        public async Task<TaskDailyResponse> Handle(CreateTaskDailyCommand request, CancellationToken cancellationToken)
        {
            var result = await _taskDailyService.AddTask(request);
            if (result <= 0)
            {
                return null;
            }
            return _mapper.Map<TaskDailyResponse>(request);
        }
    }
}
