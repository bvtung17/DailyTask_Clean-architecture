namespace Backend.Application.Features.DailyTasks.Handlers
{
    using AutoMapper;
    using Backend.Application.Contracts.Interfaces.Persistence;
    using Backend.Application.Responses;
    using Backend.Application.UseCases.DailyTasks.Queries;
    using MediatR;

    /// <summary>
    /// Handler.
    /// </summary>
    public class GetAllTaskDailyQueryHandler : IRequestHandler<GetAllDailyTaskQuery, IReadOnlyList<TaskDailyResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllTaskDailyQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public GetAllTaskDailyQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyList<TaskDailyResponse>> Handle(GetAllDailyTaskQuery request, CancellationToken cancellationToken)
        {
            var list = this.unitOfWork.DailyTaskRepository.AsQueryable().ToList();
            return this.mapper.Map<List<TaskDailyResponse>>(list);
        }
    }
}
