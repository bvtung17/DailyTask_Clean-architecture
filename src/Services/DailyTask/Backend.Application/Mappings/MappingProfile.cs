namespace Backend.Application.Mappings
{
    using AutoMapper;
    using Backend.Application.Dtos;
    using Backend.Application.Features.DailyTasks.Commands;
    using Backend.Application.Responses;
    using Backend.Domain.Entities;

    /// <summary>
    /// The mapping profile.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // Dto -> Request / Response -> Entity
            CreateMap<TaskDailyDto, TaskDailyResponse>();
            CreateMap<TaskDailyResponse, TaskDailyResponse>();

            //Request/Response -> Entity
            CreateMap<DailyTask, TaskDailyResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<TaskDailyResponse, DailyTask>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<DailyTask, TaskDailyResponse>();
            CreateMap<TaskDailyResponse, DailyTask>();
            //Command -> Entity
            CreateMap<DailyTask, CreateDailyTaskCommand>();
            CreateMap<CreateDailyTaskCommand, DailyTask>();
            CreateMap<DailyTask, UpdateDailyTaskCommand>();
            CreateMap<UpdateDailyTaskCommand, DailyTask>();
            CreateMap<DailyTask, DeleteDailyTaskCommand>();
            CreateMap<DeleteDailyTaskCommand, DailyTask>();


            //Dto -> Entity
            CreateMap<DailyTask, TaskDailyDto>();
            CreateMap<TaskDailyDto, DailyTask>();

            //Reponse -> Commnad
            CreateMap<TaskDailyResponse, CreateDailyTaskCommand>();
            CreateMap<CreateDailyTaskCommand, TaskDailyResponse>();
            CreateMap<TaskDailyResponse, UpdateDailyTaskCommand>();
            CreateMap<UpdateDailyTaskCommand, TaskDailyResponse>();
            CreateMap<TaskDailyResponse, DeleteDailyTaskCommand>();
            CreateMap<DeleteDailyTaskCommand, TaskDailyResponse>();

            //Dto -> Command
            CreateMap<TaskDailyDto, CreateDailyTaskCommand>();
            CreateMap<CreateDailyTaskCommand, TaskDailyDto>();
            CreateMap<TaskDailyDto, UpdateDailyTaskCommand>();
            CreateMap<UpdateDailyTaskCommand, TaskDailyDto>();
            CreateMap<TaskDailyDto, DeleteDailyTaskCommand>();
            CreateMap<DeleteDailyTaskCommand, TaskDailyDto>();
        }
    }
}