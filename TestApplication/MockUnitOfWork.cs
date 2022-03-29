using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockTaskRepo = MockRepository.GetTaskDailyRepository();
            mockUow.Setup(r => r.GetRepository<TaskDaily>().GetAll()).Returns(mockTaskRepo.Object.GetAll());
 
            return mockUow;
        }
    }
}
