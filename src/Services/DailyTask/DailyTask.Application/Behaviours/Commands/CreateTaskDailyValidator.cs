using DailyTask.Application.Features.DailyTasks.Commands;
using FluentValidation;

namespace DailyTask.Application.Behaviours.Commands
{
    public class CreateTaskDailyValidator : AbstractValidator<CreateTaskDailyCommand>
    {
        public CreateTaskDailyValidator()
        {
            RuleFor(_ => _.Id).NotEmpty().WithMessage("This field cannot be left blank!");
            RuleFor(_ => _.TimeEnd).NotEmpty().WithMessage("This field cannot be left blank!");
            RuleFor(_ => _.TimeStart).NotEmpty().WithMessage("This field cannot be left blank!");
            RuleFor(_ => _.Title).NotEmpty().WithMessage("This field cannot be left blank!");
            RuleFor(_ => _.UserId).NotEmpty().WithMessage("This field cannot be left blank!");
        }
    }
}
