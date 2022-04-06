using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Features.DailyTasks.Handlers
{
    public class DeleteTaskDailyCommandHandler : IRequestHandler<DeleteTaskDailyCommand, TaskDailyResponse>
    {
        private readonly ITaskDailyService _taskDailyService;
        public DeleteTaskDailyCommandHandler(ITaskDailyService taskDailyService)
        {
            _taskDailyService = taskDailyService;
        }
        public async Task<TaskDailyResponse> Handle(DeleteTaskDailyCommand request, CancellationToken cancellationToken)
        {
            TaskDailyResponse taskDaily = await _taskDailyService.DeleteTask(request.Id);
            if (taskDaily == null)
            {
                return null;
            }
            return taskDaily;
        }
    }
}
