// <copyright file="HelloCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Application.UseCases.Hello
{
    using MediatR;

    /// <summary>
    /// Hello command.
    /// </summary>
    public class HelloCommand : IRequest<string>
    {
        /// <summary>
        /// Gets or sets message.
        /// </summary>
        public string Message { get; set; }
    }
}
