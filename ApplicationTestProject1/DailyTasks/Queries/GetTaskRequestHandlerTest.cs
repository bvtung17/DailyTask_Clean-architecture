using ApplicationTestProject1.Mock;
using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Features.DailyTasks.Handlers;
using DailyTask.Application.Features.DailyTasks.Queries;
using DailyTask.Application.Mappings;
using DailyTask.Application.Responses;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTestProject1.DailyTasks.Queries
{
    public class GetTaskRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITaskDailyService> _mockService;
        public GetTaskRequestHandlerTest()
        {
            var mappingConfig = new MapperConfiguration(_ => { _.AddProfile<MappingProfile>(); });
            _mapper = mappingConfig.CreateMapper();
            _mockService = MockTaskService.GetTaskService();
        }
        
        public async Task GetAllTaskHanlerTest()
        {
            var handler = new GetAllTaskDailyQueryHandler(_mockService.Object);
            var result = await handler.Handle(new GetAllTaskDailyQuery(1), CancellationToken.None);
            result.ShouldBeOfType<List<TaskDailyResponse>>();
            result.Count.ShouldBe(1);
        }
    }
}
