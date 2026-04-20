using Backend.Application.Contracts.Interfaces.Grpc;
using Backend.InfrastructureGrpc.ClientServices;
using Grpc.Net.ClientFactory;

namespace Backend.InfrastructureGrpc
{
    /// <summary>
    /// The unit of grpc.
    /// </summary>
    public class UnitOfGrpc : IUnitOfGrpc
    {
        public readonly Lazy<IHelloClient> helloClient;

        public UnitOfGrpc(GrpcClientFactory grpcClientFactory)
        {
            this.helloClient = new Lazy<IHelloClient>(() => new HelloClientGrpc(grpcClientFactory));
        }

        public IHelloClient HelloClient => throw new NotImplementedException();
    }
}
