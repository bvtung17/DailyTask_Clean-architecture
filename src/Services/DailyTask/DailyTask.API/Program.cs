using System.Reflection;
using AutoMapper;
using DailyTask.Application.Contracts.Interfaces.IServices;
using DailyTask.Application.Contracts.Interfaces.Persistence;
using DailyTask.Application.Contracts.Services;
using DailyTask.Application.Handlers;
using DailyTask.Application.Mappings;
using DailyTask.Infrastructure.Persistence;
using DailyTask.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<DailyDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("DailyTaskContext"));
});
// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
//DI
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddTransient<IAuthenticationService, AuthenticationService >();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITaskDailyService, TaskDailyService>();

//MediatR
//builder.Services.AddScoped<IGetTaskDailyByIdQueryHandler, GetTaskDailyByIdQueryHandler>();

builder.Services.AddMediatR(typeof(GetTaskDailyByIdQueryHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetAllTaskDailyQueryHandler).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(CreateTaskDailyCommandHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteTaskDailyCommandHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateTaskDailyCommandHandler).GetTypeInfo().Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
