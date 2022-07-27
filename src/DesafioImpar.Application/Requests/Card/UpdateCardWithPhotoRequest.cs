using DesafioImpar.Application.Shared;
using MediatR;
using System.Text.Json.Serialization;

namespace DesafioImpar.Application.Requests.Card
{
    public class UpdateCardWithPhotoRequest : IRequest<OperationResult>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public int PhotoId { get; set; }

        public UpdateCardWithPhotoRequest(int id, string name, string status, int photoId)
        {
            Id = id;
            Name = name;
            Status = status;
            PhotoId = photoId;
        }
    }
}
