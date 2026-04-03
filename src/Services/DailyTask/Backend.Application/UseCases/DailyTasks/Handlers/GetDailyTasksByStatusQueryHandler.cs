namespace Backend.Application.Features.DailyTasks.Handlers
{
    using AutoMapper;
    using Backend.Application.Contracts.Interfaces.Persistence;
    using Backend.Application.Responses;
    using Backend.Application.UseCases.DailyTasks.Queries;
    using MediatR;

    /// <summary>
    /// Handler for getting daily tasks filtered by status.
    /// </summary>
    public class GetDailyTasksByStatusQueryHandler : IRequestHandler<GetDailyTasksByStatusQuery, IReadOnlyList<TaskDailyResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDailyTasksByStatusQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public GetDailyTasksByStatusQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyList<TaskDailyResponse>> Handle(GetDailyTasksByStatusQuery request, CancellationToken cancellationToken)
        {
            var tasks = await this.unitOfWork.DailyTaskRepository.GetByStatusAsync(request.Status, request.Take);
            return this.mapper.Map<List<TaskDailyResponse>>(tasks);
        }
    }
}
