namespace Backend.Application.UseCases.DailyTasks.Queries
{
    using Backend.Application.Responses;
    using MediatR;

    /// <summary>
    /// The daily task get all.
    /// </summary>
    public class GetAllDailyTaskQuery : IRequest<IReadOnlyList<TaskDailyResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllDailyTaskQuery"/> class.
        /// </summary>
        /// <param name="take">the number take.</param>
        public GetAllDailyTaskQuery(int take)
        {
            this.Take = take;
        }

        /// <summary>
        /// Gets or sets the number take.
        /// </summary>
        public int Take { get; set; }
    }
}
