namespace Backend.Application.Features.DailyTasks.Handlers
{
    using AutoMapper;
    using Backend.Application.Contracts.Interfaces.Persistence;
    using Backend.Application.Responses;
    using Backend.Application.UseCases.DailyTasks.Queries;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Handler for searching daily tasks.
    /// </summary>
    public class SearchDailyTasksQueryHandler : IRequestHandler<SearchDailyTasksQuery, IReadOnlyList<TaskDailyResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchDailyTasksQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public SearchDailyTasksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyList<TaskDailyResponse>> Handle(SearchDailyTasksQuery request, CancellationToken cancellationToken)
        {
            var query = this.unitOfWork.DailyTaskRepository.AsQueryable();

            var tasks = await query
                .Where(t => t.Title.Contains(request.SearchTerm) || t.Note.Contains(request.SearchTerm))
                .Take(request.Take)
                .ToListAsync(cancellationToken);

            return this.mapper.Map<List<TaskDailyResponse>>(tasks);
        }
    }
}
