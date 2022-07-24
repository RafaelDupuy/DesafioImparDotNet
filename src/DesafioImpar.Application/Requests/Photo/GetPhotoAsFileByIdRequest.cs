using DesafioImpar.Application.Shared;
using MediatR;

namespace DesafioImpar.Application.Requests.Photo
{
    public class GetPhotoAsFileByIdRequest : IRequest<OperationResult>
    {
        public int Id { get; set; }

        public GetPhotoAsFileByIdRequest(int id) => Id = id;
    }
}
