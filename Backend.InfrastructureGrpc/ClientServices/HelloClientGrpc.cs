// <copyright file="HelloClientGrpc.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.InfrastructureGrpc.ClientServices
{
    using Backend.Application.Contracts.Interfaces.Grpc;
    using Backend.Grpc.Proto;
    using Backend.InfrastructureGrpc.Base;
    using global::Grpc.Net.ClientFactory;

    /// <summary>
    /// The hello client.
    /// </summary>
    public class HelloClientGrpc : BaseClientGrpc<Hello.HelloClient>, IHelloClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelloClientGrpc"/> class.
        /// Hello client.
        /// </summary>
        /// <param name="grpcClientFactory">grpc client factory.</param>
        public HelloClientGrpc(GrpcClientFactory grpcClientFactory)
            : base(grpcClientFactory)
        {
        }

        /// <inheritdoc/>
        public string SayHello(string message)
        {
            return $"Hello + {message}";
        }
    }
}
