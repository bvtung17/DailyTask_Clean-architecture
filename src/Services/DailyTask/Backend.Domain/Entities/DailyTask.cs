namespace Backend.Domain.Entities
{
    using global::Backend.Domain.Common;

    /// <summary>
    /// The daily task entity.
    /// </summary>
    public class DailyTask : EntityBase
    {
        /// <summary>
        /// Gets or sets the.
        /// </summary>
        public DateTime TimeStart { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the.
        /// </summary>
        public DateTime TimeEnd { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the.
        /// </summary>
        public Status Status { get; set; }
    }
}
