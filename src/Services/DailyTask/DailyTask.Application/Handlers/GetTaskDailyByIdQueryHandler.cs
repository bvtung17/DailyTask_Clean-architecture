using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Queries;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Handlers
{
    public class GetTaskDailyByIdQueryHandler : IRequestHandler<GetTaskDailyByIdQuery, TaskDailyResponse>
    {
        private readonly ITaskDailyService _taskDailyService;
        public GetTaskDailyByIdQueryHandler(ITaskDailyService taskDailyService)
        {
            _taskDailyService = taskDailyService;
        }
        public async Task<TaskDailyResponse> Handle(GetTaskDailyByIdQuery request, CancellationToken cancellationToken)
        {
            return await _taskDailyService.GetTaskById(request.Id);
        }
    }
}
