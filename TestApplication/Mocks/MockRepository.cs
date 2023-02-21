using Backend.Application.Contracts.Interfaces.Persistence;
using Backend.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;

namespace TestApplication
{
    public static class MockRepository
    {
        public static Mock<IGenericRepository<DailyTask>> GetTaskDailyRepository()
        {
            var tasks = new List<DailyTask>
            {
                new DailyTask {
                    TimeEnd = DateTime.Now,
                    TimeStart = DateTime.Now,
                    Title = "Xin Chào",
                    
                },
                new DailyTask {
                    TimeEnd = DateTime.Now,
                    TimeStart = DateTime.Now,
                    Title = "Xin Chào 2",
                    
                },
                new DailyTask {
                    TimeEnd = DateTime.Now,
                    TimeStart = DateTime.Now,
                    Title = "Xin Chào 3",
                    
                },
            };
            var mockRepo = new Mock<IGenericRepository<DailyTask>>();

            return mockRepo;
        }
       
    }
}
