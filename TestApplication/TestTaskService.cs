using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Application.Contracts.Services;
using DailyTask.Application.Mappings;
using DailyTask.Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestApplication
{

    public class TestTaskService
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<TaskDaily>> _mockRepo;
        private readonly Mock<IUnitOfWork> _mockUow;
        public TestTaskService()
        {
            _mockRepo = MockRepository.GetTaskDailyRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetAllAsync()
        {
            var service = new TaskDailyService(_mockUow.Object, _mapper, null);
            var result = await service.GetAll(0);
            Assert.Equal(result.Count, 3);
        }
    }
}