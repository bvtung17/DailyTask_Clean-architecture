using DailyTask.Application.Features.DailyTasks.Queries;
using FluentValidation;

namespace DailyTask.Application.Behaviours.Queries
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdValidator()
        {
            RuleFor(_ => _.Id).NotEmpty().WithMessage("This field cannot be left blank!");
        }
    }
}
