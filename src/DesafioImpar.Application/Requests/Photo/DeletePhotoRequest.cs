using DesafioImpar.Application.Shared;
using MediatR;

namespace DesafioImpar.Application.Requests.Photo
{
    public class DeletePhotoRequest : IRequest<OperationResult>
    {
        public int Id { get; set; }

        public DeletePhotoRequest(int id)
            => Id = id;
    }
}
