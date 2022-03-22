using AutoMapper;
using DailyTask.Application.Dtos;
using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;
using DailyTask.Domain.Entities;

namespace DailyTask.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Dto -> Request / Response -> Entity
            CreateMap<UserDto, UserResponse>();
            CreateMap<UserResponse, UserDto>();
            CreateMap<TaskDailyDto, TaskDailyResponse>();
            CreateMap<TaskDailyResponse, TaskDailyResponse>();

            //Request/Response -> Entity
            CreateMap<TaskDaily, TaskDailyResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<TaskDailyResponse, TaskDaily>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<User, UserResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<UserResponse, User>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));


            CreateMap<User, UserResponse>();
            CreateMap<UserResponse, User>();
            CreateMap<TaskDaily, TaskDailyResponse>();
            CreateMap<TaskDailyResponse, TaskDaily>();
            //Command -> Entity
            CreateMap<TaskDaily, CreateTaskDailyCommand>();
            CreateMap<CreateTaskDailyCommand, TaskDaily>();
            CreateMap<TaskDaily, UpdateTaskDailyCommand>();
            CreateMap<UpdateTaskDailyCommand, TaskDaily>();
            CreateMap<TaskDaily, DeleteTaskDailyCommand>();
            CreateMap<DeleteTaskDailyCommand, TaskDaily>();

            CreateMap<User, CreateUserCommand>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, UpdateUserCommand>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, DeleteUserCommand>();
            CreateMap<DeleteUserCommand, User>();

            //Dto -> Entity
            CreateMap<User, UserDto>(); 
            CreateMap<UserDto, User>();
            CreateMap<TaskDaily, TaskDailyDto>();
            CreateMap<TaskDailyDto, TaskDaily>();

            //Reponse -> Commnad
            CreateMap<TaskDailyResponse, CreateTaskDailyCommand>();
            CreateMap<CreateTaskDailyCommand, TaskDailyResponse>();
            CreateMap<TaskDailyResponse, UpdateTaskDailyCommand>();
            CreateMap<UpdateTaskDailyCommand, TaskDailyResponse>();
            CreateMap<TaskDailyResponse, DeleteTaskDailyCommand>();
            CreateMap<DeleteTaskDailyCommand, TaskDailyResponse>();

            CreateMap<UserResponse, CreateUserCommand>();
            CreateMap<CreateUserCommand, UserResponse>();
            CreateMap<UserResponse, UpdateUserCommand>();
            CreateMap<UpdateUserCommand, UserResponse>();
            CreateMap<UserResponse, DeleteUserCommand>();
            CreateMap<DeleteUserCommand, UserResponse>();
            //Dto -> Command
            CreateMap<TaskDailyDto, CreateTaskDailyCommand>();
            CreateMap<CreateTaskDailyCommand, TaskDailyDto>();
            CreateMap<TaskDailyDto, UpdateTaskDailyCommand>();
            CreateMap<UpdateTaskDailyCommand, TaskDailyDto>();
            CreateMap<TaskDailyDto, DeleteTaskDailyCommand>();
            CreateMap<DeleteTaskDailyCommand, TaskDailyDto>();
            CreateMap<UserDto, CreateUserCommand>();
            CreateMap<CreateUserCommand, UserDto>();
            CreateMap<UserDto, UpdateUserCommand>();
            CreateMap<UpdateUserCommand, UserDto>();
            CreateMap<UserDto, DeleteUserCommand>();
            CreateMap<DeleteUserCommand, UserDto>();
        }
    }
}