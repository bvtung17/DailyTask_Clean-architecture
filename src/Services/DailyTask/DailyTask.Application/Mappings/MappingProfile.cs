using AutoMapper;
using DailyTask.Application.Commands;
using DailyTask.Application.Dtos;
using DailyTask.Application.Responses;
using DailyTask.Domain.Entities;

namespace DailyTask.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<TaskDaily, TaskDailyDto>();
            CreateMap<TaskDailyDto, TaskDaily>();
            CreateMap<TaskDaily, CreateTaskDailyCommand>();
            CreateMap<CreateTaskDailyCommand, TaskDaily>();
            CreateMap<TaskDailyResponse, CreateTaskDailyCommand>();
            CreateMap<CreateTaskDailyCommand, TaskDailyResponse>();
            CreateMap<TaskDaily, TaskDailyResponse>();
            CreateMap<CreateTaskDailyCommand, TaskDaily>();
            
        }
    }
}