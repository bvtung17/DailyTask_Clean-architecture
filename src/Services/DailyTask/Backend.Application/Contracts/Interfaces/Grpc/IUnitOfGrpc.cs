// <copyright file="IUnitOfGrpc.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Application.Contracts.Interfaces.Grpc
{
    /// <summary>
    /// IUnit of grpc.
    /// </summary>
    public interface IUnitOfGrpc
    {
        /// <summary>
        /// Gets hello client.
        /// </summary>
        IHelloClient HelloClient { get; }
    }
}
