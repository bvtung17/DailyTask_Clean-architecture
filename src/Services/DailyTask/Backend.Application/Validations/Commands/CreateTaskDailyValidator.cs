namespace Backend.Application.Validations.Commands
{
    using Backend.Application.Features.DailyTasks.Commands;
    using FluentValidation;

    /// <summary>
    /// Validator.
    /// </summary>
    public class CreateTaskDailyValidator : AbstractValidator<CreateDailyTaskCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTaskDailyValidator"/> class.
        /// </summary>
        public CreateTaskDailyValidator()
        {
            RuleFor(_ => _.TimeEnd).NotEmpty().WithMessage("This field cannot be left blank!");
            RuleFor(_ => _.TimeStart).NotEmpty().WithMessage("This field cannot be left blank!");
            RuleFor(_ => _.Title).NotEmpty().WithMessage("This field cannot be left blank!");
        }
    }
}
