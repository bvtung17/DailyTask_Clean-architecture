using DailyTask.Application.Features.DailyTasks.Commands;
using FluentValidation;

namespace DailyTask.Application.Validations.Commands
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(_ => _.Id).NotEmpty().WithMessage("This field cannot be left blank!");
        }
    }
}
