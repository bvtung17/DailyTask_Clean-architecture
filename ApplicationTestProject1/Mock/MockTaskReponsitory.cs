using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTestProject1
{
    public static class MockTaskReponsitory
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
            var mockUnit = new Mock<IAsyncRepository<TaskDaily>>();
            mockUnit.Setup(r => r.AsQueryable().ToList()).Returns(tasks);
            mockUnit.Setup(r => r.AddAsync(It.IsAny<TaskDaily>())).ReturnsAsync((TaskDaily taskDaily) =>
                  {
                      tasks.Add(taskDaily);
                      return taskDaily;  
              });
            return mockUnit;
        }
    }
}