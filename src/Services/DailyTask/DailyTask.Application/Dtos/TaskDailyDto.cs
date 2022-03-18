using DailyTask.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTask.Application.Dtos
{
    public class TaskDailyDto
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public Status Status { get; set; }
    }
}
