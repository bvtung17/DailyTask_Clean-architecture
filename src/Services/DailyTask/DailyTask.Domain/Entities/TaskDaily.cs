using DailyTask.Domain.Common;

namespace DailyTask.Domain.Entities
{
    public class TaskDaily : EntityBase
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public Status Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
