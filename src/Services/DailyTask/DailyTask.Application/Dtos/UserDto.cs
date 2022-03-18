namespace DailyTask.Application.Dtos
{
    public class UserDto : EntityBaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
