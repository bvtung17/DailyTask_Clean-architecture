using Backend.Application.UseCases.Hello;
using Backend.Grpc.Proto;
using Grpc.Core;
using MediatR;

namespace Backend.WebApi.GrpcService
{
    public class HelloServiceGrpc : Hello.HelloBase
    {
        private readonly IMediator mediator;
        public HelloServiceGrpc(IMediator mediator)
        {
            this.mediator = mediator;
        }

        ///<inheritdoc>/>
        public override async Task<MessageResponse> SayHello(MessageRequest request, ServerCallContext context)
        {
            var command = new HelloCommand() { Message = request.Message };
            var response = await this.mediator.Send(command);
            return new MessageResponse { Message = response };
        }
    }
}
