using AutoMapper;
using DailyTask.Application.Commands;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Handlers
{
    public class DeleteTaskDailyCommandHandler : IRequestHandler<DeteleTaskDailyCommand, TaskDailyResponse>
    {
        private readonly ITaskDailyService _taskDailyService;
        private readonly IMapper _mapper;
        public DeleteTaskDailyCommandHandler(ITaskDailyService taskDailyService, IMapper mapper)
        {
            _taskDailyService = taskDailyService;
            _mapper = mapper;
        }
        public async Task<TaskDailyResponse> Handle(DeteleTaskDailyCommand request, CancellationToken cancellationToken)
        {
            var result = await _taskDailyService.DeleteTask(request.Id);
            if (result <= 0)
            {
                return null;
            }
            return _mapper.Map<TaskDailyResponse>(request);
        }
    }
}
