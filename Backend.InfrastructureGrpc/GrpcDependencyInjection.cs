using Backend.Application.Contracts.Interfaces.Grpc;
using Backend.Grpc.Proto;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.InfrastructureGrpc
{
    public static class GrpcDependencyInjection
    {
        public static IServiceCollection AddGrpcService(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfGrpc, UnitOfGrpc>();
            var uri = new Uri("https://localhost:5001");
            AddGrpcServiceGeneric<Hello.HelloClient>(service, uri);
            return service;
        }

        private static void AddGrpcServiceGeneric<T>(IServiceCollection services, Uri uri)
            where T : ClientBase
        {
            services.AddGrpcClient<T>(o =>
            {
                o.Address = uri;
            });
        }
    }
}
