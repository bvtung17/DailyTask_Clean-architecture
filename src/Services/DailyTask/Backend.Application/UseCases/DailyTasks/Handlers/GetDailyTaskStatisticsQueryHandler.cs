namespace Backend.Application.Features.DailyTasks.Handlers
{
    using AutoMapper;
    using Backend.Application.Contracts.Interfaces.Persistence;
    using Backend.Application.UseCases.DailyTasks.Queries;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Handler for getting daily task statistics.
    /// </summary>
    public class GetDailyTaskStatisticsQueryHandler : IRequestHandler<GetDailyTaskStatisticsQuery, TaskDailyStatistics>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDailyTaskStatisticsQueryHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public GetDailyTaskStatisticsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<TaskDailyStatistics> Handle(GetDailyTaskStatisticsQuery request, CancellationToken cancellationToken)
        {
            var query = this.unitOfWork.DailyTaskRepository.AsQueryable();

            var total = await query.CountAsync(cancellationToken);
            var todoCount = await query.Where(t => t.Status == Status.Todo).CountAsync(cancellationToken);
            var inProgressCount = await query.Where(t => t.Status == Status.InProgress).CountAsync(cancellationToken);
            var doneCount = await query.Where(t => t.Status == Status.Done).CountAsync(cancellationToken);
            var cancelledCount = await query.Where(t => t.Status == Status.Cancelled).CountAsync(cancellationToken);

            return new TaskDailyStatistics
            {
                Total = total,
                TodoCount = todoCount,
                InProgressCount = inProgressCount,
                DoneCount = doneCount,
                CancelledCount = cancelledCount,
            };
        }
    }
}
