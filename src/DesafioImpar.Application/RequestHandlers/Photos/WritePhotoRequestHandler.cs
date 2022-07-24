using AutoMapper;
using DesafioImpar.Application.Requests.Photo;
using DesafioImpar.Application.Shared;
using DesafioImpar.Domain.Models;
using DesafioImpar.Infra.Interfaces;
using MediatR;

namespace DesafioImpar.Application.RequestHandlers.Photos
{
    public class WritePhotoRequestHandler : BaseRequestHandler, IRequestHandler<UploadPhotoRequest, OperationResult>, IRequestHandler<DeletePhotoRequest, OperationResult>
    {
        private readonly IPhotoRepository _photoRepo;

        public WritePhotoRequestHandler(IPhotoRepository photoRepo, IMapper mapper) : base(mapper)
            => _photoRepo = photoRepo;

        public async Task<OperationResult> Handle(UploadPhotoRequest request, CancellationToken cancellationToken)
        {
            var photo = new Photo
            {
                Base64 = request.Base64Photo
            };
            var id = await _photoRepo.InsertAsync(photo);
            return Success(id);
        }

        public async Task<OperationResult> Handle(DeletePhotoRequest request, CancellationToken cancellationToken)
        {
            var photo = await _photoRepo.GetByIdAsync(request.Id);
            if (photo is null)
                return NotFound();

            await _photoRepo.Delete(photo);
            return Success();
        }
    }
}
