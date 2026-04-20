// <copyright file="BaseClientGrpc.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Grpc.Net.ClientFactory;

namespace Backend.InfrastructureGrpc.Base
{
    /// <summary>
    /// The base client grpc.
    /// </summary>
    /// <typeparam name="T">The class.</typeparam>
    public class BaseClientGrpc<T>
        where T : class
    {
        private readonly GrpcClientFactory grpcClientFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseClientGrpc{T}"/> class.
        /// </summary>
        /// <param name="grpcClientFactory">The factory.</param>
        public BaseClientGrpc(GrpcClientFactory grpcClientFactory)
        {
            this.grpcClientFactory = grpcClientFactory;
        }

        /// <summary>
        /// Created client.
        /// </summary>
        /// <returns>Client factory.</returns>
        public T CreatedClient()
        {
            var type = typeof(T);
            return this.grpcClientFactory.CreateClient<T>(type.Name);
        }
    }
}
