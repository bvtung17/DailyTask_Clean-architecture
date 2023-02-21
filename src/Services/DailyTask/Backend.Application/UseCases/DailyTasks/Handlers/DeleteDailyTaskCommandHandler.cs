namespace Backend.Application.Features.DailyTasks.Handlers
{
    using Backend.Application.Contracts.Interfaces.Persistence;
    using Backend.Application.Features.DailyTasks.Commands;
    using MediatR;

    public class DeleteDailyTaskCommandHandler : IRequestHandler<DeleteDailyTaskCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        public DeleteDailyTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteDailyTaskCommand request, CancellationToken cancellationToken)
        {
            var taskDaily = await this.unitOfWork.DailyTaskRepository.GetByIdAsync(request.Id);
            this.unitOfWork.DailyTaskRepository.Delete(taskDaily);
            return true;
        }
    }
}
