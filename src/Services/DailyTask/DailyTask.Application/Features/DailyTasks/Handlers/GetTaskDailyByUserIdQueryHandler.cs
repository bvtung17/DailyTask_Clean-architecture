using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Features.DailyTasks.Queries;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Handlers
{
    public class GetTaskDailyByUserIdQueryHandler : IRequestHandler<GetTaskDailyByUserIdQuery, IReadOnlyList<TaskDailyResponse>>
    {
        private readonly ITaskDailyService _taskDailyService;
        public GetTaskDailyByUserIdQueryHandler(ITaskDailyService taskDailyService)
        {
            _taskDailyService = taskDailyService;
        }

        public async Task<IReadOnlyList<TaskDailyResponse>> Handle(GetTaskDailyByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _taskDailyService.GetTaskByUserId(request.UserId);
        }
    }
}

