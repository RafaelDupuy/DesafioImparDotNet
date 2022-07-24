using DesafioImpar.Application.Shared;
using MediatR;

namespace DesafioImpar.Application.Requests.Photo
{
    public class UploadPhotoRequest : IRequest<OperationResult>
    {
        public string Base64Photo { get; set; }

        public UploadPhotoRequest(string base64Photo)
        {
            Base64Photo = base64Photo;
        }
    }
}
