namespace Backend.Application.Features.DailyTasks.Handlers
{
    using AutoMapper;
    using Backend.Application.Contracts.Interfaces.Persistence;
    using Backend.Application.Responses;
    using Backend.Application.UseCases.DailyTasks.Queries;
    using MediatR;

    /// <summary>
    /// Handler for getting a daily task by ID.
    /// </summary>
    public class GetDailyTaskByIdQueryHandler : IRequestHandler<GetDailyTaskByIdQuery, TaskDailyResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDailyTaskByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public GetDailyTaskByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<TaskDailyResponse> Handle(GetDailyTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await this.unitOfWork.DailyTaskRepository.GetByIdAsync(request.Id);
            
            if (task == null)
            {
                return null;
            }

            return this.mapper.Map<TaskDailyResponse>(task);
        }
    }
}
