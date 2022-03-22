using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTask.Application.Contracts.Interfaces.IHandlers.ICommandHandlers
{
    public interface IDeleteUserCommandHandler
    {
        UserResponse DeleteUser(DeleteUserCommand request);
    }
}
