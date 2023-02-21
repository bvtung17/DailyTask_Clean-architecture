namespace Backend.Application.Features.DailyTasks.Commands
{
    using MediatR;

    /// <summary>
    /// Command.
    /// </summary>
    public class DeleteDailyTaskCommand : IRequest<bool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteDailyTaskCommand"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public DeleteDailyTaskCommand(Guid id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public Guid Id { get; set; }
    }
}
