using DailyTask.Application.Features.DailyTasks.Commands;
using FluentValidation;

namespace DailyTask.Application.Validations.Commands
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(_ => _.FullName).NotEmpty().WithMessage("This field cannot be left blank!").MaximumLength(250);
            RuleFor(_ => _.UserName).NotEmpty().WithMessage("This field cannot be left blank!").MaximumLength(250);
            RuleFor(_ => _.Password).NotEmpty().WithMessage("This field cannot be left blank!").MaximumLength(250);
        }
    }
}
