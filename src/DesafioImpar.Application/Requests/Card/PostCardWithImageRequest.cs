using DesafioImpar.Application.Shared;
using MediatR;

namespace DesafioImpar.Application.Requests.Card
{
    public class PostCardWithImageRequest : IRequest<OperationResult>
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public string PhotoBase64 { get; set; }

        public PostCardWithImageRequest(string name, string status, string photoBase64)
        {
            Name = name;
            Status = status;
            PhotoBase64 = photoBase64;
        }
    }
}
