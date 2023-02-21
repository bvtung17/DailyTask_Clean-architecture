// <copyright file="TaskDailyDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Application.Dtos
{
    using Backend.Domain.Common;

    /// <summary>
    /// DTO.
    /// </summary>
    public class TaskDailyDto : EntityBase
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
