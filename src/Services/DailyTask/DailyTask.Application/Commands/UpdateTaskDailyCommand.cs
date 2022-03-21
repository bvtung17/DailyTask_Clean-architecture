using DailyTask.Application.Responses;
using DailyTask.Domain.Common;
using MediatR;

namespace DailyTask.Application.Commands
{
    public class UpdateTaskDailyCommand : EntityBaseModel, IRequest<TaskDailyResponse>
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public Status Status { get; set; }
        public int UserId { get; set; }
    }
}