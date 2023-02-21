using Backend.Application.Features.DailyTasks.Commands;
using FluentValidation;

namespace Backend.Application.Validations.Commands
{
    public class UpdateTaskDailyValidator : AbstractValidator<UpdateDailyTaskCommand>
    {
        public UpdateTaskDailyValidator()
        {
            RuleFor(_ => _.Id).NotEmpty().WithMessage("This field cannot be left blank!");
            RuleFor(_ => _.TimeEnd).NotEmpty().WithMessage("This field cannot be left blank!");
            RuleFor(_ => _.TimeStart).NotEmpty().WithMessage("This field cannot be left blank!");
            RuleFor(_ => _.Title).NotEmpty().WithMessage("This field cannot be left blank!");
        }
    }
}
