﻿using Backend.Domain.Common;

namespace Backend.Application.Responses
{
    public class TaskDailyResponse : EntityBase
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public Status Status { get; set; }
    }
}