﻿using DailyTask.Domain.Common;

namespace DailyTask.Application.Responses
{
    public class TaskDailyResponse : EntityBaseModel
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public Status Status { get; set; }
        public int UserId { get; set; }
    }
}