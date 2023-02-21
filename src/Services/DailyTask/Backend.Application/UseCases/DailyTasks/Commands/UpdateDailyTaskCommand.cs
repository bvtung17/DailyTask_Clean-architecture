namespace Backend.Application.Features.DailyTasks.Commands
{
    using Backend.Domain.Common;
    using MediatR;

    /// <summary>
    /// Command.
    /// </summary>
    public class UpdateDailyTaskCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the.
        /// </summary>
        public Guid Id { get; set; }

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