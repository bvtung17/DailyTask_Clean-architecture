// <copyright file="IHelloClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Application.Contracts.Interfaces.Grpc
{
    /// <summary>
    /// The client interface.
    /// </summary>
    public interface IHelloClient
    {
        /// <summary>
        /// Say hello.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <returns>Hello message.</returns>
        string SayHello(string message);
    }
}
