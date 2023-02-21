namespace Backend.Application.Features.DailyTasks.Handlers
{
    using AutoMapper;
    using Backend.Application.Contracts.Interfaces.Persistence;
    using Backend.Application.Features.DailyTasks.Commands;
    using Backend.Application.Responses;
    using Backend.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handler.
    /// </summary>
    public class CreateDailyTaskCommandHandler : IRequestHandler<CreateDailyTaskCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateDailyTaskCommandHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The auto mapper.</param>
        public CreateDailyTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<bool> Handle(CreateDailyTaskCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var entity = this.mapper.Map<DailyTask>(request);
            await this.unitOfWork.DailyTaskRepository.AddAsync(entity);
            await this.unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
