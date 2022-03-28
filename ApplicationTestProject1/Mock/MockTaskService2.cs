using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Application.Mappings;
using DailyTask.Application.Responses;
using DailyTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTestProject1.Mock
{
    public static class MockTaskService2
    {
        public static Mock<ITaskDailyService> GetTaskService2()
        {
            var mockService = new Mock<ITaskDailyService>();
            var mockRepo = MockTaskReponsitory.GetTaskDailyRepository();
            var mappingConfig = new MapperConfiguration(_ => { _.AddProfile<MappingProfile>(); });
            IMapper mapper = mappingConfig.CreateMapper();
            mockService.Setup(r => r.GetAll(1)).Returns((List<TaskDailyResponse> tasks) =>
            {
                var listTasks = mockRepo.Object.AsQueryable().ToListAsync();
                return mapper.Map<List<TaskDailyResponse>>(listTasks);
            });
            return mockService;
        }
    }
}
