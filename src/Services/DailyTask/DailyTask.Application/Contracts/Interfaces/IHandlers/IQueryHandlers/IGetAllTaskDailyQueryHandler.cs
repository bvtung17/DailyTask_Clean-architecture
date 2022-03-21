﻿using DailyTask.Application.Queries;
using DailyTask.Application.Responses;

namespace DailyTask.Application.Contracts.Interfaces.IHandlers.IQueryHandlers
{
    public interface IGetAllTaskDailyQueryHandler
    {
        List<TaskDailyResponse> GetTaskDailyById(GetAllTaskDailyQuery request);
    }
}
