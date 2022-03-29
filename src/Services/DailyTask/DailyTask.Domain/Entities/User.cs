using DailyTask.Domain.Common;

namespace DailyTask.Domain.Entities
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public virtual List<TaskDaily> TaskDailies { get; set; }
    }
}
