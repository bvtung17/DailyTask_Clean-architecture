namespace DailyTask.Domain.Common
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}