namespace Backend.Application.UseCases.DailyTasks.Queries
{
    using Backend.Domain.Common;
    using MediatR;

    /// <summary>
    /// Query to get statistics of daily tasks by status.
    /// </summary>
    public class GetDailyTaskStatisticsQuery : IRequest<TaskDailyStatistics>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDailyTaskStatisticsQuery"/> class.
        /// </summary>
        public GetDailyTaskStatisticsQuery()
        {
        }
    }

    /// <summary>
    /// Statistics of daily tasks.
    /// </summary>
    public class TaskDailyStatistics
    {
        /// <summary>
        /// Gets or sets the total number of tasks.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the number of todo tasks.
        /// </summary>
        public int TodoCount { get; set; }

        /// <summary>
        /// Gets or sets the number of in-progress tasks.
        /// </summary>
        public int InProgressCount { get; set; }

        /// <summary>
        /// Gets or sets the number of done tasks.
        /// </summary>
        public int DoneCount { get; set; }

        /// <summary>
        /// Gets or sets the number of cancelled tasks.
        /// </summary>
        public int CancelledCount { get; set; }
    }
}
