using AutoMapper;
using DesafioImpar.Application.Requests.Photo;
using DesafioImpar.Application.Shared;
using DesafioImpar.Application.ViewModels.Photo;
using DesafioImpar.Infra.Interfaces;
using DesafioImpar.Infra.Repositories;
using MediatR;

namespace DesafioImpar.Application.RequestHandlers.Photos
{
    internal class ReadPhotoRequestHandler : BaseRequestHandler, 
        IRequestHandler<GetAllPhotosRequest, OperationResult>,
        IRequestHandler<GetPhotoAsFileByIdRequest, OperationResult>
    {
        private readonly IPhotoRepository _photoRepo;

        public ReadPhotoRequestHandler(PhotoRepository photoRepo, IMapper mapper) : base(mapper)
            => _photoRepo = photoRepo;

        public async Task<OperationResult> Handle(GetAllPhotosRequest request, CancellationToken cancellationToken)
        {
            var photos = await _photoRepo.GetAllAsync();
            return Success(Mapper.Map<List<PhotoViewModel>>(photos));
        }

        public async Task<OperationResult> Handle(GetPhotoAsFileByIdRequest request, CancellationToken cancellationToken)
        {
            var photo = await _photoRepo.GetByIdAsync(request.Id);
            if (photo is null)
                return NotFound();

            var photoBytes = Convert.FromBase64String(photo.Base64);
            return Success(new FileRequestResult
            {
                Content = photoBytes,
                MimeType = "image/png"
            });
        }
    }
}
