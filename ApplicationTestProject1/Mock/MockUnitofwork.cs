using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTestProject1.Mock
{
    public static class MockUnitofwork
    {
      public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockTaskRepo = MockRepository.GetTaskDailyRepository();
            var mockUserRepo = MockRepository.GetUserRepository();
            mockUow.Setup(r => r.GetRepository<TaskDaily>()).Returns(mockLeaveTypeRepo.Object);
            mockUow.Setup(r => r.GetRepository<User>()).Returns(mockLeaveTypeRepo.Object);
            return mockUow;
        }
    }
}
