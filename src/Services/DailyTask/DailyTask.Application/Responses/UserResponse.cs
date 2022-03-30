using DailyTask.Domain.Common;

namespace DailyTask.Application.Responses
{
    public class UserResponse : EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
