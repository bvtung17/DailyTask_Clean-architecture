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

namespace ApplicationTestProject1.Mock
{
    public class MockTaskService
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<TaskDaily>> _mockRepo;
        public MockTaskService(Mock<IAsyncRepository<TaskDaily>> mockRepo)
        {
            var mappingConfig = new MapperConfiguration(_ => { _.AddProfile<MappingProfile>(); });
            _mapper = mappingConfig.CreateMapper();
            _mockRepo = MockTaskReponsitory.GetTaskDailyRepository();
        }
        public async Task<Mock<ITaskDailyService>> GetTaskDailyServicesAsync()
        {
            var mockService = new Mock<ITaskDailyService>();
            var test = await _mockRepo.Object.AsQueryable().ToListAsync();
            mockService.Setup(x => x.GetAll(1)).ReturnsAsync((List<TaskDailyResponse> taskDailyResponse) =>
            {               
                return _mapper.Map<List<TaskDailyResponse>>(test);
            });
            return mockService;
        }
    }
}
