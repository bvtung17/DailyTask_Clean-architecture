﻿using DailyTask.Application.Features.DailyTasks.Commands;
using FluentValidation;

namespace DailyTask.Application.Behaviours.Commands
{
    public class DeleteTaskDailyValidator : AbstractValidator<DeleteTaskDailyCommand>
    {
        public DeleteTaskDailyValidator()
        {
            RuleFor(_ => _.Id).NotEmpty().WithMessage("This field cannot be left blank!");
        }
    }
}
