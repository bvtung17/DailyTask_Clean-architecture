using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApplication
{
    public static class MockRepository
    {
        public static Mock<IAsyncRepository<TaskDaily>> GetTaskDailyRepository()
        {
            var tasks = new List<TaskDaily>
            {
                new TaskDaily {
                    TimeEnd = DateTime.Now,
                    TimeStart = DateTime.Now,
                    Title = "Xin Chào",
                    UserId = 4,
                },
                new TaskDaily {
                    TimeEnd = DateTime.Now,
                    TimeStart = DateTime.Now,
                    Title = "Xin Chào 2",
                    UserId = 4,
                },
                new TaskDaily {
                    TimeEnd = DateTime.Now,
                    TimeStart = DateTime.Now,
                    Title = "Xin Chào 3",
                    UserId = 4,
                },
            };
            var mockRepo = new Mock<IAsyncRepository<TaskDaily>>();
            mockRepo.Setup(_ => _.GetAll()).ReturnsAsync(tasks);

            return mockRepo;
        }
       
    }
}
