namespace Backend.Application.UseCases.DailyTasks.Queries
{
    using Backend.Application.Responses;
    using Backend.Domain.Common;
    using MediatR;

    /// <summary>
    /// Query to get daily tasks filtered by status.
    /// </summary>
    public class GetDailyTasksByStatusQuery : IRequest<IReadOnlyList<TaskDailyResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDailyTasksByStatusQuery"/> class.
        /// </summary>
        /// <param name="status">The task status to filter by.</param>
        /// <param name="take">The maximum number of tasks to return.</param>
        public GetDailyTasksByStatusQuery(Status status, int take = 10)
        {
            this.Status = status;
            this.Take = take;
        }

        /// <summary>
        /// Gets the status filter.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Gets the maximum number of tasks to return.
        /// </summary>
        public int Take { get; set; }
    }
}
