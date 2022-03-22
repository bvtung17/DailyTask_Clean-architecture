using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Features.DailyTasks.Queries;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Handlers
{
    public class GetAllTaskDailyQueryHandler : IRequestHandler<GetAllTaskDailyQuery, List<TaskDailyResponse>>
    {
        private readonly ITaskDailyService _taskDailyService;
        private readonly IMapper _mapper;
        public GetAllTaskDailyQueryHandler(ITaskDailyService taskDailyService, IMapper mapper)
        {
            _taskDailyService = taskDailyService;
            _mapper = mapper;
        }
        public async Task<List<TaskDailyResponse>> Handle(GetAllTaskDailyQuery request, CancellationToken cancellationToken)
        {
            var taskDailies = await _taskDailyService.GetAll(request.Take);
            return _mapper.Map<List<TaskDailyResponse>>(taskDailies);
        }
    }
}
