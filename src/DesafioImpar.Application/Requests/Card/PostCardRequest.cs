using DesafioImpar.Application.Shared;
using MediatR;

namespace DesafioImpar.Application.Requests.Card
{
    public class PostCardRequest : IRequest<OperationResult>
    {
        public string Name { get; set; }

        public string Status { get; set; }
    }
}
