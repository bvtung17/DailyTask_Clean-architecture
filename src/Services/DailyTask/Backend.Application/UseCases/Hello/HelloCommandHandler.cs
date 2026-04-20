// <copyright file="HelloCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Application.UseCases.Hello
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    /// <summary>
    /// The handler.
    /// </summary>
    public class HelloCommandHandler : IRequestHandler<HelloCommand, string>
    {
        /// <inheritdoc/>
        public Task<string> Handle(HelloCommand request, CancellationToken cancellationToken)
        {
            var message = $"Sayyy Hello {request.Message}";
            return Task.FromResult(message);
        }
    }
}
