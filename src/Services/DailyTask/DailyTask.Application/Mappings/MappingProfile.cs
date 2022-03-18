using AutoMapper;
using DailyTask.Application.Dtos;
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
        }
    }
}