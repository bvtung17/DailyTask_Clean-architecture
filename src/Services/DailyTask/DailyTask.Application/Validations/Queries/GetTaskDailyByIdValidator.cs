using DailyTask.Application.Features.DailyTasks.Queries;
using FluentValidation;

namespace DailyTask.Application.Validations.Queries
{
    public class GetTaskDailyByIdValidator : AbstractValidator<GetTaskDailyByIdQuery>
    {
        public GetTaskDailyByIdValidator()
        {
            RuleFor(_ => _.Id).NotEmpty().WithMessage("This field cannot be left blank!");
        }
    }
}
