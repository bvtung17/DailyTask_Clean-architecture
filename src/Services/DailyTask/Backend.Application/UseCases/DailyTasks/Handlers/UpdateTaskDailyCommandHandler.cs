namespace Backend.Application.Features.DailyTasks.Handlers
{
    using AutoMapper;
    using Backend.Application.Contracts.Interfaces.Persistence;
    using Backend.Application.Features.DailyTasks.Commands;
    using Backend.Application.Responses;
    using MediatR;

    /// <summary>
    /// Handler.
    /// </summary>
    public class UpdateTaskDailyCommandHandler : IRequestHandler<UpdateDailyTaskCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTaskDailyCommandHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public UpdateTaskDailyCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <inheritdoc/>
        public async Task<bool> Handle(UpdateDailyTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await this.unitOfWork.DailyTaskRepository.GetByIdAsync(request.Id);
            entity.TimeStart = request.TimeStart;
            entity.TimeEnd = request.TimeEnd;
            entity.Status = request.Status;
            entity.Title = request.Title;
            entity.Note = request.Note;
            entity.Status = request.Status;
            this.unitOfWork.DailyTaskRepository.Update(entity);
            await this.unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
