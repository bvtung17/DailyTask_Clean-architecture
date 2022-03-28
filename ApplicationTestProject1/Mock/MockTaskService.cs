using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Application.Mappings;
using Moq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DailyTask.Domain.Entities;
using System.Linq;
using DailyTask.Application.Responses;
using System.Collections.Generic;
using Xunit;
using DailyTask.Application.Contracts.Services;

namespace ApplicationTestProject1.Mock
{
    public class MockTaskService
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<TaskDaily>> _mockRepo;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Mock<IUserService> _mockUserService;
        public MockTaskService()
        {
            var mappingConfig = new MapperConfiguration(_ => { _.AddProfile<MappingProfile>(); });
            _mapper = mappingConfig.CreateMapper();
            _mockRepo = MockTaskReponsitory.GetTaskDailyRepository();
            _mockUow = MockUnitofwork.GetUnitOfWork();
        }
        [Fact]
        public async Task<Mock<ITaskDailyService>> GetTaskDailyServicesAsync()
        {
            var mockService1 = new Mock<ITaskDailyService>();
            var mockRepo = MockTaskReponsitory.GetTaskDailyRepository();
            var mockUow = MockUnitofwork.GetUnitOfWork();
            mockUow.Setup(_ => _.GetRepository<TaskDaily>().AsQueryable()).Returns(mockRepo.Object.AsQueryable());
            var mockService = new TaskDailyService(_mockUow.Object, _mapper, _mockUserService.Object);
            mockService1.Setup(_ => _.GetAll(0)).Returns(mockService.GetAll(0));
            return mockService1;
        }
    }
}
