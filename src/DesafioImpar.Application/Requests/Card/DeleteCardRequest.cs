using DesafioImpar.Application.Shared;
using MediatR;

namespace DesafioImpar.Application.Requests.Card
{
    public class DeleteCardRequest : IRequest<OperationResult>
    {
        public int Id { get; set; }

        public DeleteCardRequest(int id)
            => Id = id;

    }
}
