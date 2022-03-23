using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Features.DailyTasks.Queries;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Handlers
{
    public class GetAllTaskDailyQueryHandler : IRequestHandler<GetAllTaskDailyQuery, IReadOnlyList<TaskDailyResponse>>
    {
        private readonly ITaskDailyService _taskDailyService;
        public GetAllTaskDailyQueryHandler(ITaskDailyService taskDailyService)
        {
            _taskDailyService = taskDailyService;
        }
        public async Task<IReadOnlyList<TaskDailyResponse>> Handle(GetAllTaskDailyQuery request, CancellationToken cancellationToken)
        {
            return await _taskDailyService.GetAll(request.Take);
        }
    }
}
