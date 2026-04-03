namespace Backend.Domain.Common
{
    /// <summary>
    /// Represents the status of a daily task.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Task is pending and not yet started.
        /// </summary>
        Todo = 0,

        /// <summary>
        /// Task is currently in progress.
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// Task has been completed.
        /// </summary>
        Done = 2,

        /// <summary>
        /// Task has been cancelled.
        /// </summary>
        Cancelled = 3,
    }
}
