using Backend.Application.Features.DailyTasks.Commands;
using FluentValidation;

namespace Backend.Application.Validations.Commands
{
    public class DeleteTaskDailyValidator : AbstractValidator<DeleteDailyTaskCommand>
    {
        public DeleteTaskDailyValidator()
        {
            RuleFor(_ => _.Id).NotEmpty().WithMessage("This field cannot be left blank!");
        }
    }
}
