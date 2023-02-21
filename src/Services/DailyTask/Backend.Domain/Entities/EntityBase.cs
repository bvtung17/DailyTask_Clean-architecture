namespace Backend.Domain.Common
{
    /// <summary>
    /// The entity base.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the createdBy.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate.
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the LastModifiedBy.
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the LastModifiedDate.
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }
    }
}