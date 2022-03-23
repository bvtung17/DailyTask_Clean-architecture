using DailyTask.Application.Features.DailyTasks.Queries;
using FluentValidation;

namespace DailyTask.Application.Validations.Queries
{
    public class GetTaskDailyByUserIdValidator : AbstractValidator<GetTaskDailyByUserIdQuery>
    {
        public GetTaskDailyByUserIdValidator()
        {
            RuleFor(_ => _.UserId).NotEmpty().WithMessage("This field cannot be left blank!");
        }
    }
}
