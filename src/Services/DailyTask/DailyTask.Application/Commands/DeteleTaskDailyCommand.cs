using DailyTask.Application.Responses;
using MediatR;

namespace DailyTask.Application.Commands
{
    public class DeteleTaskDailyCommand : IRequest<TaskDailyResponse>
    {
        public int Id { get; set; }
        public DeteleTaskDailyCommand(int id)
        {
            Id = id;
        }
    }
}
