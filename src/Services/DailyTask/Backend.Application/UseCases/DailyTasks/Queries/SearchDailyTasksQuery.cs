namespace Backend.Application.UseCases.DailyTasks.Queries
{
    using Backend.Application.Responses;
    using MediatR;

    /// <summary>
    /// Query to search daily tasks by title or note.
    /// </summary>
    public class SearchDailyTasksQuery : IRequest<IReadOnlyList<TaskDailyResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchDailyTasksQuery"/> class.
        /// </summary>
        /// <param name="searchTerm">The search term.</param>
        /// <param name="take">The maximum number of tasks to return.</param>
        public SearchDailyTasksQuery(string searchTerm, int take = 10)
        {
            this.SearchTerm = searchTerm;
            this.Take = take;
        }

        /// <summary>
        /// Gets the search term.
        /// </summary>
        public string SearchTerm { get; set; }

        /// <summary>
        /// Gets the maximum number of tasks to return.
        /// </summary>
        public int Take { get; set; }
    }
}
