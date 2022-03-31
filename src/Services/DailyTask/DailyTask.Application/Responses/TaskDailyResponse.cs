using DailyTask.Domain.Common;

namespace DailyTask.Application.Responses
{
    public class TaskDailyResponse : EntityBase
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public Status Status { get; set; }
        public Guid UserId { get; set; }
        public UserResponse UserResponse { get; set; }
    }
}