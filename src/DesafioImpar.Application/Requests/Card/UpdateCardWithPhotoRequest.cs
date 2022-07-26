using DesafioImpar.Application.Shared;
using MediatR;

namespace DesafioImpar.Application.Requests.Card
{
    public class UpdateCardWithPhotoRequest : IRequest<OperationResult>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string PhotoBase64 { get; set; }

        public UpdateCardWithPhotoRequest(int id,string name, string status, string photoBase64)
        {
            Id = id;
            Name = name;
            Status = status;
            PhotoBase64 = photoBase64;
        }
    }
}
