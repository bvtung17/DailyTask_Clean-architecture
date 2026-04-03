namespace Backend.Application.UseCases.DailyTasks.Queries
{
    using Backend.Application.Responses;
    using Backend.Domain.Common;
    using MediatR;

    /// <summary>
    /// Query to get a daily task by its ID.
    /// </summary>
    public class GetDailyTaskByIdQuery : IRequest<TaskDailyResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDailyTaskByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The task ID.</param>
        public GetDailyTaskByIdQuery(Guid id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the task ID.
        /// </summary>
        public Guid Id { get; set; }
    }
}
